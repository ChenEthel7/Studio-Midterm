using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

//using the window kinect instead of unity kinect
using Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class BodySourceViewHand : MonoBehaviour
{
	public BodySourceManager mBodySourceManager;
	public GameObject mJointObject;
	
	private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();
	private List<JointType> _joints = new List<JointType>
	{
		JointType.HandLeft,
		JointType.HandRight,
		
	};
	void HUpdate()
	{
		//get kinect data
		Body[] data = mBodySourceManager.GetData();
		if(data == null)
			return;

		List<ulong> trackedIds = new List<ulong>();
		// get all data from kinect
		foreach (var body in data)
		{
			if (body == null)
			{
				continue;
			}

			if (body.IsTracked)
			{
				trackedIds.Add(body.TrackingId);
			}
		}
		//deleting kinect body
		List<ulong> knownIds = new List<ulong>(mBodies.Keys);
		foreach (ulong trackingId in knownIds)
		{
			if (!trackedIds.Contains(trackingId))
			{
				// destroy body object
				Destroy(mBodies[trackingId]);

				// Remove from List
				mBodies.Remove(trackingId);
			}
		}
		
		// creates kinect bodies
		foreach (var body in data)
		{
			//if no body skip
			if (body == null)
			{
				continue;
			}
			if (body.IsTracked)
			{
				// If body isn't tracked, create Body
				if(! mBodies.ContainsKey(body.TrackingId))
				{
					mBodies[body.TrackingId] = HCreateBodyObject(body.TrackingId);
				}

				// Update positions
				HUpdateBodyObject(body, mBodies[body.TrackingId]);
			}
		}
	}

	private GameObject HCreateBodyObject(ulong id)
	{
		//create body parent
		GameObject body = new GameObject("Body:" +id);

		// Create joints
		foreach (JointType joint in _joints)
		{
			// Create object
			GameObject newJoint = Instantiate(mJointObject);
			
			newJoint.name = joint.ToString();

			// parent to Body
			newJoint.transform.parent = body.transform;
		}
		return body;

	}

	private void HUpdateBodyObject (Body body, GameObject bodyObject)
	{
		// upate joints
		foreach (JointType _joints in _joints)
		{
			//Get new target position
			Joint sourceJoint = body.Joints[_joints];
			Vector3 targetPosition = HGetVector3FromJoint(sourceJoint);
			targetPosition.z = 0;

			// Get joint, set new position
			Transform jointObject = bodyObject.transform.Find(_joints.ToString());
			jointObject.position = targetPosition;
		}
	}
	
	private Vector3 HGetVector3FromJoint(Joint joint)
	{
		return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);

	}


}
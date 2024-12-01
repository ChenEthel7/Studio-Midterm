using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public Transform mHandMesh;
    
    // Update is called once per frame
    private void Update()
    {
        //hand mesh to follow the joint
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         //tag check for bubble
        if (!collision.gameObject.CompareTag("Ear"))
            return;

        collision.gameObject.SetActive(false);
            
    }
}
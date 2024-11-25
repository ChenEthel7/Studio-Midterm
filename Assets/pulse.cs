using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pulse : MonoBehaviour
{
    

// Grow parameters
public float approachSpeed = 0.02f;
public float growthBound = 2f;
public float shrinkBound = 0.5f;
private float currentRatio = 1f;

// The text object we're trying to manipulate
private GameObject text;
private float originalFontSize;
    private AudioSource audioSource;

// And something to do the manipulating
private Coroutine routine;
private bool keepGoing = true;
private bool closeEnough = false;

    private bool sound = false;

// Attach the coroutine
void Awake()
{
    // Find the text  element we want to use
    this.text = this.gameObject;
        if (this.gameObject.GetComponent<AudioSource>() != null)
        { //errors here
            this.sound = true;
            this.audioSource = this.gameObject.GetComponent<AudioSource>();
        }
        


    // Then start the routine
    this.routine = StartCoroutine(this.Pulse());
}

IEnumerator Pulse()
{
        // Run this indefinitely
        while (keepGoing)
        {
            // Range to wait while still
            yield return new WaitForSeconds(Random.Range(4f, 9f));
            
            // Range of number of grow/shrink cycles before waiting again
            int f = (int)Random.Range(30f, 40f);
            if (this.sound)
            {
                this.audioSource.Play();
            }

            for (int i = 0; i < f; i++) {
                // Range of grow/shrink speed
                approachSpeed = Random.Range(0.07f, 0.1f);

                // Range of growth bound
                growthBound = Random.Range(0.9f, 1.1f);

                while (this.currentRatio != this.growthBound)
                {

                    // Determine the new ratio to use
                    currentRatio = Mathf.MoveTowards(currentRatio, growthBound, approachSpeed);

                    // Update our text element
                    this.text.transform.localScale = Vector3.one * currentRatio;


                    yield return new WaitForEndOfFrame();
                }

                // Range of shrink bound
                shrinkBound = Random.Range(0.9f, 1.1f);

                while (this.currentRatio != this.shrinkBound)
                {

                    // Determine the new ratio to use
                    currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, approachSpeed);

                    // Update our text element
                    this.text.transform.localScale = Vector3.one * currentRatio;


                    yield return new WaitForEndOfFrame();
                }
                
            }
            if (this.sound)
            {
                this.audioSource.Stop();
            }
        }
}
}

//public class pulse : MonoBehaviour

//{ 
//    // Grow parameters
//    public float approachSpeed = 0.02f;
//public float growthBound = 2f;
//public float shrinkBound = 0.5f;
//private float currentRatio = 1;

//// The text object we're trying to manipulate
//private GameObject text;
//private float originalFontSize;

//// And something to do the manipulating
//private Coroutine routine;
//private bool keepGoing = true;
//private bool closeEnough = false;

//// Attach the coroutine
//void Awake()
//{
//    // Find the text  element we want to use
//    this.text = this.gameObject;

//    // Then start the routine
//    this.routine = StartCoroutine(this.Pulse());
//}

//IEnumerator Pulse()
//{
//    // Run this indefinitely
//    while (keepGoing)
//    {
//        // Get bigger for a few seconds
//        while (this.currentRatio != this.growthBound)
//        {
//            // Determine the new ratio to use
//            currentRatio = Mathf.MoveTowards(currentRatio, growthBound, approachSpeed);

//            // Update our text element
//            this.text.transform.localScale = Vector3.one * currentRatio;
            

//            yield return new WaitForEndOfFrame();
//        }

//        // Shrink for a few seconds
//        while (this.currentRatio != this.shrinkBound)
//        {
//            // Determine the new ratio to use
//            currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, approachSpeed);

//            // Update our text element
//            this.text.transform.localScale = Vector3.one * currentRatio;
            

//            yield return new WaitForEndOfFrame();
//        }
//    }
//}
//}

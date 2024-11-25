using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidertest : MonoBehaviour
{
    [SerializeField]
    Animator myAnim;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Brain")
        {
            myAnim.SetTrigger("Trigger");
        }
       
    }
}

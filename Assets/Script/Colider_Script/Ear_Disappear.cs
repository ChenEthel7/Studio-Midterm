using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ear_Disappear : MonoBehaviour
{
    [SerializeField]
    EarOn EO;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ear")
        {
           EO.Ear = true;
        }
       
    }
}

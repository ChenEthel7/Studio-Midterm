using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Disappear : MonoBehaviour
{
    [SerializeField]
    HeartOn HO;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Heart")
        {
           HO.Heart = true;
        } 
    }
}

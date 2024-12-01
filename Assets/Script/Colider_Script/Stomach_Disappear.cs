using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomach_Disappear : MonoBehaviour
{
    [SerializeField]
    StomachOn SO;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Stomach")
        {
            SO.Stomach = true;
        }     
    }
}

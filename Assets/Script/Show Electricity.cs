using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowElectricity : MonoBehaviour
{
    [SerializeField]
    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nerve"))
           {
               myAnim.SetTrigger("OFF");
           }
    }
}

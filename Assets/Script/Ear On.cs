using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarOn : MonoBehaviour
{
    [SerializeField]
    Animator myAnim;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            myAnim.SetTrigger("Ear");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarOn : MonoBehaviour
{
    [SerializeField]
    Animator myAnim;
    public bool Ear;
    // Start is called before the first frame update
    private void Start()
    {
         Ear = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("Player"))&& Ear)
        {
            myAnim.SetTrigger("Ear");
        }
    }
}

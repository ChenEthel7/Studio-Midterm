using System.Collections;
using UnityEngine;


public class disappear : MonoBehaviour
{
    [SerializeField]
    Animator myAnim;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
     

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            myAnim.SetTrigger("Trigger");
        }
        
    }
}

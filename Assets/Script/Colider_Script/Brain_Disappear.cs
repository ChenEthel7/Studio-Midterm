using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain_Disappear : MonoBehaviour
{
    [SerializeField]
    BrainOn BO;
    [SerializeField]
    Animator myAnim;
    private void Start()
    {

    }
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Brain")
        {
           BO.Brain = true;
           myAnim.SetTrigger("ON");
        }
        
        
    }
}

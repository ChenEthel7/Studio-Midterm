using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartOn : MonoBehaviour
{
    [SerializeField]
    Animator myAnim;
    public bool Heart;
    // Start is called before the first frame update
    private void Start()
    {
        Heart = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("Player")) && Heart)
        {
            myAnim.SetTrigger("Heart");
        }
    }
}

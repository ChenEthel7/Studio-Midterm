using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyOFF : MonoBehaviour
{
    [SerializeField]
    DynamicButterflyGuide BO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ButterflyTrail"))
           {
                BO.butterflyTriggered = false;
           }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomach_Disappear : MonoBehaviour
{
    public ParticleSystem PR;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Stomach")
        {
            PR.Play();
        StartCoroutine(StopParticleSystem(PR,5));
        }
       
    }
     IEnumerator StopParticleSystem(ParticleSystem ps, float time)
    {
        yield return new WaitForSeconds(time);
        ps.Stop();
    }
}

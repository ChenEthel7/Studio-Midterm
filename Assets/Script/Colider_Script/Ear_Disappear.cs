using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ear_Disappear : MonoBehaviour
{
    [SerializeField]
    EarOn EO;
    public ParticleSystem PR;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ear")
        {
           EO.Ear = true;
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

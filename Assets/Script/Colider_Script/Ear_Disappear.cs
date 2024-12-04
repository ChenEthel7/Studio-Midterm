using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ear_Disappear : MonoBehaviour
{
    [SerializeField]
    EarOn EO;
    [SerializeField]
    HeartOn HO;
    public ParticleSystem PR;
    public AudioSource audio;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ear")
        {
           EO.Ear = true;
           HO.HeartE = true;
           PR.Play();
           audio.Play();
            StartCoroutine(StopParticleSystem(PR,5));
        }  
    }
    IEnumerator StopParticleSystem(ParticleSystem ps, float time)
    {
        yield return new WaitForSeconds(time);
        ps.Stop();
    }
}

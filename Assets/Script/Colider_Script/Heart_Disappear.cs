using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Disappear : MonoBehaviour
{
    [SerializeField]
    HeartOn HO;
    public ParticleSystem PR;
    [SerializeField]
    BloodSpatterGuide BSO;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Heart")
        {
           HO.Heart = true;
           BSO.bloodsplatter = true;
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

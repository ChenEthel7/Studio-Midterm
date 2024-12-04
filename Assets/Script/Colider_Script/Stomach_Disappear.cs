using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomach_Disappear : MonoBehaviour
{
    [SerializeField]
    StomachOn SO;
    [SerializeField]
    HeartOn HO;
    public ParticleSystem PR;
    [SerializeField]
    DynamicButterflyGuide BO;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Stomach")
        {
            SO.Stomach = true;
            HO.HeartS = true;
            BO.butterflyTriggered = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain_Disappear : MonoBehaviour
{
    [SerializeField]
    BrainOn BO;
    [SerializeField]
    HeartOn HO;
    [SerializeField]
    Animator myAnim;
    public ParticleSystem PR;
    private void Start()
    {

    }
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Brain")
        {
           BO.Brain = true;
           HO.HeartB = true;
           myAnim.SetTrigger("ON");
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

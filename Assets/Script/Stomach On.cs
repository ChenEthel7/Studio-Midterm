using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomachOn : MonoBehaviour
{
    [SerializeField]
    Animator myAnim;
    public bool Stomach;
    // Start is called before the first frame update
    private void Start()
    {
        Stomach = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")) && Stomach)
        {
            myAnim.SetTrigger("Stomach");
        }
    }
}

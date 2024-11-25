using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Body_EffectScript : MonoBehaviour
{
   [SerializeField] VisualEffect _pathEffect;

   private void Start()
   {
	   PlayParticle();

   }

   void PlayParticle()
   {
	   _pathEffect.Play();

   }
}
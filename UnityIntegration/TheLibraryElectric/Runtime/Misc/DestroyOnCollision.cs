using UnityEngine;
using System;
using SLZ.VFX;
using TheLibraryElectric.Markers;

namespace TheLibraryElectric.Misc
{
    [AddComponentMenu("The Library Electric/Misc/Destroy On Collision")]
    public class DestroyOnCollision : ElectricBehaviour
    {
        private bool activeState;
        public AudioSource audioSource;
        public GameObject[] excludedObjects;
        private Transform rigManager;
        private Blip blip;
        public void Disable()
        {
            
        }
        public void Enable()
        {

        }
        private void Start()
        {
            
        }
        private void OnCollisionEnter(Collision collision)
        {
            return;
        }
        private bool IsObjectExcluded(GameObject obj)
        {
            return false;
        }
    }

}
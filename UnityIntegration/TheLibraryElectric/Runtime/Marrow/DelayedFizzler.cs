using System;
using SLZ.Marrow.Pool;
using UnityEngine;

namespace TheLibraryElectric.Marrow
{
	[AddComponentMenu("The Library Electric/Marrow/Delayed Fizzler")]
	[RequireComponent(typeof(Collider))]
    public class DelayedFizzler : ElectricBehaviour
    {
        public float delay = 1f;
        private AssetPoolee _assetPoolee;

        private void OnTriggerEnter(Collider other)
        {

        }
        
        private void Fizzle()
        {

        }
    }
}
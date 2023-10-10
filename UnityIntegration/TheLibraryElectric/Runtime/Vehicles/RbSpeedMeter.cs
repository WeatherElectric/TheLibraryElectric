using TMPro;
using UnityEngine;

namespace TheLibraryElectric.Vehicles
{
	[AddComponentMenu("The Library Electric/Vehicles/RB Speed Meter")]
    public class RbSpeedMeter : MonoBehaviour
    {
		[Tooltip("The targeted RB for the speed meter.")]
        public Rigidbody targetRigidbody;
		[Tooltip("The textmeshpro to show the speed on.")]
        public TextMeshPro speedText;
		[Tooltip("The text format.")]
        public string speedFormat = "Speed: {0:0.00} m/s";

        private void FixedUpdate()
        {
            if (targetRigidbody != null && speedText != null)
            {
                var speed = targetRigidbody.velocity.magnitude;
                speedText.text = string.Format(speedFormat, speed);
            }
        }
    }
}
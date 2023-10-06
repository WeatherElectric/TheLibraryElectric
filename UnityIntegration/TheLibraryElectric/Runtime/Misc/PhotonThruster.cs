using UnityEngine;
using TMPro;

namespace TheLibraryElectric.Misc
{
    // this is named after not enough photons since thrusters was originally an adamdev boneworks mod
	[AddComponentMenu("The Library Electric/Misc/Photon Thruster")]
	[RequireComponent(typeof(Rigidbody))]
    public class PhotonThruster : ElectricBehaviour
    {
		public override string Comment => "This must be on the same object as the rigidbody!";
		[Header("Base Settings")]
        [Tooltip("The amount of force this thruster will apply by default.")]
        public float thrustForce = 100f;
        public float ThrustForce
        {
            get => thrustForce;
            set => thrustForce = value;
        }
        [Tooltip("The object that'll get enabled/disabled when the thruster is enabled/disabled. I recommend you put particles and audio under it.")]
		public GameObject particles;
		[Header("Increment/Decrement Settings")]
        [Tooltip("Should this thruster use text to display the current force?")]
		public bool useText;
        [Tooltip("The text mesh pro object that'll display the current force.")]
		public TextMeshPro textMeshPro;
        [Tooltip("The amount to increment the force by")]
        public float incrementAmount = 50f;
        [Tooltip("The amount to decrement the force by")]
        public float decrementAmount = 50f;
        [Tooltip("The maximum force this thruster can have.")]
        public float maximumForce = 500f;
        [Tooltip("The minimum force this thruster can have.")]
        public float minimumForce = 50f;

        private bool _thrustEnabled;
        private Rigidbody _thisrb;
        
        private void Awake()
        {
            _thisrb = GetComponent<Rigidbody>();
        }

        public void Toggle()
        {
            if (_thrustEnabled)
            {
                _thrustEnabled = false;
                particles.SetActive(false);
            }
            else
            {
                _thrustEnabled = true;
                particles.SetActive(true);
            }
        }

        public void IncreaseForce()
        {
            if (thrustForce > maximumForce)
            {
                thrustForce += incrementAmount;
            }
            else
            {
                thrustForce = maximumForce;
            }
            if (useText)
            {
                UpdateTextValue(incrementAmount, false);
            }
        }

        public void DecreaseForce()
        {
            if (thrustForce < minimumForce)
            {
                thrustForce -= decrementAmount;
            }
            else
            {
                thrustForce = minimumForce;
            }
            if (useText)
            {
                UpdateTextValue(decrementAmount, true);
            }
        }
        
        public void UpdateTextValue(float value, bool subtract)
        {
            if (subtract)
            {
                var currentValue = float.Parse(textMeshPro.text);
                currentValue -= value;
                if (currentValue < minimumForce)
                {
                    currentValue = minimumForce;
                }
                textMeshPro.text = currentValue.ToString("F1");
            }
            else
            {
                var currentValue = float.Parse(textMeshPro.text);
                currentValue += value;
                if (currentValue > maximumForce)
                {
                    currentValue = maximumForce;
                }
                textMeshPro.text = currentValue.ToString("F1");
            }
        }
        
        private void FixedUpdate()
        {
            if (_thrustEnabled)
            {
                _thisrb.AddRelativeForce(transform.forward * thrustForce);
            }
        }
    }
}
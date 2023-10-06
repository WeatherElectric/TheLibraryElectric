using UnityEditor;
using UnityEngine;
using UltEvents;

namespace TheLibraryElectric.Signals
{
    [AddComponentMenu("The Library Electric/Signals/Signal Trigger")]
    public class SignalTrigger : ElectricBehaviour
    {
        [Tooltip("The key to activate this signal trigger.")]
        public string activationKey;
		[Tooltip("The event to invoke when the signal trigger enters the trigger.")]
        public UltEvent triggerEnterEvent;
        [Tooltip("The event to invoke when the signal trigger exits the trigger.")]
        public UltEvent triggerExitEvent;
        private void Start()
        {
        }
        private void OnTriggerEnter(Collider other)
        {
            var triggerer = other.GetComponent<SignalTriggerer>();
            if (triggerer != null)
            {
                if (triggerer.activationKey == activationKey)
                {
                    triggerEnterEvent.Invoke();
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            var triggerer = other.GetComponent<SignalTriggerer>();
            if (triggerer != null)
            {
                if (triggerer.activationKey == activationKey)
                {
                    triggerExitEvent.Invoke();
                }
                else
                {
                }
            }
        }
        #if UNITY_EDITOR
		private void OnDrawGizmos()
        {
			if (Selection.activeGameObject == gameObject)
				return;
            Collider collider = GetComponent<Collider>();

            if (collider != null && (collider is CapsuleCollider || collider is BoxCollider || collider is SphereCollider))
            {
                Gizmos.color = Color.yellow;

                // Draw gizmo based on collider type
                if (collider is CapsuleCollider)
                {
                    DrawCapsuleGizmo((CapsuleCollider)collider);
                }
                else if (collider is BoxCollider)
                {
                    DrawBoxGizmo((BoxCollider)collider);
                }
                else if (collider is SphereCollider)
                {
                    DrawSphereGizmo((SphereCollider)collider);
                }
            }
        }
        private void DrawCapsuleGizmo(CapsuleCollider capsuleCollider)
        {
            Vector3 position = transform.position + capsuleCollider.center;
			float height = capsuleCollider.height * transform.lossyScale.y;
			float radius = capsuleCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.z);
			Vector3 boxSize = new Vector3(radius * 2, height - 2 * radius, radius * 2);
			Gizmos.DrawWireSphere(position + Vector3.up * (height / 2 - radius), radius);
			Gizmos.DrawWireSphere(position - Vector3.up * (height / 2 - radius), radius);
			Gizmos.DrawWireCube(position, boxSize);
        }

        private void DrawBoxGizmo(BoxCollider boxCollider)
        {
            Vector3 position = transform.position + boxCollider.center;
            Vector3 size = Vector3.Scale(boxCollider.size, transform.lossyScale);
            Gizmos.DrawWireCube(position, size);
        }

        private void DrawSphereGizmo(SphereCollider sphereCollider)
        {
            Vector3 position = transform.position + sphereCollider.center;
            float radius = sphereCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);
            Gizmos.DrawWireSphere(position, radius);
        }
        #endif
    }
}
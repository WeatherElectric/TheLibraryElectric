using SLZ.Interaction;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Cube Break")]
#endif
    public class CubeBreak : MonoBehaviour
    {
        public float force = 10f;
        Vector3[] offsets = { new Vector3(0.25f, 0.25f, 0.25f), new Vector3(-0.25f, 0.25f, 0.25f), new Vector3(0.25f, 0.25f, -0.25f), new Vector3(-0.25f, 0.25f, -0.25f),
                            new Vector3(0.25f, -0.25f, 0.25f), new Vector3(-0.25f, -0.25f, 0.25f), new Vector3(0.25f, -0.25f, -0.25f), new Vector3(-0.25f, -0.25f, -0.25f),};
#if UNITY_EDITOR
        [ContextMenu("Break")]
#endif
        public void Break()
        {
            for (int i = 0; i < 8; i++)
            {
                var smallerCopy = Instantiate(gameObject, transform.position, transform.rotation);
                foreach (var grip in smallerCopy.GetComponents<Grip>())
                {
                    grip.ForceDetach();
                    grip.enabled = true;
                }
                try
                {
                    smallerCopy.transform.parent = transform;
                }
                catch { }
                smallerCopy.transform.localPosition += offsets[i];
                smallerCopy.transform.parent = null;
                smallerCopy.transform.localScale = transform.localScale / 2f;
                var body = smallerCopy.GetComponent<Rigidbody>();
                body.ResetCenterOfMass();
                body.ResetInertiaTensor();
                body.velocity = GetComponent<Rigidbody>().velocity;
                body.AddRelativeForce(transform.rotation * (offsets[i] * force), ForceMode.Impulse);
                body.AddRelativeTorque(transform.rotation * (offsets[i] * force + Vector3.one * (Random.value / 3f)), ForceMode.Impulse);
                body.mass /= 2;
                Destroy(gameObject);
            }
        }
#if !UNITY_EDITOR
        public CubeBreak(IntPtr ptr) : base(ptr) { }
#endif
    }
}

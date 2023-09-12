using UnityEngine;

namespace TheLibraryElectric.Helpers
{
    public static class RigidBodyHelper
    {
        public static void SetKinematic(Rigidbody body, bool b) 
        {
            body.isKinematic = b;
        }
        public static bool GetKinematic(Rigidbody body) 
        {
            return body.isKinematic;
        }
        public static void SetUseGravity(Rigidbody body, bool b)
        {
            body.useGravity = b;
        }
        public static bool GetUseGravity(Rigidbody body)
        {
            return body.useGravity;
        }
        public static void SetMass(Rigidbody body, float mass)
        {
            body.mass = mass;
        }
        public static float GetMass(Rigidbody body)
        {
            return body.mass;
        }
        public static void AddForce(Rigidbody body, Vector3 force)
        {
            body.AddForce(force);
        }
        public static void AddTorque(Rigidbody body, Vector3 torque)
        {
            body.AddTorque(torque);
        }
        public static void SetFreezeRotation(Rigidbody body, bool freezeRotation)
        {
            body.freezeRotation = freezeRotation;
        }
        public static bool GetFreezeRotation(Rigidbody body)
        {
            return body.freezeRotation;
        }
    }
}
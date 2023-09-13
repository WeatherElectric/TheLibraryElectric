using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.PlayerUtil
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Player Utilities/Rigmanager Control")]
#endif
    public class RigManagerControl : MonoBehaviour
    {
        public void RagDoll()
        {

        }
        public void UnRagDoll()
        {

        }
        public void Teleport(Vector3 feetPos)
        {
            return;
        }
        public void Teleport(Vector3 feetPos, bool zerovelocity)
        {
            return;
        }
        public void Invincible()
        {

        }
        public void Mortal()
        {

        }
        public void InstantDeath()
        {

        }
    }
}
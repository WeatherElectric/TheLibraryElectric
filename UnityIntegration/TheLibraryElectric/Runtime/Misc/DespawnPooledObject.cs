using SLZ.Marrow.Pool;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Misc
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Misc/Despawn Pooled Object")]
#endif
    public class DespawnPooledObject : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("This MUST be on root!")]
#endif
        private GameObject _self;
        private AssetPoolee _assetPoolee;
        private void Start()
        {
            _self = gameObject;
            _assetPoolee = gameObject.GetComponent<AssetPoolee>();
        }

        public void Despawn()
        {
            if (_assetPoolee != null)
            {
                _self.SetActive(false);
                _assetPoolee.Despawn();
            }
        }
    }
}
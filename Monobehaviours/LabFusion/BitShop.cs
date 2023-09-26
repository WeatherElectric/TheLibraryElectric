using System;
using LabFusion.SDK.Points;
using UltEvents;
using UnityEngine;

namespace TheLibraryElectric.LabFusion
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Fusion/Bit Shop")]
#endif
    public class BitShop : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("Settings")]
        [Tooltip("The bits needed to purchase.")]
#endif
        public int bitsRequired;
#if UNITY_EDITOR
        [Header("Events")]
        [Tooltip("Called if the player has enough bits.")]
#endif
        public UltEvent purchaseEvent;
#if UNITY_EDITOR
        [Tooltip("Called if the player does not have enough bits.")]
#endif
        public UltEvent noBitsEvent;
        public void Purchase()
        {
            var bits = PointItemManager.GetBitCount();
            if (bits == bitsRequired)
            {
                purchaseEvent.Invoke();
            }
            else
            {
                noBitsEvent.Invoke();
            }
        }
#if !UNITY_EDITOR
        public BitShop(IntPtr ptr) : base(ptr) { }
#endif
    }
}
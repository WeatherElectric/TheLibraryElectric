using System;
using UltEvents;
using UnityEngine;

namespace TheLibraryElectric.LabFusion
{
    [AddComponentMenu("The Library Electric/Fusion/Bit Shop")]
    public class BitShop : ElectricBehaviour
    {
        public override string Comment => "You do not need to use a Bit Reward Proxy! This takes away bits on it's own!";
        [Header("Shop Settings")]
        [Tooltip("The amount of bits required to purchase.")]
        public int bitsRequired;
        [Header("Events")]
        [Tooltip("Event that is called when the purchase is successful.")]
        public UltEvent purchaseEvent;
        [Tooltip("Event that is called when the purchase is unsuccessful.")]
        public UltEvent noBitsEvent;
        public void Purchase()
        {

        }
    }
}
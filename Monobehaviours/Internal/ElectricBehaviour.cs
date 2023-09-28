using System;
using UnityEngine;

namespace TheLibraryElectric 
{
    public class ElectricBehaviour : MonoBehaviour 
	{
		public ElectricBehaviour(IntPtr intPtr) : base(intPtr) { }

		private Transform _transform;
		private bool _hasTransform = false;
		public Transform Transform {
			get {
				if (!_hasTransform) {
					_transform = transform;
					_hasTransform = true;
				}

				return _transform;
			}
		}
    }
}
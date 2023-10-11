using SLZ.Marrow.Data;
using SLZ.Marrow.Warehouse;
using UnityEngine;
using SLZ.Marrow.Utilities;
using UltEvents;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric.Marrow
{
	[AddComponentMenu("The Library Electric/Marrow/Cooler Spawnable Placer")]
    public class CoolerSpawnablePlacer : ElectricBehaviour
    {
		[Header("Crate Reference")]
        public SpawnableCrateReference spawnableCrateReference;
        public SpawnPolicyData spawnPolicy;
		[Header("Spawn Settings")]
		[Tooltip("Should the crate not be placed on start?")]
        public bool manualMode;
		[Tooltip("Should it ignore the spawn policy? This can be set in UltEvents.")]
        public bool ignorePolicy;
        public bool IgnorePolicy
        {
            get => ignorePolicy;
            set => ignorePolicy = value;
        }
		public UltEvent onPlaceEvent;
		
#if UNITY_EDITOR
        public static bool showPreviewMesh = true;
        public static bool showColliderBounds = true;
		private static Material voidMaterial = null;
#endif

		public void Start()
		{
			
		}

        public void Spawn()
        {

        }
		
		public void SpawnWithForce(Vector3 force)
		{
			
		}
		
		private SpawnableCrateReference GetCrateReference()
        {
            if (AssetWarehouse.ready)
            {
                return spawnableCrateReference;
            }

            return null;
        }
	
		
		#if UNITY_EDITOR
        [DrawGizmo(GizmoType.Active | GizmoType.Selected | GizmoType.NonSelected)]
        private static void DrawPreviewGizmo(CoolerSpawnablePlacer placer, GizmoType gizmoType)
        {
            if (!Application.isPlaying && placer.gameObject.scene != default)
            {
                if (voidMaterial == null)
                {
                    voidMaterial = AssetDatabase.LoadAssetAtPath<Material>("Packages/com.stresslevelzero.marrow.sdk/sdk/Editor/Assets/Materials/Void Glow.mat");
                }
                EditorPreviewMeshGizmo.Draw("PreviewMesh", placer.gameObject, placer.GetCrateReference(), voidMaterial, !showPreviewMesh, !showColliderBounds, true);
            }
        }
		#endif
    }
}
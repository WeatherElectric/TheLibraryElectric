using System;
using BoneLib.Nullables;
using SLZ.Marrow.Data;
using SLZ.Marrow.Pool;
using UnityEngine;
using SLZ.Marrow.Warehouse;

namespace TheLibraryElectric.InternalHelpers
{
    public class SpawnCrate
    {
        public static void Spawn(string barcode, Vector3 position, Quaternion rotation, bool ignorePolicy, Action<GameObject> callback)
        {
            var reference = new SpawnableCrateReference(barcode);
            var spawnable = new Spawnable()
            {
                crateRef = reference
            };
            AssetSpawner.Register(spawnable);
            Action<GameObject> spawnAction = go =>
            {
                callback(go);
            };
            AssetSpawner.Spawn(spawnable, position, rotation, new BoxedNullable<Vector3>(null), ignorePolicy, new BoxedNullable<int>(null), spawnAction);
        }
    }
}
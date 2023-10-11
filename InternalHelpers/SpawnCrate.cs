using System;
using BoneLib.Nullables;
using SLZ.Marrow.Data;
using SLZ.Marrow.Pool;
using UnityEngine;
using SLZ.Marrow.Warehouse;

namespace TheLibraryElectric.InternalHelpers
{
    public static class SpawnCrate
    {
        public static void Spawn(Spawnable spawnable, Vector3 position, Quaternion rotation, bool ignorePolicy, Action<GameObject> callback)
        {
            AssetSpawner.Register(spawnable);
            Action<GameObject> spawnAction = go =>
            {
                callback(go);
            };
            AssetSpawner.Spawn(spawnable, position, rotation, new BoxedNullable<Vector3>(null), ignorePolicy, new BoxedNullable<int>(null), spawnAction);
        }
    }
}
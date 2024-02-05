using System;
using BoneLib.Nullables;
using Il2CppSLZ.Marrow.Data;
using Il2CppSLZ.Marrow.Pool;
using UnityEngine;

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
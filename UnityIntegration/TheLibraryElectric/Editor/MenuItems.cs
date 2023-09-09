using UnityEngine;
using UnityEditor;
using TheLibraryElectric.Rigidbodies;

public class MenuItems : Editor
{
    [MenuItem("GameObject/The Library Electric/Gravity Chamber", false, 10)]
        static void CreateGravityChamber(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("Gravity Chamber");
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            go.AddComponent<BoxCollider>();
            go.AddComponent<GravityChamber>();
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
}

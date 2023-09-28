using UnityEngine;
using UnityEditor;
using TheLibraryElectric.Rigidbodies;
using TheLibraryElectric.PlayerUtil;
using TheLibraryElectric.Water;
using TheLibraryElectric.Signals;
using TheLibraryElectric.Misc;
using UltEvents;

public class MenuItems : Editor
{
	[MenuItem("GameObject/The Library Electric/Gravity Chamber", false, 10)]
	private static void CreateGravityChamber(MenuCommand menuCommand)
	{
		var go = new GameObject("Gravity Chamber");
		GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
		var bc = go.AddComponent<BoxCollider>();
		bc.isTrigger = true;
		go.AddComponent<GravityChamber>();
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}
	[MenuItem("GameObject/The Library Electric/Basic Water Zone", false, 10)]
	private static void CreateBasicWaterZone(MenuCommand menuCommand)
	{
		var go = new GameObject("Water Zone");
		GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
		var bc = go.AddComponent<BoxCollider>();
		bc.isTrigger = true;
		go.AddComponent<WaterZone>();
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}
		[MenuItem("GameObject/The Library Electric/Full Water Zone", false, 10)]
		private static void CreateFullWaterZone(MenuCommand menuCommand)
	{
		var go = new GameObject("Water Zone");
		GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
		var bc = go.AddComponent<BoxCollider>();
		bc.isTrigger = true;
		go.AddComponent<WaterZone>();
		go.AddComponent<SwimmingController>();
		go.AddComponent<DrowningManager>();
		go.AddComponent<SpawnOnTriggerEnter>();
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}
	[MenuItem("GameObject/The Library Electric/Ragdoll Zone", false, 10)]
	private static void CreateRagdollZone(MenuCommand menuCommand)
	{
		var go = new GameObject("Ragdoll Zone");
		GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
		var bc = go.AddComponent<BoxCollider>();
		bc.isTrigger = true;
		go.AddComponent<RagdollZone>();
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}
	[MenuItem("GameObject/The Library Electric/Signal Trigger", false, 10)]
	private static void CreateSignalTrigger(MenuCommand menuCommand)
	{
		var go = new GameObject("Signal Trigger");
		GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
		var bc = go.AddComponent<BoxCollider>();
		bc.isTrigger = true;
		go.AddComponent<SignalTrigger>();
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}
}

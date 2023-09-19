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
	static void CreateGravityChamber(MenuCommand menuCommand)
	{
		GameObject go = new GameObject("Gravity Chamber");
		GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
		BoxCollider bc = go.AddComponent<BoxCollider>();
		bc.isTrigger = true;
		go.AddComponent<GravityChamber>();
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}
	[MenuItem("GameObject/The Library Electric/Basic Water Zone", false, 10)]
	static void CreateBasicWaterZone(MenuCommand menuCommand)
	{
		GameObject go = new GameObject("Water Zone");
		GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
		BoxCollider bc = go.AddComponent<BoxCollider>();
		bc.isTrigger = true;
		go.AddComponent<WaterZone>();
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}
		[MenuItem("GameObject/The Library Electric/Full Water Zone", false, 10)]
	static void CreateFullWaterZone(MenuCommand menuCommand)
	{
		GameObject go = new GameObject("Water Zone");
		GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
		BoxCollider bc = go.AddComponent<BoxCollider>();
		bc.isTrigger = true;
		go.AddComponent<WaterZone>();
		go.AddComponent<SwimmingController>();
		go.AddComponent<DrowningManager>();
		go.AddComponent<SpawnOnTriggerEnter>();
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}
	[MenuItem("GameObject/The Library Electric/Ragdoll Zone", false, 10)]
	static void CreateRagdollZone(MenuCommand menuCommand)
	{
		GameObject go = new GameObject("Ragdoll Zone");
		GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
		BoxCollider bc = go.AddComponent<BoxCollider>();
		bc.isTrigger = true;
		go.AddComponent<RagdollZone>();
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}
	[MenuItem("GameObject/The Library Electric/Signal Trigger", false, 10)]
	static void CreateSignalTrigger(MenuCommand menuCommand)
	{
		GameObject go = new GameObject("Signal Trigger");
		GameObject child1 = new GameObject("Enter Event");
		GameObject child2 = new GameObject("Exit Event");
		child1.transform.parent = go.transform;
		child2.transform.parent = go.transform;
		UltEventHolder enterEvent = child1.AddComponent<UltEventHolder>();
		UltEventHolder exitEvent = child2.AddComponent<UltEventHolder>();
		GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
		BoxCollider bc = go.AddComponent<BoxCollider>();
		bc.isTrigger = true;
		SignalTrigger st = go.AddComponent<SignalTrigger>();
		st.triggerEnterEvent = enterEvent;
		st.triggerExitEvent = exitEvent;
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}
}

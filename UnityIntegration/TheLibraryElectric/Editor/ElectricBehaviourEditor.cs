using TheLibraryElectric;
using UnityEditor;
using UnityEngine;

namespace TheLibaryElectric 
{
    [CustomEditor(typeof(ElectricBehaviour), editorForChildClasses: true)]
    public class ElectricBehaviourEditor : Editor {
        public override void OnInspectorGUI()
        {
            var behaviour = target as ElectricBehaviour;
            if (behaviour.Comment != null) {
                EditorGUILayout.HelpBox(behaviour.Comment, MessageType.Info);
            }

            base.OnInspectorGUI();
        }
    }
}

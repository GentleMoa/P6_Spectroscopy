using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CustomEditor(typeof(LinearConveyor))]
[CanEditMultipleObjects]
public class LinearConveyorEditor : Editor {

	public override void OnInspectorGUI() {
		serializedObject.Update ();
		EditorGUI.BeginChangeCheck ();
		base.OnInspectorGUI ();
		if (EditorGUI.EndChangeCheck ()) {
			Undo.RecordObjects (targets, "Conveyor Speed Group");
			UpdateSpeed ();
		}
	} 
	// account for undo/redo in editor
	void OnEnable() {
		Undo.undoRedoPerformed += UpdateSpeed;
	}
	void OnDisable() {
		Undo.undoRedoPerformed -= UpdateSpeed;
	}

	void UpdateSpeed() {
		foreach (Object o in targets) {
			//refresh all selected objects with new speed
			LinearConveyor conv = (LinearConveyor)o;
			conv.RefreshReferences ();
			conv.ChangeSpeed (conv.speed);
		}
	}
	void OnHierarchyChange() {
		Repaint ();
	}
	void OnSelectionChange() {
		Repaint ();
	}
}

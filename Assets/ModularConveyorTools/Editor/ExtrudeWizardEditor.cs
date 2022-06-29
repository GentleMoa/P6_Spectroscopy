using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ExtrudeConveyorWizard))]
public class ExtrudeWizardEditor : Editor {
	private ExtrudeConveyorWizard wizard;
	public void OnSceneGUI() {
		wizard = this.target as ExtrudeConveyorWizard;
		// draw front of the conveyor
		Handles.color = Color.green;
		Handles.DrawWireDisc (wizard.transform.position - wizard.transform.forward * (wizard.length / 2 - wizard.radius), wizard.transform.right, wizard.radius);
		//draw the rest
		Handles.color = Color.red;
		Handles.DrawWireDisc (wizard.transform.position + wizard.transform.forward * (wizard.length / 2 - wizard.radius), wizard.transform.right, wizard.radius);
		Handles.DrawLine (wizard.transform.position - wizard.transform.forward * (wizard.length / 2 - wizard.radius) + wizard.transform.up * wizard.radius, 
			wizard.transform.position + wizard.transform.forward * (wizard.length / 2 - wizard.radius) + wizard.transform.up * wizard.radius);
		Handles.DrawLine (wizard.transform.position - wizard.transform.forward * (wizard.length / 2 - wizard.radius) - wizard.transform.up * wizard.radius, 
			wizard.transform.position + wizard.transform.forward * (wizard.length / 2 - wizard.radius) - wizard.transform.up * wizard.radius);
	}
	public override void OnInspectorGUI() {
		base.OnInspectorGUI ();

		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Generate")) {
			wizard.Generate ();
		}
		if (GUILayout.Button ("Clear")) {
			wizard.Clear ();
		}
		GUILayout.EndHorizontal ();
	}
}

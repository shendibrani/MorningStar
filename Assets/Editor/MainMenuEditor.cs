using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MainMenuHandler))]
public class TrackBuilderEditor : Editor {
	
	float startingAngle, endingAngle, radius;
	
	public override void OnInspectorGUI() {
		DrawDefaultInspector();
		
//		GUILayout.Label("Turns");
//		
//		
//		radius = EditorGUILayout.FloatField("Radius", radius);
//		GUILayout.BeginHorizontal();
//		startingAngle = EditorGUILayout.FloatField("Starting Angle", startingAngle);
//		endingAngle = EditorGUILayout.FloatField("Ending Angle", endingAngle);
//		GUILayout.EndHorizontal();
		
		if(GUILayout.Button("Align Menu")){
			(target as MainMenuHandler).Initialise();
		}
	}
}

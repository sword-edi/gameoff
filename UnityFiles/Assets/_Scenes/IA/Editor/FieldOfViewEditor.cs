using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(View))]
public class FieldOfViewEditor : Editor {

    private void OnSceneGUI(){
        View fow = (View)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.up, 360, fow.View_Radius);
        Handles.color = Color.yellow;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.View_Radius);
        Vector3 View_Angle_A = fow.DirFromAngle(-fow.View_Angle / 2, false);
        Vector3 View_Angle_B = fow.DirFromAngle(fow.View_Angle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + View_Angle_A * fow.View_Radius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + View_Angle_B * fow.View_Radius);

        Handles.color = Color.red;
        foreach (Transform Visible_Target in fow.Visible_Targets){
            Handles.DrawLine(fow.transform.position, Visible_Target.position);
        }
    }
}

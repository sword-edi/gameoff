using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDetection : MonoBehaviour {

    public LayerMask Target_Mask;

    public List<Transform> Visible_Targets = new List<Transform>();
    

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", 0.2f);
    }
    

    IEnumerator FindTargetsWithDelay(float Delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            FindVisibleTarget();
        }
    }

    void FindVisibleTarget()
    {
        Visible_Targets.Clear();
        Vector3 size = transform.TransformVector(transform.localScale / 2);
        Collider[] Target_In_View_Radius = Physics.OverlapBox(transform.position, transform.localScale / 2, transform.localRotation, Target_Mask);

        for (int i = 0; i < Target_In_View_Radius.Length; i++)
        {
            Transform Target = Target_In_View_Radius[i].transform;
            Visible_Targets.Add(Target);
        }
    }
    
}

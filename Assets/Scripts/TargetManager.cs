using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

    private RaycastHit hit;
    private Ray ray;

    private float rayRange = 200.0f;
    private int layerMask = 1;

	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, rayRange, layerMask))
        {
            transform.position = hit.point;
        }
    }
}

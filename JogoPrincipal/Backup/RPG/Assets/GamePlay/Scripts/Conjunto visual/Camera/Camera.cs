using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public Transform pt, ct;
	
	// Update is called once per frame
	void Update () {
        ct.position = Vector3.Lerp(ct.position, new Vector3(pt.position.x, pt.position.y, ct.position.z), 1f);
	}
}

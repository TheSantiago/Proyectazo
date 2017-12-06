using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour {

    public GameObject Player;
    public Vector3 offset;
	void Start ()
    {
 
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = new Vector3 (Player.transform.position.x + offset.x,-1,-10);
	}
}

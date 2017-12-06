using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private PlayerMovement Player;

    void Start()
    {
        Player = gameObject.GetComponentInParent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.grounded = true;
    }



    void OnTriggerExit2D(Collider2D collision)
    {
        Player.grounded = false;
    }
}

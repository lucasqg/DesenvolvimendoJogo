using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaDeMapa : MonoBehaviour {
    public Transform player;
    public Quaternion player2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Player")
        {
            player.SetPositionAndRotation(new Vector3(-22.88f, -5.65f, -0.28f), player2);
        }
    }
}

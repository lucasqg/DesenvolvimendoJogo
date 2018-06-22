using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaDeMapa : MonoBehaviour {
    public Transform player;
    public Quaternion player2;
    public float x, y, z;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLocation( )    {

        player.SetPositionAndRotation(new Vector3(x, y, z), player2);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Player")
        {
            SetLocation();
        }
    }
}

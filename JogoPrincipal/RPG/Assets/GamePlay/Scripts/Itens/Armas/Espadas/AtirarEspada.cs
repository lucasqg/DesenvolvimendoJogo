using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarEspada : MonoBehaviour {
    private float timer = 0f;
    public int X, Y;
    private float vel = 5f;
    public bool alone;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!alone)
        {
            if (X == 0)
            {
                transform.Translate(new Vector2(0, Y * vel * Time.deltaTime));
                transform.Rotate(new Vector3(0, 0, -800 * Time.deltaTime));
            }
            if (Y == 0)
            {
                transform.Translate(new Vector2(X * vel * Time.deltaTime, 0));
                transform.Rotate(new Vector3(0, 0, -800 * Time.deltaTime));

            }
            if (timer > 5f)
                Destroy(this.gameObject);
            else
                timer = timer + Time.deltaTime;
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -800 * Time.deltaTime));
            if (timer > 3f)
                Destroy(this.gameObject);
            else
                timer = timer + Time.deltaTime;
        }
    }

}

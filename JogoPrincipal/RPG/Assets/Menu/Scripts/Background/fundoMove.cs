using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fundoMove : MonoBehaviour {

    public Renderer quad;

    private void Start()
    {
        
    }

    void Update () {

        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        if (transform.position.x < 1 && transform.position.x > -0.8 && transform.position.y < 1 && transform.position.y > -0.3)
        {
            transform.Translate(new Vector2(h * Time.deltaTime, v * Time.deltaTime));
        }
        else if(transform.position.x > 1)
        {
            transform.Translate(new Vector2(-1* Time.deltaTime, 0));
        }
        else if (transform.position.x < -0.8)
        {
            transform.Translate(new Vector2(1 * Time.deltaTime, 0));
        }
        else if (transform.position.y > 1)
        {
            transform.Translate(new Vector2(0, -1 * Time.deltaTime));
        }
        else if (transform.position.y < -0.3)
        {
            transform.Translate(new Vector2(0, 1 * Time.deltaTime));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirExplosion : MonoBehaviour {
   private float timer = 0f;

    // Use this for initialization

    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (timer > 0.3f)
            Destroy(this.gameObject);
        else
            timer = timer + Time.deltaTime;
    }

}

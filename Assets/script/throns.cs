﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throns : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.transform.tag == "Player")
        {
            //print("collide");
            collision.transform.GetComponent<Antmovement>().die(0);
        }
        
    }
}

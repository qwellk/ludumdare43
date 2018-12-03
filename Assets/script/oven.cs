using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oven : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //print("collide");
            collision.transform.GetComponent<Antmovement>().burn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //print("collide");
            collision.transform.GetComponent<Antmovement>().putoutfire();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nest : MonoBehaviour {

    public GameObject gm;
    public int nestcapacity;
    public bool isactive = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isactive)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                gm.GetComponent<gamemanage>().restart(nestcapacity);
            }
        }
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject[] nests = GameObject.FindGameObjectsWithTag("nest");
        foreach(GameObject x in nests)
        {
            if (x != this)
            {
                x.GetComponent<nest>().isactive = false;
            }
        }
        this.isactive = true;
        gm.GetComponent<gamemanage>().setsavepoint(this.transform.position);
        if (collision.transform.tag == "Player")
        {
            if(collision.transform.GetComponent<Antmovement>().iscentreobj)
            {
                //print("collide");
                this.GetComponent<Animator>().SetTrigger("light");
            }
        }
    }
}

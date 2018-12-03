using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgame : MonoBehaviour {

    public GameObject welldone;
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
            if (collision.transform.GetComponent<Antmovement>().iscentreobj)
            {
                Time.timeScale = 0.2f;
                welldone.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (collision.transform.GetComponent<Antmovement>().iscentreobj)
            {
                Time.timeScale = 1f;
            }
        }
    }
}

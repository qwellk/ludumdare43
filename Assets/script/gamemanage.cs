using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanage : MonoBehaviour {

    public GameObject ant;
    private Vector3 savepoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setsavepoint(Vector3 i)
    {
        savepoint = i;
    }

    public void restart(int y)
    {
        GameObject[] ants = GameObject.FindGameObjectsWithTag("Player");
        int x = 0;
        int i = 0;
        for(x = 0; x<ants.Length;x++)
        {
            //print("i:"+i);
            //print("y:" + y);
            if (ants[x].GetComponent<Antmovement>().iscentreobj)
            {
                ants[x].GetComponent<Antmovement>().resetposition(savepoint);
                continue;
            }
            if (i < y)
            {
                if (ants[x].GetComponent<Antmovement>().resetposition(savepoint)) i++;
            }
            else
            {
                ants[x].GetComponent<Antmovement>().die(0);
            }
        }
        for(; i<y;i++ )
        {
            Instantiate(ant, savepoint, new Quaternion(0, 0, 0, 0));
        }
        
    }
}

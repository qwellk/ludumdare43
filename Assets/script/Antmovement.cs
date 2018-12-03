using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antmovement : MonoBehaviour {

    public bool iscentreobj = false;
    public GameObject centreobj = null;
    public float centreforce = 0;
    public float maxforce = 10;
    public float maxmovedis = 2;
    public float moveforce = 0.4f;
    public float jumpspeed = 5f;

    private bool alive = true;
    private bool onfire = false;
    private float burntime;
    private float burningtime = 0;
	// Use this for initialization
	void Start () {
        burntime = Random.Range(2.0f, 10.0f);
        centreobj = GameObject.Find("centreant");
	}
	
	// Update is called once per frame
	void Update () {
        if(alive)
        {
            if(iscentreobj)
            {
                return;
            }
            //automove to centre obj
            if (centreobj != null)
            {
                Vector2 dir2centre = centreobj.transform.position - this.transform.position;
                Vector2 dirfoce = dir2centre * centreforce;
                if (Mathf.Sqrt(dirfoce.x * dirfoce.x + dirfoce.y * dirfoce.y) > maxforce) dirfoce = dir2centre.normalized * maxforce;
                this.GetComponent<Rigidbody2D>().AddForce(dirfoce);
            }
            //movement when on fire
            if(onfire)
            {
                if (burningtime > burntime)
                {
                    die(1);
                }
                burningtime += Time.deltaTime;
                this.GetComponent<Rigidbody2D>().velocity += new Vector2(0, moveforce);
            }
            //move when prees key
            if (Input.GetKey(KeyCode.D))
            {
                Vector2 dir2this = this.transform.position - centreobj.transform.position;
                if (Mathf.Sqrt(dir2this.x * dir2this.x + dir2this.y * dir2this.y) > maxmovedis)
                {

                }
                else
                {
                    if(dir2this.x<0 || dir2this.y>0)
                    {
                        Vector2 movedir = new Vector2(dir2this.y, -dir2this.x);//顺时针旋转90
                        this.GetComponent<Rigidbody2D>().velocity += movedir * moveforce;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Vector2 dir2this = this.transform.position - centreobj.transform.position;
                if (Mathf.Sqrt(dir2this.x * dir2this.x + dir2this.y * dir2this.y) > maxmovedis)
                {

                }
                else
                {
                    if (dir2this.x > 0 || dir2this.y > 0)
                    {
                        Vector2 movedir = new Vector2(-dir2this.y, dir2this.x);//逆时针旋转90
                        this.GetComponent<Rigidbody2D>().velocity += movedir * moveforce;
                    }
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                Vector2 dir2this = this.transform.position - centreobj.transform.position;
                if (Mathf.Sqrt(dir2this.x * dir2this.x + dir2this.y * dir2this.y) > maxmovedis)
                {

                }
                else
                {
                    float x = (dir2this.y * dir2this.x) > 0 ? 1 : -1;
                    Vector2 movedir = new Vector2(x*Mathf.Abs(dir2this.y), -Mathf.Abs(dir2this.x));//顺时针旋转90
                    this.GetComponent<Rigidbody2D>().velocity += movedir * moveforce ;
                    
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Vector2 dir2this = this.transform.position - centreobj.transform.position;
                if (Mathf.Sqrt(dir2this.x * dir2this.x + dir2this.y * dir2this.y) > maxmovedis)
                {

                }
                else
                {
                    float x = (dir2this.y * dir2this.x) > 0 ? 1 : -1;
                    Vector2 movedir = new Vector2(x * Mathf.Abs(dir2this.y), -Mathf.Abs(dir2this.x));//顺时针旋转90
                    this.GetComponent<Rigidbody2D>().velocity += movedir * jumpspeed;

                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                RaycastHit2D hit = Physics2D.Raycast(this.transform.position, new Vector2(0, -1), this.GetComponent<Collider2D>().bounds.size.y+0.1f, 1<<8);//发射射线判断是否在地上
                if(hit)
                {
                    this.GetComponent<Rigidbody2D>().velocity += new Vector2(0, jumpspeed);
                }
            }

        }
        else
        {
            if (this.GetComponent<Rigidbody2D>().mass != 0.1f) this.GetComponent<Rigidbody2D>().mass = 0.1f;

        }
	}

    public void die(int x)
    {
        if(alive)
        {
            if (x == 0)//kill by throns
            {
                if (!iscentreobj)
                {
                    this.GetComponent<Animator>().SetTrigger("dead");
                    alive = false;
                    
                }
            }
            else if (x == 1)//kill by fire
            {
                if(!iscentreobj)
                {
                    this.GetComponent<Animator>().SetTrigger("dead1");
                    alive = false;
                }
            }
        }
    }

    public void burn()
    {
        if(alive)
        {
            if(!iscentreobj)
            {
                this.GetComponent<Animator>().SetTrigger("burn");
                this.GetComponent<Animator>().SetFloat("burningspeed", 2 / burntime);
                onfire = true;
            }
        }
    }

    public void putoutfire()
    {
        if(alive)
        {
            if(!iscentreobj)
            {
                this.GetComponent<Animator>().SetFloat("burningspeed", -2 / burntime);
                this.GetComponent<Animator>().SetBool("putoutfire", true);
                onfire = false;
            }
        }
    }

    public bool resetposition(Vector3 newpos)
    {
        if(alive)
        {
            this.transform.position = newpos;
            return true;
        }
        return false;
    }
}

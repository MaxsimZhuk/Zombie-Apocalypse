using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZombie : MonoBehaviour {
    public GameObject Body;
    private int i=100;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
	    if (i < 0)
	    {
           
            GameObject myArrov = Instantiate(Body, transform.position, transform.rotation);
            i = 10000;
            

        }
	    else
	    {
	        i--;
	    }

    }
}

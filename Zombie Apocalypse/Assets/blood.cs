﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour {
    public GameObject oldblood;
    private int Health=50;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Health < 0)
        {
            //GameObject myArrov = Instantiate(oldblood, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else Health--;


    }
}

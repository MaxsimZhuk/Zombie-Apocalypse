﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public Transform EndPoint;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
	    transform.position = Vector3.MoveTowards( transform.position, EndPoint.position,Time.deltaTime );
	}
}

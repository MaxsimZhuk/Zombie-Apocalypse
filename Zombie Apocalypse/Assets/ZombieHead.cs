using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHead : MonoBehaviour {
    public GameObject blood;
    public GameObject body;
    private int Health=100;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!body.transform.position.x.Equals(gameObject.transform.position.x))
        {
            if (Health > 0)
            {
                GameObject testGameObject = new GameObject();
                testGameObject.transform.position = transform.position;
                testGameObject.transform.position += transform.up*(float) -0.1;
                GameObject myArrov = Instantiate(blood, testGameObject.transform.position, transform.rotation);
                Health--;
            }
        }
        Debug.Log(gameObject.transform.position.x);
	}
}

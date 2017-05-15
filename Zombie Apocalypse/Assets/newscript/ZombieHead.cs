using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHead : MonoBehaviour
{
    
    public GameObject Blood;

    private int _health=100;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
      
            if (_health > 0)
            {
                GameObject testGameObject = new GameObject();
                testGameObject.transform.position = transform.position;
                testGameObject.transform.position += transform.up*(float) -0.1;
                GameObject myArrov = Instantiate(Blood, testGameObject.transform.position, transform.rotation);
                _health--;
                Destroy(testGameObject);
                
            }
         
        
         
        
   
    }
}

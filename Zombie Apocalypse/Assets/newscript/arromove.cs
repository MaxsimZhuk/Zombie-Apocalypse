using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arromove : MonoBehaviour {
    

    public int Arrowspeed;
    private int ArrowHealth;
    // Use this for initialization
    void Start ()
    {
        ArrowHealth = 180;
        Quaternion rotatenionX = Quaternion.AngleAxis(90, Vector3.right);
        transform.rotation *=  rotatenionX;
        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (Arrowspeed > 1) Arrowspeed--;
        ArrowHealth--;
        if(ArrowHealth<1)Destroy(gameObject);
        transform.position += transform.up * Arrowspeed* Time.deltaTime;
        Quaternion rotatenionX = Quaternion.AngleAxis(1, Vector3.right);
        transform.rotation *= rotatenionX; 
    }
}

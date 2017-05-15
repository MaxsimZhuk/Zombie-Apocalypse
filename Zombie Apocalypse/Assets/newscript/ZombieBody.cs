using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBody : MonoBehaviour
{
    public GameObject RespamPoint;
    public GameObject HeadDead;
    public GameObject Player;
    public GameObject Blood;
    public GameObject Head;
    private GameObject myHead;
    private Vector3 Player_Lerb;
    private int _health;
    private bool alive;
    // Use this for initialization
    void Start () {
        myHead = Instantiate(Head, transform.position, transform.rotation);
        alive = false;
        _health = 300;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        
        if (alive)
	    {
	        if (_health > 0)
	        {
	            GameObject testGameObject = new GameObject();
	            testGameObject.transform.position = transform.position;
	            testGameObject.transform.position += transform.up*(float) 0.5;
	            GameObject myArrov = Instantiate(Blood, testGameObject.transform.position, transform.rotation);
	            _health--;
	            Destroy(testGameObject);
	        }
	        if (_health == 0)
	        {
	            RespamPoint.transform.position -= RespamPoint.transform.right*10;

                transform.position = RespamPoint.transform.position;

                Start();
            }

        }
	    else
	    {
	        if (!myHead.transform.position.x.Equals(gameObject.transform.position.x))
	        {
	            Destroy(myHead);
	            HeadDead = Instantiate(HeadDead, myHead.transform.position, myHead.transform.rotation);
	            alive = true;

	        }
	        else
	        {
	            Player_Lerb = Vector3.Lerp(Player_Lerb, Player.transform.position, Time.deltaTime * (float)0.7);
                transform.LookAt(Player_Lerb);
                Quaternion rotatenion = Quaternion.AngleAxis(90, Vector3.up);
                transform.rotation *= rotatenion;
                transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
                transform.position -= transform.right * 5 * Time.deltaTime;

                myHead.transform.position = transform.position;
	            myHead.transform.position += transform.up*(float) 0.7;
	        }
	    }


    }
}

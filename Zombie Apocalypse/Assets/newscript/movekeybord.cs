using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movekeybord : MonoBehaviour
{
    public Texture2D Pricel;

    public GameObject Arrov;

    private Quaternion originRotatenion;

    private CharacterController characterController;

    private float angle;

    private float mouseX;
    private float mouseY;

    private GameObject player; //Переменна объекта персонажа с которым будем работать. 
    public int speed; //Скорость перемещения персонажа. Запись public static обозначает что мы сможем обращаться к этой переменной из любого скрипта 
    private int playerspeed ;
    // Настройка скорости
    //   public float SpeedGravity;

    // Гравитация
    public float Gravity;

    public float jump;
    public int acceleration;

    // Ссылка на Character Controller


    // Вектор перемещение
    private Vector3 vMotion;
    // Use this for initialization
    void Start ()
    {
        player = (GameObject)this.gameObject;
        // Запоминаем ссылку на Character Controller
        characterController = GetComponent<CharacterController>();
        playerspeed = speed;
        // Изначально вектор перемещения равен нулю
        vMotion = Vector3.zero;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    mouseX = 0;
	    mouseY = 0;
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");
        Quaternion rotatenionY = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion rotatenionX = Quaternion.AngleAxis(mouseY, Vector3.left);
	 
        transform.rotation *= rotatenionY*rotatenionX;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        Cursor.lockState = CursorLockMode.Locked;


        if (Input.GetKey(KeyCode.W)) //Если нажать W 
        {
            player.transform.position += player.transform.forward * playerspeed * Time.deltaTime; //Перемещаем персонажа в перед, с заданой скорость. Time.deltaTime ставится для плавного перемещения персонажа, если этого не будет он будет двигаться рывками 
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position -= player.transform.forward * playerspeed * Time.deltaTime; //Перемещаем назад 
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position -= player.transform.right * playerspeed * Time.deltaTime; //перемещаем в лево 
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += player.transform.right * playerspeed * Time.deltaTime; //перемещаем в право 
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.transform.position += player.transform.up * jump  * Time.deltaTime;  
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerspeed = speed ;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerspeed = speed + acceleration;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            GameObject testGameObject = new GameObject();
            testGameObject.transform.position = transform.position;
            testGameObject.transform.position += transform.forward * 1;
            GameObject myArrov = Instantiate(Arrov, testGameObject.transform.position, transform.rotation );
            Destroy(testGameObject);
            
        }




	    // Тут имитируем гравитацию, добавляя перемещение по вертикальной оси вниз
        vMotion.y =  Gravity;

        // А теперь перемещаем персонажа на рассчитанный вектор
        characterController.Move(vMotion);
    }
    public void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2-20, Screen.height / 2-20, 40, 40), Pricel);
    }
}

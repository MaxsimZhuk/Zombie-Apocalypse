using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float red = Random.Range(.0f, 1.0f);
        float green = Random.Range(.0f, 1.0f);
        float blue = Random.Range(.0f, 1.0f);

        Color color = new Color(red, green, blue);

        gameObject.GetComponent<Renderer>().material.color = color;

        Vector3 pointA = eventData.pointerPressRaycast.worldPosition;
        Vector3 pointB = Camera.main.transform.position;

        Vector3 direction = pointA - pointB;

        direction = direction.normalized;

        Vector3 force = direction * 700;
        Vector3 target = eventData.pointerPressRaycast.worldPosition;

        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(force, target);
    }
}

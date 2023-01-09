using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float speed = 0.7f;
    
    private Camera mainCamera;
    private Vector3 mousePos;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        
    }

    private void MoveToMouse()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);

        if (Input.GetMouseButton(0))
        {
            transform.position = Vector3.Lerp(transform.position, mousePos, Time.deltaTime * speed);
        }
    }
}

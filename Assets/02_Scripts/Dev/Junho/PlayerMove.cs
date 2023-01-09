using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Player Status")]
    public float defalutSpeed = 9f;
    public float dashSpeed;
    public float speed = 9f;

    public float _dashDelay;

    [SerializeField] private bool _isDash = false; 

    private Camera mainCamera;
    private Vector3 mousePos;
    private BoxCollider2D bxCol;

    private void Awake()
    {
        mainCamera = Camera.main;
        bxCol = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        speed = defalutSpeed;
    }

    private void Update()
    {
        MoveToMouse();
        if (Input.GetKeyDown(KeyCode.LeftShift) && !_isDash)
        {
            StartCoroutine(DashDelay());
        }
    }

    private void MoveToMouse()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);

        
        if (Input.GetMouseButton(0))
        {
            transform.position = Vector3.MoveTowards(transform.position, mousePos, Time.deltaTime * speed);
        }
    }

    IEnumerator DashDelay()
    {
        speed = dashSpeed;
        _isDash = true;
        bxCol.enabled = false;

        transform.position = Vector3.MoveTowards(transform.position, mousePos, Time.deltaTime * speed);
        bxCol.enabled = true;
        speed = defalutSpeed;
        yield return new WaitForSeconds(_dashDelay);
        _isDash = false;
    }
}

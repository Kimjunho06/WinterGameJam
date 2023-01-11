using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Player Status")]
    public float defalutSpeed = 9f;
    public float dashSpeed;
    private float speed = 9f;

    public float _dashDelay;

    [SerializeField] private bool _isDash = false;
    [SerializeField] GameObject moveParticle;
    [SerializeField] GameObject dashParticle;

    private Camera mainCamera;
    private Vector3 mousePos;
    private BoxCollider2D bxCol;

    public bool _isMoveLimit = false;

    public bool cantMove = false;

    [SerializeField] GameObject OptionPanel;

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
        if (cantMove)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionPanel.SetActive(true);

        }

        MoveToMouse();
        if (!_isMoveLimit)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -26, 26), Mathf.Clamp(transform.position.y, -14.5f, 14.5f));
        }
        else
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -26, 26), Mathf.Clamp(transform.position.y, -13.3f, 9f));
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_isDash)
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
            ParticleSystem particleSystem = PoolManager.Instance.Pop(moveParticle, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            if (transform.GetComponent<SpriteRenderer>().color == Color.black)
            {
                particleSystem.startColor = new Color(0.16f,0.16f,0.15f,1);
            }
            else
            {
                particleSystem.startColor = transform.GetComponent<SpriteRenderer>().color;
            }
        }
    }

    IEnumerator DashDelay()
    {
        speed = dashSpeed;
        _isDash = true;
        bxCol.enabled = false;
        SpriteRenderer spriteRenderer = PoolManager.Instance.Pop(dashParticle, transform.position, Quaternion.identity).GetComponent<SpriteRenderer>();
        if (transform.GetComponent<SpriteRenderer>().color == Color.black)
        {
            spriteRenderer.color = new Color(0.16f,0.16f,0.15f,1);
        }
        else
        {
            spriteRenderer.color = transform.GetComponent<SpriteRenderer>().color;
        }

        transform.position = Vector3.MoveTowards(transform.position, mousePos, Time.deltaTime * speed);
        bxCol.enabled = true;
        speed = defalutSpeed;
        yield return new WaitForSeconds(_dashDelay);
        _isDash = false;
    }
}

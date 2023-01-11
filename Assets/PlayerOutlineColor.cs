using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutlineColor : MonoBehaviour
{
    [SerializeField] GameObject parent;
    SpriteRenderer spriteRenderer;
    
    private bool checkOne;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(checkOne)
            ChangeColor();
    }

    private void ChangeColor()
    {
        if(parent.GetComponent<SpriteRenderer>().color == spriteRenderer.color)
            spriteRenderer.color = Color.white;
        else
            spriteRenderer.color = Color.black;
    }
}

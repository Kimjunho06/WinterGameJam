using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] float speed = 0.7f;
    float r = 0f;
    void Update()
    {
        r += speed;
        transform.rotation = Quaternion.Euler(0,0,r);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody2D ball;
    [HideInInspector]public bool hasStarted;
    private Vector2 direction = Vector2.up;
    public float impactForce;
    public float jumpForce;

    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject obj = other.gameObject;
        Debug.Log(obj.name);
        Vector2 location = other.gameObject.transform.position;
        if (other.gameObject.CompareTag("Brick"))
        {
            gameManager.Breakable(location,obj);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hasStarted is "+hasStarted);
            if (hasStarted)
            {
                Impact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            gameManager.GameOver();
        } 
    }

    public void Push()
    {
            ball.AddForce(direction * jumpForce, ForceMode2D.Impulse);
            hasStarted = true;
            gameManager.KeyPressed();
    }

    public void Impact()
    {
        ball.AddForce(direction * impactForce, ForceMode2D.Impulse);  
    }
}

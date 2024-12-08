using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{ 
    public Ball ball;
   private PlayerInput playerInput;
   [HideInInspector] public InputAction jumpAction;
   private Rigidbody2D paddle;
   public float moveSpeed;
   private bool isBallOn;
   private bool isDrag;

   void Awake()
   {
       playerInput = GetComponent<PlayerInput>();
       paddle = GetComponent<Rigidbody2D>();
   }

   void OnEnable()
   {
       jumpAction.Enable();
   }
   
   void Update()
   {
       if (jumpAction.triggered)
       {
           if (!isBallOn)
           {
               ball.Push();
               isBallOn = true;
           }
       }
   }
   
   void OnMove(InputValue value)
   {
       Vector2 direction = value.Get<Vector2>();
       paddle.velocity = direction * moveSpeed;
   }
   

   
}

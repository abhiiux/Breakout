using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class TouchMove : MonoBehaviour
{
    public Transform paddle;
    public float paddleSpeed = 10f;

    private Camera mainCamera;
    private int paddleTouchID = -1;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            Vector3 touchPosition = GetTouchWorldPosition(touch.position);

            // Handle Touch Phases
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    paddleTouchID = touch.fingerId;
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (touch.fingerId == paddleTouchID)
                    {
                        MovePaddle(paddle, touchPosition);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (touch.fingerId == paddleTouchID)
                    {
                        paddleTouchID = -1;
                    }
                    break;
            }
        }
    }

    Vector3 GetTouchWorldPosition(Vector2 screenPosition)
    {
        Vector3 touchPosScreen = new Vector3(screenPosition.x, screenPosition.y, Mathf.Abs(mainCamera.transform.position.z));
        return mainCamera.ScreenToWorldPoint(touchPosScreen);
    }

    void MovePaddle(Transform paddle, Vector3 touchPosition)
    {
        // Restrict movement to X-axis
        Vector3 newPosition = paddle.position;
        newPosition.x = Mathf.Lerp(paddle.position.x, touchPosition.x, Time.deltaTime * paddleSpeed);
        paddle.position = newPosition;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    public Transform spawnPoint; //position to spawn Ball.
    public GameObject Ball;
    public Ball ballScript;
    public GameObject gameOverImage;
    public GameObject playAgain;
    public Text Key;
    public GameObject red;
    public GameObject blue;
    public GameObject green;
    public GameObject lightBrown;
    public GameObject darkBrown;
    public void Breakable(Vector2 location,GameObject obj)
    {
        switch (obj.name)
        {
            case "Blue":
                Destroy(obj);
                Instantiate(blue, location, Quaternion.identity);
                break;
            case "Green":
                Destroy(obj);
                Instantiate(green, location, Quaternion.identity);
                break;
            case "LB":
                Destroy(obj);
                Instantiate(lightBrown, location, Quaternion.identity);
                break;
            case "DB":
                Destroy(obj);
                Instantiate(darkBrown, location, Quaternion.identity);
                break;
            case "Red":
                Destroy(obj);
                Instantiate(red, location, Quaternion.identity);
                break;
            default:
                Debug.Log(obj.name);
                break;
        }
    }

    public void KeyPressed()
    {
        Key.enabled = false;
    }

    public void GameOver()
    {
        gameOverImage.SetActive(true);
        playAgain.SetActive(true);
    }

    public void PlayAgain()
    {
        Vector2 spawnPos = spawnPoint.position;
        if (Ball != null)
        {
            Instantiate(Ball,spawnPos,Quaternion.identity);
            ballScript.hasStarted = true;
        }
        else
        {
            Debug.Log("Ball is null");
        }
        gameOverImage.SetActive(false);
        playAgain.SetActive(false);
    }
}

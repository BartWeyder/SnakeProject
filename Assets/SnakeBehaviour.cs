using Assets.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour {

    Snake snake;
    bool isGameActive = false;
    // Use this for initialization
    void Start () {
        snake = new Snake();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                snake.TurnLeft();
            if (Input.GetKeyDown(KeyCode.RightArrow))
                snake.TurnRight();
            if (Input.GetKeyDown(KeyCode.DownArrow))
                snake.TurnDown();
            if (Input.GetKeyDown(KeyCode.UpArrow))
                snake.TurnUp();
            if (Input.GetKeyDown(KeyCode.Space))
                isGameActive = true;
            if (Input.GetKeyDown(KeyCode.Escape))
                isGameActive = false;

        }
        
        else
        {
            if(isGameActive)
                snake.Move();
        }

        
    }
}

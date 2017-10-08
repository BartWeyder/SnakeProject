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
        InvokeRepeating("SnakeMove", 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            snake.TurnLeft();
            CancelInvoke("SnakeMove");
            InvokeRepeating("SnakeMove", 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            snake.TurnRight();
            CancelInvoke("SnakeMove");
            InvokeRepeating("SnakeMove", 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            snake.TurnDown();
            CancelInvoke("SnakeMove");
            InvokeRepeating("SnakeMove", 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            snake.TurnUp();
            CancelInvoke("SnakeMove");
            InvokeRepeating("SnakeMove", 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            isGameActive = true;
        if (Input.GetKeyDown(KeyCode.Escape))
            isGameActive = false;
    }

    void SnakeMove()
    {
        if(isGameActive)
        {
            snake.Move();
        }
    }
}

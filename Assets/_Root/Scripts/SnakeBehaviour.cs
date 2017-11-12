/*using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeBehaviour : MonoBehaviour {
    [SerializeField, Range(0.3f, 5f)]
    private float speed = 1f;
    
    Snake snake;
    Game game;
    public int Score { get { return snake.BodyParts.Count; } }
    // Use this for initialization
    void Start () {
        game = new Game();
        game.DoLogic();
        snake = new Snake();
        InvokeRepeating("SnakeMove", 0, 1/speed);

    }

    // Update is called once per frame
    void Update () {
        if (!snake.IsDead)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                snake.TurnLeft();
                CancelInvoke("SnakeMove");
                InvokeRepeating("SnakeMove", 1 / speed, 1 / speed);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                snake.TurnRight();
                CancelInvoke("SnakeMove");
                InvokeRepeating("SnakeMove", 1 / speed, 1 / speed);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                snake.TurnDown();
                CancelInvoke("SnakeMove");
                InvokeRepeating("SnakeMove", 1 / speed, 1 / speed);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                snake.TurnUp();
                CancelInvoke("SnakeMove");
                InvokeRepeating("SnakeMove", 1 / speed, 1 / speed);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                snake.IsMoving = true;
                GameObject gameOver = GameObject.Find("GameOver");
                gameOver.GetComponent<Text>().text = "";
            }
            if (Input.GetKeyDown(KeyCode.Escape))
                snake.IsMoving = false;
        }
    }

    void SnakeMove()
    {
        if(snake.IsMoving)
            snake.Move();
        else if (snake.IsDead)
        {

            GameObject gameOver = GameObject.Find("GameOver");
            GameObject score = GameObject.Find("Score");
            gameOver.GetComponent<Text>().text = "Game Over!";
            if (Score > 3)
                score.GetComponent<Text>().text = $"Score: {Score * 10}";
            else
                score.GetComponent<Text>().text = $"Score: 0";
        }
    }
}
*/
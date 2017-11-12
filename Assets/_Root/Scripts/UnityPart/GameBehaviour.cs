using Assets._Root.Scripts.Render;
using Assets._Root.Scripts.Strange.Context;
using Assets.Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour {
    Game game;
    bool isGameStarted = false;
    DrawPart draw;
    // Use this for initialization
    void Start () {
        //GameContext gameContext = new GameContext();
        game = new Game();
        draw = new DrawPart();
        Draw();
        InvokeRepeating("CallMove", 1, game.Velocity);

    }

    // Update is called once per frame
    void Update () {
		if(!isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGameStarted = true;
                InvokeRepeating("CallMove", 1, game.Velocity);
            }
        }
        else
        {
            
            float xAxis = Input.GetAxis("Horizontal");
            float yAxix = Input.GetAxis("Vertical");
            if (Math.Abs(xAxis) > Math.Abs(yAxix))
            {
                CancelInvoke("CallMove");
                game.MakeMove(xAxis);
                InvokeRepeating("CallMove", game.Velocity, game.Velocity);
            }
            else
            {
                CancelInvoke("CallMove");
                game.MakeMove(yAxix, false);
                InvokeRepeating("CallMove", game.Velocity, game.Velocity);
            }
        }
	}

    void CallMove()
    {
        game.MakeMove();
        Draw();
    }

    void Draw()
    {
        draw.Draw(game.Snake.snakeParts);
        draw.Draw(game.apples);
        draw.Draw(game.bonuses);
    }
}

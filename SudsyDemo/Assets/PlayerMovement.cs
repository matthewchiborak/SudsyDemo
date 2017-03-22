using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets;

public class PlayerMovement : MonoBehaviour
{

    GameBoard gb;

    // Use this for initialization
    void Start()
    {
        gb = gameObject.AddComponent<GameBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow) )
        {
            print("w key was pressed");
            gb.doGameEvent(new PlayerMoveEventUp());
        }
        else if (Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            print("a key was pressed");
            gb.doGameEvent(new PlayerMoveEventLeft());
        }

        else if (Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow))
        {
            print("s key was pressed");
            gb.doGameEvent(new PlayerMoveEventDown());
        }

        else if (Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow))
        {
            print("d key was pressed");
            gb.doGameEvent(new PlayerMoveEventRight());
        }

    }

}

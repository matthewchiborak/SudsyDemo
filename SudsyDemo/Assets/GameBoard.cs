using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class GameBoard : MonoBehaviour {

    public int width = 6;
    public int height = 6;




    public ActorPlayer player = new ActorPlayer();


    public List<List<Tile>> board = new List<List<Tile>>();

  

    //Deafult constructor, private as it is a singleton class
    public GameBoard()
    {
        this.Start();
    }

    // Use this for initialization
    void Start () {

        //Initialize the board
        for (int i = 0; i < height; i++)
        {
            List<Tile> row = new List<Tile>(width);            

            for(int j = 0; j < width; j++)
            {
                row.Add(new Tile(i, j));
            }

            board.Add(row);

        }

        //Add the player for testing purposes.
        board[2][2] = new Block(2,2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void doGameEvent(GameBoardEvent ev)
    {
        bool res = ev.doEvent(this);
        print(res);
        printPlayerPos();
    }

    private void printPlayerPos()
    {
        print("Player Position: (" + player.row + ", " + player.col + ")");
    }
}

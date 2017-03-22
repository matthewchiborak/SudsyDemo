using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

//Later probably save deep copy of player object for items etc
public class MoveHistory
{
    public int row, col;
    public Tile tile;

    public MoveHistory(int row, int col, Tile t)
    {
        this.row = row;
        this.col = col;
        tile = t;
    }
}

public class GameBoard : MonoBehaviour {

    public int width = 6;
    public int height = 6;

    Stack<MoveHistory> history;


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
                Tile tile = TileFactoryMethods.TileFactory(TileType.Dirty);
                tile.setPos(i, j);
                row.Add(tile);
            }

            board.Add(row);

        }

        //Add the player for testing purposes.
        Tile t = TileFactoryMethods.TileFactory(TileType.Block);
        t.setPos(2, 2);
        board[2][2] = t;

        player.currentTile = board[0][0];

        //Initialize the History stack

        history = new Stack<MoveHistory>();
        
	}
	
    public void addHistory(int x, int y, Tile t)
    {
        MoveHistory h = new MoveHistory(x, y, t);
        history.Push(h);
    }

    public MoveHistory getHistory()
    {
        if (history.Count == 0) return null;
        return history.Pop();
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

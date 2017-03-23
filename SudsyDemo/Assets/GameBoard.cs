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

    public Transform mudOverlay;

    public ActorPlayer player = new ActorPlayer();


    public List<List<Tile>> board = new List<List<Tile>>();
    private List<List<Transform>> boardObj = new List<List<Transform>>();


    //Deafult constructor, private as it is a singleton class
    public GameBoard()
    {

        
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

        //Draw screen

        
            for (int col = width - 1; col >= 0; col--)
            {
                List<Transform> objRow = new List<Transform>();

            for (int row = 0; row < height; row++)
            {
                Transform obj = Instantiate(mudOverlay, new Vector3(row, col, 0), Quaternion.identity);
                objRow.Add(obj);

            }
            boardObj.Add(objRow);

        }
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
	void Update ()
    {
	
        for(int row = 0; row < height; row++)
        {
            for(int col = 0; col < width; col++)
            {

                bool muddy = board[row][col].type == TileType.Dirty;

                boardObj[row][col].GetComponent<Renderer>().enabled = muddy;

            }
        }
        	
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

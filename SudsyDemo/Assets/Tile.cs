using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{

    
    public class Tile
    {

        //insert move behaviour
        public int row, col;
        protected MoveBehavior moveBehaviour;        

        public Tile(int row, int col)
        {

            this.row = row;
            this.col = col;
            moveBehaviour = new MoveBehaviorDeafult();

        }

        public Boolean MoveTo(Actor act)
        {

            return moveBehaviour.move(act, this);

        }

    }

    public class Block : Tile
    {

        public Block(int row, int col) : base(row, col)
        {

            moveBehaviour = new MoveBehaviorBlock();

        }

    }
}

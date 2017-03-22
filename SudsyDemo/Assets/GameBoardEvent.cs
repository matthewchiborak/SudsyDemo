using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class GameBoardEvent
    {

        public GameBoardEvent() { }

        public virtual Boolean doEvent(GameBoard gb)
        {
            return false;
        }

    }

    public class PlayerMoveEvent : GameBoardEvent
    {

        public PlayerMoveEvent() { }

    }

    //move player up event
    public class PlayerMoveEventUp : PlayerMoveEvent
    {

        public override Boolean doEvent(GameBoard gb)
        {

            ActorPlayer p = gb.player;

            if (p.row <= 0) return false;

            Tile tile = gb.board[p.row - 1][p.col];

            return tile.MoveTo(gb.player);

        }

    }

    public class PlayerMoveEventLeft : PlayerMoveEvent
    {

        public override Boolean doEvent(GameBoard gb)
        {

            ActorPlayer p = gb.player;

            if (p.col <= 0) return false;

            Tile tile = gb.board[p.row][p.col - 1];

            return tile.MoveTo(gb.player);

        }

    }

    public class PlayerMoveEventDown : PlayerMoveEvent
    {

        public override Boolean doEvent(GameBoard gb)
        {

            ActorPlayer p = gb.player;

            if (p.row >= (gb.height - 1) ) return false;

            Tile tile = gb.board[p.row + 1][p.col];

            return tile.MoveTo(gb.player);

        }

    }

    public class PlayerMoveEventRight : PlayerMoveEvent
    {

        public override Boolean doEvent(GameBoard gb)
        {

            ActorPlayer p = gb.player;

            if (p.col >= (gb.width - 1) ) return false;

            Tile tile = gb.board[p.row][p.col + 1];

            return tile.MoveTo(gb.player);

        }

    }
}

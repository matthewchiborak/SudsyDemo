using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{

    //Maybe return a gamebehviour for updating/chaining?
    
    public class MoveBehavior
    {

        public virtual Boolean move(Actor actor, Tile block)
        {

            return false;

        }

    }

    public class MoveBehaviorDeafult : MoveBehavior
    {

        public override Boolean move(Actor actor, Tile block)
        {

            actor.row = block.row;
            actor.col = block.col;

            return true;

        }

    }

    public class MoveBehaviorBlock : MoveBehavior
    {

        public override Boolean move(Actor actor, Tile block)
        {

            return false;

        }

    }
}

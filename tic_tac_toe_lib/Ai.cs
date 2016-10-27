// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------

using System;

namespace TicTacToe
{
    public abstract class Ai
    {
        public Ai ()
        {
        }

        // Subclasses override this to make a move.
        // Throws if we can't make a move (because game is over)
        public abstract void MakeMove(Board b, Player p);

        // Call from subclasses' MakeMove() override
        protected void ThrowIfCannotMakeMove(Board b)
        {
            if (b.GetMoves().Count == 0)
            {
                throw new ApplicationException("No empty square, can't make move.");
            }
        }
    }
}


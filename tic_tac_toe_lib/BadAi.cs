// ------------------------------------------------------------------------------
// j.c. TDD tic tac toe learning example - Oct 2016
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace TicTacToe
{
    // Implements the Ai interface... badly, not in a smart way
    public class BadAi : Ai
    {
        public BadAi()
        {
            rnd = new Random();
        }

        public override void MakeMove(Board b, Player p) 
        {
            ThrowIfCannotMakeMove(b, p);

            // Get list of possible moves - same for either player
            List<Move> moves = b.GetMoves(p);
            int r = rnd.Next(0, moves.Count);
            b.MakeMove(moves[r]);
        }

        private Random rnd;
    }
}


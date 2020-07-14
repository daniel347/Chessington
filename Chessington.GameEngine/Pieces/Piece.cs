using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);
        
        protected List<Square> GetLateralMoves(Board board, Square currentPos)
        {
            var availableMoves = new List<Square>();
            for (var i = 0; i < GameSettings.BoardSize; i++)
                availableMoves.Add(Square.At(currentPos.Row, i));

            for (var i = 0; i < GameSettings.BoardSize; i++)
                availableMoves.Add(Square.At(i, currentPos.Col));

            return availableMoves;
        }
        
        protected List<Square> GetDiagonalMoves(Board board, Square currentPos)
        {
            var availableMoves = new List<Square>();
            for (var u = 0; u < GameSettings.BoardSize; u++)
            {
                var v1 = u - currentPos.Col + currentPos.Row;
                var v2 = currentPos.Col + currentPos.Row - u;
                
                if (board.IsPositionValid(v1, u))
                {
                    availableMoves.Add(Square.At(v1, u));
                }

                if (board.IsPositionValid(v2, u))
                {
                    availableMoves.Add(Square.At(v2, u));
                }
            }

            return availableMoves;
        }
        
        public virtual void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
    }
}
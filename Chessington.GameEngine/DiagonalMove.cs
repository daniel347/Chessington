using System.Collections.Generic;

namespace Chessington.GameEngine
{
    public class DiagonalMove
    {
        public DiagonalMove()
        {
        }

        public IEnumerable<Square> GetDiagonalMoves(Board board, Square currentPos)
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
    }
}
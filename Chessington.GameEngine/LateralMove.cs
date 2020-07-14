using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine
{
    enum Direction
    {
        Horizontal,
        Vertical
    }
    
    public class LateralMove
    {
        public IEnumerable<Square> GetLateralMoves(Board board, Square currentPos)
        {
            var availableMovesHorizontally = GetMovesInLine(board, currentPos, Direction.Horizontal);
            var availableMovesVertically = GetMovesInLine(board, currentPos, Direction.Vertical);

            return availableMovesHorizontally.Concat(availableMovesVertically);
        }

        private IEnumerable<Square> GetMovesInLine(Board board, Square currentPos, Direction dir)
        {
            var availableMoves = new List<Square>();
            
            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                Square square;
                int piecePosition;  // the piece position along the axis we are moving
                
                if (dir == Direction.Horizontal)
                {
                    square = Square.At(currentPos.Row, i);
                    piecePosition = currentPos.Col;
                }
                else
                {
                    square = Square.At(i, currentPos.Col);
                    piecePosition = currentPos.Row;
                }
                
                if (!board.IsSquareEmpty(square))
                {
                    if (i < piecePosition)
                    {
                        availableMoves.Clear();
                    } 
                    else if (i > piecePosition)
                    {
                        break;
                    }
                }
                availableMoves.Add(square);
            }

            return availableMoves;
        }
    }
}
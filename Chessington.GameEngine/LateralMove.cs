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
        private Player player;

        public LateralMove(Player player)
        {
            this.player = player;
        }
        
        public IEnumerable<Square> GetLateralMoves(Board board, Square currentPos)
        {
            var availableMovesHorizontally = GetMovesInLine(board, currentPos, Direction.Horizontal);
            var availableMovesVertically = GetMovesInLine(board, currentPos, Direction.Vertical);

            return availableMovesHorizontally.Concat(availableMovesVertically);
        }

        private IEnumerable<Square> GetMovesInLine(Board board, Square currentPos, Direction dir)
        {
            var availableMoves = new List<Square>();
            var crossedPiece = false; // decides if the piece we intend to move has been crossed
            
            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                Square square;
                
                if (dir == Direction.Horizontal)
                {
                    square = Square.At(currentPos.Row, i);
                }
                else
                {
                    square = Square.At(i, currentPos.Col);
                }

                if (square == currentPos)
                {
                    crossedPiece = true;
                    continue;
                }

                if (!board.IsSquareEmpty(square))
                {
                    if (HandleBlockingPieceAndBreak(board, square, crossedPiece, ref availableMoves))
                    {
                        break;
                    }
                }
                else
                {
                    availableMoves.Add(square);
                }
            }
            return availableMoves;
        }

        private bool HandleBlockingPieceAndBreak(Board board, Square square, bool crossedPiece, ref List<Square> availableMoves)
        {
            if (crossedPiece)
            {
                if (board.GetPiece(square).Player != player)
                { 
                    // if the piece is an enemy piece, can capture it
                    availableMoves.Add(square);
                }
                
                return true;
            }
            // If the loop hasn't passed the piece being moved yet all the positions so far are invalid
            availableMoves.Clear();
            return false;
        }
    }
}
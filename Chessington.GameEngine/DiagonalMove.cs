using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine
{
    enum Diagonal
    {
        LeadingWhiteDiagonal, 
        LeadingBlackDiagonal
    }

    public class DiagonalMove
    {
        private Player player;

        public DiagonalMove(Player player)
        {
            this.player = player;
        }
        
        public IEnumerable<Square> GetDiagonalMoves(Board board, Square currentPos)
        {
            var availableMoves = GetMovesInLine(board, currentPos, Diagonal.LeadingBlackDiagonal).ToList();
            availableMoves.AddRange(GetMovesInLine(board, currentPos, Diagonal.LeadingWhiteDiagonal));
            return availableMoves;
        }
        
        private IEnumerable<Square> GetMovesInLine(Board board, Square currentPos, Diagonal dir)
        {
            var availableMoves = new List<Square>();
            var crossedPiece = false; // decides if the piece we intend to move has been crossed
            
            for (var u = 0; u < GameSettings.BoardSize; u++)
            {
                Square square;

                if (dir == Diagonal.LeadingBlackDiagonal)
                {
                    square = Square.At( u - currentPos.Col + currentPos.Row, u);
                }
                else
                {
                    square = Square.At(currentPos.Col + currentPos.Row - u, u);
                    
                }
                
                if (!board.IsPositionValid(square))
                {
                    continue;
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
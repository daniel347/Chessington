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
                    if (crossedPiece)
                    {
                        break;
                    }
                    
                    availableMoves.Clear();
                }
                availableMoves.Add(square);
            }
            return availableMoves;
        }
    }
}
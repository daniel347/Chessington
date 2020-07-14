using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
            var availableMoves = GetLateralMoves(board, currentPos);

            availableMoves.AddRange(GetDiagonalMoves(board, currentPos));

            // Remove start square, duplicates and return
            availableMoves.RemoveAll(s => s == Square.At(4, 4));
            return availableMoves.Distinct();
        }

        private List<Square> GetLateralMoves(Board board, Square currentPos)
        {
            var availableMoves = new List<Square>();
            for (var i = 0; i < 8; i++)
                availableMoves.Add(Square.At(currentPos.Row, i));

            for (var i = 0; i < 8; i++)
                availableMoves.Add(Square.At(i, currentPos.Col));

            return availableMoves;
        }

        private List<Square> GetDiagonalMoves(Board board, Square currentPos)
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
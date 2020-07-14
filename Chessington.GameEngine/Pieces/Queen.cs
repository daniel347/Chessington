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
            return availableMoves;
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player) : base(player)
        {
            lateralMove = new LateralMove(player);
            diagonalMove = new DiagonalMove(player);
        }
        
        private readonly LateralMove lateralMove;
        private readonly DiagonalMove diagonalMove;

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
            var availableMoves = lateralMove.GetLateralMoves(board, currentPos).ToList();

            availableMoves.AddRange(diagonalMove.GetDiagonalMoves(board, currentPos));

            // Remove start square, duplicates and return
            availableMoves.RemoveAll(s => s == Square.At(4, 4));
            return availableMoves.Where(board.IsPositionValid);
        }
    }
}
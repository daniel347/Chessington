using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player) : base(player)
        {
            diagonalMove = new DiagonalMove(player);
        }

        private readonly DiagonalMove diagonalMove;

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
            var availableMoves = diagonalMove.GetDiagonalMoves(board, currentPos).ToList();
            availableMoves.RemoveAll(s => s == Square.At(4, 4));
                
            return availableMoves.Where(board.IsPositionValid);
        }
    }
}
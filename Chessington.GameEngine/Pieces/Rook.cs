using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player) : base(player)
        {
            lateralMove = new LateralMove(player);
        }
        
        private readonly LateralMove lateralMove;

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
            var availableMoves = lateralMove.GetLateralMoves(board, currentPos).ToList();

            return availableMoves.Where(board.IsPositionValid);
        }
    }
}
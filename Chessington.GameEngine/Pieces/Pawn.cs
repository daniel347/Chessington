using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
            var moveDir = 0;
            
            if (this.Player == Player.White)
            {
                moveDir = -1;
            }
            else if (this.Player == Player.Black)
            {
                moveDir = 1;
            }
            
            return new List<Square>() {Square.At(currentPos.Row + moveDir, currentPos.Col)} ;
        }
    }
}
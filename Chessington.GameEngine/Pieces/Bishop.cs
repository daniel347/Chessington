using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
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

            //Get rid of our starting location.
            availableMoves.RemoveAll(s => s == Square.At(4, 4));
            return availableMoves;
        }
    }
}
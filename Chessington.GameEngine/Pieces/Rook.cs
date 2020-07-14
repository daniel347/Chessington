using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPos = board.FindPiece(this);

            var availableMoves = new List<Square>();

            for (var i = 0; i < GameSettings.BoardSize; i++)
                availableMoves.Add(Square.At(currentPos.Row, i));

            for (var i = 0; i < GameSettings.BoardSize; i++)
                availableMoves.Add(Square.At(i, currentPos.Col));

            //Get rid of our starting location.
            availableMoves.RemoveAll(s => s == currentPos);

            return availableMoves;
        }
    }
}
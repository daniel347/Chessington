using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
            var availableMoves = new List<Square>()
            {
                Square.At(currentPos.Row + 1, currentPos.Col),
                Square.At(currentPos.Row + 1, currentPos.Col + 1),
                Square.At(currentPos.Row, currentPos.Col + 1),
                Square.At(currentPos.Row - 1, currentPos.Col + 1),
                Square.At(currentPos.Row - 1, currentPos.Col),
                Square.At(currentPos.Row - 1, currentPos.Col - 1),
                Square.At(currentPos.Row, currentPos.Col - 1 ),
                Square.At(currentPos.Row + 1, currentPos.Col - 1)
            };

            return availableMoves;
        }
    }
}
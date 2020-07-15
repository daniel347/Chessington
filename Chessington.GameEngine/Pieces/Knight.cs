using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
            var availableMoves = new List<Square>()
            {
                Square.At(currentPos.Row + 2, currentPos.Col + 1),
                Square.At(currentPos.Row + 2, currentPos.Col - 1),
                Square.At(currentPos.Row - 2, currentPos.Col + 1),
                Square.At(currentPos.Row - 2, currentPos.Col - 1),
                Square.At(currentPos.Row + 1, currentPos.Col + 2),
                Square.At(currentPos.Row + 1, currentPos.Col - 2),
                Square.At(currentPos.Row - 1, currentPos.Col + 2),
                Square.At(currentPos.Row - 1, currentPos.Col - 2)
            };

            return availableMoves.Where(board.IsPositionValid);
        }
    }
}
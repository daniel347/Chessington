using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        private bool IsFirstMove { get; set; } = true;

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
            
            var availableMoves = new List<Square>();
            availableMoves.Add(GetNSquaresForward(currentPos, 1));

            if (IsFirstMove)
            {
                availableMoves.Add(GetNSquaresForward(currentPos, 2));
            }
            
            return availableMoves;
        }

        public override void MoveTo(Board board, Square newSquare)
        {
            base.MoveTo(board, newSquare);
            IsFirstMove = false;
        }

        private Square GetNSquaresForward(Square currentPos, int N)
        {
            Square newSquare;
            
            if (this.Player == Player.White)
            {
                newSquare = Square.At(currentPos.Row - N, currentPos.Col);
            }
            else
            {
                newSquare = Square.At(currentPos.Row + N, currentPos.Col);
            }

            return newSquare;
        }

    }
}
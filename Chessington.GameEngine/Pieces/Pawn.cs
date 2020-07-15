using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        private bool isFirstMove = true;

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPos = board.FindPiece(this);
            var availableMoves = new List<Square>();
            
            var oneSquareAhead = GetNSquaresForward(currentPos, 1);
            var twoSquaresAhead = GetNSquaresForward(currentPos, 2);

            if (!board.IsPositionValid(oneSquareAhead)  || !board.IsSquareEmpty(oneSquareAhead))
            {
                return availableMoves;
            }
            
            availableMoves.Add(oneSquareAhead);
            if (isFirstMove && board.IsPositionValid(twoSquaresAhead) && board.IsSquareEmpty(twoSquaresAhead))
            {
                availableMoves.Add(twoSquaresAhead);
            }

            return availableMoves;
        }

        public override void MoveTo(Board board, Square newSquare)
        {
            base.MoveTo(board, newSquare);
            isFirstMove = false;
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
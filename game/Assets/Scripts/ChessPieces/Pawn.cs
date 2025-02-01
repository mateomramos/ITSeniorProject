using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        int direction = (team == 0) ? 1 : -1;
        
        // Single forward move
        if (board[currentX, currentY + direction] == null) { 
            r.Add(new Vector2Int(currentX, currentY + direction));
        }

        //Double forward move
        if (board[currentX, currentY + direction] == null) { 

            // White team
            if (team == 0 && currentY == 1 && board[currentX, currentY + (direction * 2)] == null) {
                r.Add(new Vector2Int(currentX, currentY + (direction * 2)));
            }
            // Black team
            if (team == 1 && currentY == 6 && board[currentX, currentY + (direction * 2)] == null)
            {
                r.Add(new Vector2Int(currentX, currentY + (direction * 2)));
            }
        }

        // Diagonal Capture

        // Check left diagonal
        if (currentX != tileCountX - 1) {
            
            if (board[currentX + 1, currentY + direction] != null && board[currentX + 1, currentY + direction].team != team) { 
                r.Add(new Vector2Int(currentX + 1, currentY + direction));
            }
        }
        // Check right diagonal
        if (currentX != 0)
        {
            // Check left diagonal
            if (board[currentX -1, currentY + direction] != null && board[currentX - 1, currentY + direction].team != team)
            {
                r.Add(new Vector2Int(currentX - 1, currentY + direction));
            }
        }

        return r;
    }

    public override SpecialMove GetSpecialMoves(ref ChessPiece[,] board, ref List<Vector2Int[]> moveList, ref List<Vector2Int> availableMoves)
    {
        int direction = (team == 0) ? 1 : -1;

        if (((team == 0) && currentY == 6) || ((team == 1) && currentY == 1)) {

            

            return SpecialMove.Promotion;
        }

        // En Passant
        if (moveList.Count > 0) {

            Vector2Int[] lastMove = moveList[moveList.Count - 1];
            //If the last piece moved was a pawn
            if (board[lastMove[1].x, lastMove[1].y].type == ChessPieceType.Pawn) {
                //If the last pawn move was a double move in either direction
                if (Mathf.Abs(lastMove[0].y - lastMove[1].y) == 2)  { 
                    //If the last move was from the other team
                    if (board[lastMove[1].x, lastMove[1].y].team != team) {
                        //If both pawns end up on the same y
                        if (lastMove[1].y == currentY) { 
                            
                            //Left side
                            if (lastMove[1].x == currentX - 1) {
                                availableMoves.Add(new Vector2Int(currentX - 1, currentY + direction));
                                return SpecialMove.EnPassant;
                            }
                            //Right side
                            if (lastMove[1].x == currentX + 1) { 
                                availableMoves.Add(new Vector2Int(currentX + 1, currentY + direction));
                                return SpecialMove.EnPassant;
                            }
                        }
                    }
                }
            }
        }

        return SpecialMove.None;
    }
}

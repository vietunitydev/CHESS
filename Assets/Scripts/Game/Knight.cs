using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPieceBase
{
    public override List<Vector2Int> GetValidMoves(ChessPieceBase[,] board)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        Vector2Int currentPosition = this.Position;

        // Nước đi hình chữ L (2 ô theo một hướng, sau đó 1 ô theo hướng vuông góc)
        Vector2Int[] possibleMoves = {
            new Vector2Int(currentPosition.x + 2, currentPosition.y + 1),
            new Vector2Int(currentPosition.x + 2, currentPosition.y - 1),
            new Vector2Int(currentPosition.x - 2, currentPosition.y + 1),
            new Vector2Int(currentPosition.x - 2, currentPosition.y - 1),
            new Vector2Int(currentPosition.x + 1, currentPosition.y + 2),
            new Vector2Int(currentPosition.x + 1, currentPosition.y - 2),
            new Vector2Int(currentPosition.x - 1, currentPosition.y + 2),
            new Vector2Int(currentPosition.x - 1, currentPosition.y - 2)
        };

        foreach (Vector2Int move in possibleMoves)
        {
            if (IsInsideBoard(move) && (board[move.x, move.y] == null || board[move.x, move.y].ColorType != this.ColorType))
            {
                validMoves.Add(move);
            }
        }

        return validMoves;
    }
}

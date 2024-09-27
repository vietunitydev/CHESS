using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPieceBase
{
    public override List<Vector2Int> GetValidMoves(ChessPieceBase[,] board)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        Vector2Int currentPosition = this.Position;

        // Các nước đi có thể của quân vua (1 ô theo mọi hướng)
        Vector2Int[] possibleMoves = {
            new Vector2Int(currentPosition.x + 1, currentPosition.y),
            new Vector2Int(currentPosition.x - 1, currentPosition.y),
            new Vector2Int(currentPosition.x, currentPosition.y + 1),
            new Vector2Int(currentPosition.x, currentPosition.y - 1),
            new Vector2Int(currentPosition.x + 1, currentPosition.y + 1),
            new Vector2Int(currentPosition.x - 1, currentPosition.y - 1),
            new Vector2Int(currentPosition.x + 1, currentPosition.y - 1),
            new Vector2Int(currentPosition.x - 1, currentPosition.y + 1)
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

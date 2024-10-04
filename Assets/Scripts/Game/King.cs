using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPieceBase
{
    public override List<HighLightData> GetValidMoves(ChessPieceBase[,] board)
    {
        List<HighLightData> validMoves = new List<HighLightData>();
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
            if (IsInsideBoard(move) && board[move.x, move.y] == null)
            {
                HighLightData data = new HighLightData(HighLightColor.Blue, move);
                validMoves.Add(data);
            }
            else if (IsInsideBoard(move) && board[move.x, move.y].ChessColorType != this.ChessColorType)
            {
                HighLightData data = new HighLightData(HighLightColor.Red, move);
                validMoves.Add(data);
            }
        }

        return validMoves;
    }

    public override void HandleAfterMove()
    {
        
    }
}

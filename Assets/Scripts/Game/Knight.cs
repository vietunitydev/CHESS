using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPieceBase
{
    public override List<HighLightData> GetValidMoves(ChessPieceBase[,] board)
    {
        List<HighLightData> validMoves = new List<HighLightData>();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPieceBase
{
    public override List<HighLightData> GetValidMoves(ChessPieceBase[,] board)
    {
        List<HighLightData> validMoves = new List<HighLightData>();
        Vector2Int currentPosition = this.Position;

        // Di chuyển chéo
        validMoves.AddRange(GetBishopLikeMoves(board, currentPosition));

        return validMoves;
    }

    public override void HandleAfterMove()
    {
        
    }
}

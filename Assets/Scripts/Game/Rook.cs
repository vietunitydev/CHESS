using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPieceBase
{
    public override List<HighLightData> GetValidMoves(ChessPieceBase[,] board)
    {
        List<HighLightData> validMoves = new List<HighLightData>();
        Vector2Int currentPosition = this.Position;

        // Di chuyển theo hàng ngang hoặc dọc
        validMoves.AddRange(GetRookLikeMoves(board, currentPosition));

        return validMoves;
    }

    public override void HandleAfterMove()
    {
        
    }
}

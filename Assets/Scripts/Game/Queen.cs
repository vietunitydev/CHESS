using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPieceBase
{
    public override List<HighLightData> GetValidMoves(ChessPieceBase[,] board)
    {
        List<HighLightData> validMoves = new List<HighLightData>();
        Vector2Int currentPosition = this.Position;

        // Di chuyển theo các hướng của cả xe và tịnh (rook + bishop)
        validMoves.AddRange(GetRookLikeMoves(board, currentPosition));
        validMoves.AddRange(GetBishopLikeMoves(board, currentPosition));

        return validMoves;
    }

    public override void HandleAfterMove()
    {
        
    }
}

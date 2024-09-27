using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPieceBase
{
    public override List<Vector2Int> GetValidMoves(ChessPieceBase[,] board)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        Vector2Int currentPosition = this.Position;

        // Di chuyển chéo
        validMoves.AddRange(GetBishopLikeMoves(board, currentPosition));

        return validMoves;
    }

    public override void HandleAfterMove()
    {
        
    }
}

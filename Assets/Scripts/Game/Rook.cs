using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPieceBase
{
    public override List<Vector2Int> GetValidMoves(ChessPieceBase[,] board)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        Vector2Int currentPosition = this.Position;

        // Di chuyển theo hàng ngang hoặc dọc
        validMoves.AddRange(GetRookLikeMoves(board, currentPosition));

        return validMoves;
    }
}

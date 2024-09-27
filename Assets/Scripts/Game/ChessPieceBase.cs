using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPieceBase : MonoBehaviour
{
    [SerializeField] private ChessType chessType;
    [SerializeField] private ColorType colorType;

    public ChessType ChessType => chessType;
    public ColorType ColorType => colorType;
    public Vector2Int Position { get; set; }


    protected void OnMouseDown()
    {
        InGameScreen.Instance.SetText(gameObject.name);
        BoardManager.Instance.OnClickChess(this);
    }

    public virtual void OnCLick()
    {
        
    }

    public virtual void Move()
    {
        
    }
    
    public abstract List<Vector2Int> GetValidMoves(ChessPieceBase[,] board);
}

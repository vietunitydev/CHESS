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
    
    public abstract List<HighLightData> GetValidMoves(ChessPieceBase[,] board);
    public abstract void HandleAfterMove(); 
    
    protected bool IsInsideBoard(Vector2Int position)
    {
        return position.x >= 0 && position.x < 8 && position.y >= 0 && position.y < 8;
    }
    
    protected List<HighLightData> GetRookLikeMoves(ChessPieceBase[,] board, Vector2Int currentPosition)
    {
        List<HighLightData> validMoves = new List<HighLightData>();

        // Hàng ngang (trái-phải)
        for (int x = currentPosition.x + 1; x < 8; x++)
        {
            if (AddMoveIfValid(board, validMoves, x, currentPosition.y)) break;
        }
        for (int x = currentPosition.x - 1; x >= 0; x--)
        {
            if (AddMoveIfValid(board, validMoves, x, currentPosition.y)) break;
        }

        // Hàng dọc (trên-dưới)
        for (int y = currentPosition.y + 1; y < 8; y++)
        {
            if (AddMoveIfValid(board, validMoves, currentPosition.x, y)) break;
        }
        for (int y = currentPosition.y - 1; y >= 0; y--)
        {
            if (AddMoveIfValid(board, validMoves, currentPosition.x, y)) break;
        }

        return validMoves;
    }

    protected List<HighLightData> GetBishopLikeMoves(ChessPieceBase[,] board, Vector2Int currentPosition)
    {
        List<HighLightData> validMoves = new List<HighLightData>();
        
        for (int i = 1; i < 8; i++)
        {
            // Diagonal top-right
            if (AddMoveIfValid(board, validMoves, currentPosition.x + i, currentPosition.y + i)) break;
        }
        for (int i = 1; i < 8; i++)
        {
            // Diagonal top-left
            if (AddMoveIfValid(board, validMoves, currentPosition.x - i, currentPosition.y + i)) break;
        }
        for (int i = 1; i < 8; i++)
        {
            // Diagonal bottom-right
            if (AddMoveIfValid(board, validMoves, currentPosition.x + i, currentPosition.y - i)) break;
        }
        for (int i = 1; i < 8; i++)
        {
            // Diagonal bottom-left
            if (AddMoveIfValid(board, validMoves, currentPosition.x - i, currentPosition.y - i)) break;
        }

        return validMoves;
    }

    private bool AddMoveIfValid(ChessPieceBase[,] board, List<HighLightData> validMoves, int x, int y)
    {
        if (IsInsideBoard(new Vector2Int(x, y)))
        {
            if (board[x, y] == null)
            {
                HighLightData data = new HighLightData(HighLightColor.Blue, new Vector2Int(x, y));
                validMoves.Add(data);
                return false;
            }
            else if (board[x, y].ColorType != ColorType)
            {
                HighLightData data = new HighLightData(HighLightColor.Red, new Vector2Int(x, y));
                validMoves.Add(data);
                return true;
            }
            else
            {
                return true;
            }
        }
        return true;
    }

}


public class HighLightData
{
    public HighLightData(HighLightColor color, Vector2Int pos)
    {
        Color = color;
        Position = pos;
    }
    public HighLightColor Color { get; }

    public Vector2Int Position { get; }
}

public enum HighLightColor
{
    Blue, Red
}

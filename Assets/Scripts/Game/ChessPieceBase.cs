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
    
    public abstract List<Vector2Int> GetValidMoves(ChessPieceBase[,] board);
    
    protected bool IsInsideBoard(Vector2Int position)
    {
        return position.x >= 0 && position.x < 8 && position.y >= 0 && position.y < 8;
    }
    
    protected List<Vector2Int> GetRookLikeMoves(ChessPieceBase[,] board, Vector2Int currentPosition)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

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

    protected List<Vector2Int> GetBishopLikeMoves(ChessPieceBase[,] board, Vector2Int currentPosition)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        
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

    private bool AddMoveIfValid(ChessPieceBase[,] board, List<Vector2Int> validMoves, int x, int y)
    {
        if (IsInsideBoard(new Vector2Int(x, y)))
        {
            if (board[x, y] == null)
            {
                validMoves.Add(new Vector2Int(x, y));
                return false;
            }
            else if (board[x, y].ColorType != ColorType)
            {
                validMoves.Add(new Vector2Int(x, y));
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

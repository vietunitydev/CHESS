using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BoardManager : MonoSingleton<BoardManager>
{
    [SerializeField] private BoardSpawner boardSpawner;
    [SerializeField] private List<HighLight> highLights = new();
    
    [SerializeField] private ChessColorType myColor;
    private ChessPieceBase[,] ChessBoard { get; set; }
    private ChessPieceBase _currentChess;

    protected override void DoOnStart()
    {
        base.DoOnStart();
        ChessBoard = boardSpawner.GenerateBoard(myColor);
    }

    public void OnClickChess(ChessPieceBase chess)
    {
        _currentChess = chess;
        var moves = chess.GetValidMoves(ChessBoard);
        
        // Debug.Log($"--- (BoardManager) OnClickChess");
        // Debug.Log($"--- (BoardManager) List Valid Moves Count {moves.Count}");
        ClearHighLight();
        SpawnHighLight(moves);
    }
    
    public void MovePiece(ChessPieceBase piece, Vector2Int newPosition)
    {
        piece.HandleAfterMove();
        
        if (ChessBoard[newPosition.x, newPosition.y] != null)
        {
            Destroy(ChessBoard[newPosition.x, newPosition.y].gameObject);
        }
        
        ChessBoard[piece.Position.x, piece.Position.y] = null;
        piece.Position = newPosition;
        ChessBoard[newPosition.x, newPosition.y] = piece;

        piece.transform.position = boardSpawner.GetPosition(newPosition.x, newPosition.y);
        
        ClearHighLight();
    }
    public void MovePiece(Vector2Int newPosition)
    {
        _currentChess.HandleAfterMove();
        
        if (ChessBoard[newPosition.x, newPosition.y] != null)
        {
            Destroy(ChessBoard[newPosition.x, newPosition.y].gameObject);
        }

        ChessBoard[_currentChess.Position.x, _currentChess.Position.y] = null;
        _currentChess.Position = newPosition;
        ChessBoard[newPosition.x, newPosition.y] = _currentChess;

        _currentChess.transform.position = boardSpawner.GetPosition(newPosition.x, newPosition.y);
        
        ClearHighLight();
    }

    private void SpawnHighLight(List<HighLightData> moves)
    {
        // spawn highLight
        foreach (var move in moves)
        {
            if (move.Color == HighLightColor.Red)
            {
                highLights.Add(boardSpawner.SpawnHighLightRed(move.Position.x, move.Position.y));
            }
            else if (move.Color == HighLightColor.Blue)
            {
                highLights.Add(boardSpawner.SpawnHighLightBlue(move.Position.x, move.Position.y));
            }
        }
    }

    private void ClearHighLight()
    {
        // remove high light
        if (highLights == null)
        {
            return;
        }
        foreach (var highLight in highLights)
        {
            Destroy(highLight.gameObject);
        }
        highLights.Clear();
    }

    private bool IsWin()
    {
        // if king die 
        bool kingStillLive = false;
        foreach (var chess in ChessBoard)
        {
            if (chess != null)
            {
                if (chess.ChessType == ChessType.King && chess.ChessColorType != myColor)
                {
                    kingStillLive = true;
                }
            }
        }
        

        return false;
    }
}

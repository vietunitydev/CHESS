using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BoardManager : MonoSingleton<BoardManager>
{
    [SerializeField] private BoardSpawner boardSpawner;
    [SerializeField] private List<HighLight> highLights = new();
    public ChessPieceBase[,] ChessBoard { get; private set; }
    private ChessPieceBase currentChess;

    protected override void DoOnStart()
    {
        base.DoOnStart();
        ChessBoard = boardSpawner.GenerateBoard();
    }

    public void OnClickChess(ChessPieceBase chess)
    {
        currentChess = chess;
        var moves = chess.GetValidMoves(ChessBoard);
        
        // Debug.Log($"--- (BoardManager) OnClickChess");
        // Debug.Log($"--- (BoardManager) List Valid Moves Count {moves.Count}");

        SpawnHighLight(moves);
    }
    
    public void MovePiece(ChessPieceBase piece, Vector2Int newPosition)
    {
        piece.HandleAfterMove();
        ChessBoard[piece.Position.x, piece.Position.y] = null;
        piece.Position = newPosition;
        ChessBoard[newPosition.x, newPosition.y] = piece;

        piece.transform.position = boardSpawner.GetPosition(newPosition.x, newPosition.y);
        
        ClearHighLight();
    }
    public void MovePiece(Vector2Int newPosition)
    {
        currentChess.HandleAfterMove();
        ChessBoard[currentChess.Position.x, currentChess.Position.y] = null;
        currentChess.Position = newPosition;
        ChessBoard[newPosition.x, newPosition.y] = currentChess;

        currentChess.transform.position = boardSpawner.GetPosition(newPosition.x, newPosition.y);
        
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
        Debug.Log($"Clear High Light");
        // remove high light
        if (highLights == null)
        {
            return;
        }
        foreach (var highLight in highLights)
        {
            Destroy(highLight);
        }
        highLights.Clear();
    }
}

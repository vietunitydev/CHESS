using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BoardManager : MonoSingleton<BoardManager>
{
    [SerializeField] private BoardSpawner boardSpawner;
    [SerializeField] private List<GameObject> highLights = new();
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
        // Debug.Log($"--- (BoardManager) List Valid Moves Count {list.Count}");

        ClearHighLight();
        SpawnHighLight(moves);
    }
    
    public void MovePiece(ChessPieceBase piece, Vector2Int newPosition)
    {
        if (piece.GetValidMoves(ChessBoard).Contains(newPosition))
        {
            piece.HandleAfterMove();
            ChessBoard[piece.Position.x, piece.Position.y] = null;
            piece.Position = newPosition;
            ChessBoard[newPosition.x, newPosition.y] = piece;

            piece.transform.position = boardSpawner.GetPosition(newPosition.x, newPosition.y);
        }
        
        ClearHighLight();
    }
    public void MovePiece(Vector2Int newPosition)
    {
        if (currentChess.GetValidMoves(ChessBoard).Contains(newPosition))
        {
            currentChess.HandleAfterMove();
            ChessBoard[currentChess.Position.x, currentChess.Position.y] = null;
            currentChess.Position = newPosition;
            ChessBoard[newPosition.x, newPosition.y] = currentChess;

            currentChess.transform.position = boardSpawner.GetPosition(newPosition.x, newPosition.y);
        }
        
        ClearHighLight();
    }

    private void SpawnHighLight(List<Vector2Int> moves)
    {
        // spawn highLight
        foreach (var move in moves)
        {
            var highLightObject = boardSpawner.SpawnHighLight(move.x, move.y);
            HighLight highLight = highLightObject.GetComponent<HighLight>();
            highLight.Position = new Vector2Int(move.x, move.y);
            highLights.Add(highLightObject);
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
            Destroy(highLight);
        }
        highLights.Clear();
    }
}

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

    protected override void DoOnStart()
    {
        base.DoOnStart();
        ChessBoard = boardSpawner.GenerateBoard();
    }

    public void OnClickChess(ChessPieceBase chess)
    {
        // Debug.Log($"--- (BoardManager) OnClickChess");
        var moves = chess.GetValidMoves(ChessBoard);
        // Debug.Log($"--- (BoardManager) List Valid Moves Count {list.Count}");
        
        // remove high light
        foreach (var highLight in highLights)
        {
            Destroy(highLight);
        }
        highLights.Clear();
        // spawn highLight
        foreach (var move in moves)
        {
            var highLight = boardSpawner.SpawnHighLight(move.x, move.y);
            highLights.Add(highLight);
        }
    }
    
}

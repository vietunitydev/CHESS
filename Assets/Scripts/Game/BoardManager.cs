using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoSingleton<BoardManager>
{
    [SerializeField] private BoardSpawner boardSpawner;
    
    public ChessPieceBase[,] ChessBoard { get; private set; }

    protected override void DoOnStart()
    {
        base.DoOnStart();
        ChessBoard = boardSpawner.GenerateBoard();
    }

    public void OnClickChess(ChessPieceBase chess)
    {
        Debug.Log($"--- (BoardManager) OnClickChess");
        var list = chess.GetValidMoves(ChessBoard);
        
        Debug.Log($"--- (BoardManager) List Valid Moves Count {list.Count}");


        foreach (var i in list)
        {
            Debug.Log($"x {i.x} y {i.y}");
        }
    }
}

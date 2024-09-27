using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private ChessPieceBase[,] _chessBoard;
    [SerializeField] private BoardSpawner boardSpawner;

    private void Start()
    {
        _chessBoard = new ChessPieceBase[8,8];
    }
}

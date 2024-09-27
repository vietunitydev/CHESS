using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BoardSpawner : MonoBehaviour
{
   [SerializeField] private float sideSquare = 0.06f;
   [SerializeField] private float height = 0.052f;
   
   [SerializeField] private ChessPieceBase PawnBlack;
   [SerializeField] private ChessPieceBase RookBlack;
   [SerializeField] private ChessPieceBase KnightBlack;
   [SerializeField] private ChessPieceBase BishopBlack;
   [SerializeField] private ChessPieceBase QueenBlack;
   [SerializeField] private ChessPieceBase KingBlack;
   
   [SerializeField] private ChessPieceBase PawnWhite;
   [SerializeField] private ChessPieceBase RookWhite;
   [SerializeField] private ChessPieceBase KnightWhite;
   [SerializeField] private ChessPieceBase BishopWhite;
   [SerializeField] private ChessPieceBase QueenWhite;
   [SerializeField] private ChessPieceBase KingWhite;
   [SerializeField] private Transform board;

   [SerializeField] private GameObject highLightPrefab;
   public ChessPieceBase[,] GenerateBoard()
   {
      ChessPieceBase[,] chessBoard = new ChessPieceBase[8, 8];

      chessBoard[4, 0] = Instantiate(KingBlack, GetPosition(5, 1), Quaternion.identity, board);
      chessBoard[3, 0] = Instantiate(QueenBlack, GetPosition(4, 1), Quaternion.identity, board);

      chessBoard[2, 0] = Instantiate(BishopBlack, GetPosition(3, 1), Quaternion.identity, board);
      chessBoard[5, 0] = Instantiate(BishopBlack, GetPosition(6, 1), Quaternion.identity, board);

      chessBoard[1, 0] = Instantiate(KnightBlack, GetPosition(2, 1), Quaternion.identity, board);
      chessBoard[6, 0] = Instantiate(KnightBlack, GetPosition(7, 1), Quaternion.identity, board);

      chessBoard[0, 0] = Instantiate(RookBlack, GetPosition(1, 1), Quaternion.identity, board);
      chessBoard[7, 0] = Instantiate(RookBlack, GetPosition(8, 1), Quaternion.identity, board);
      
      for (int i = 0; i < 8; i++)
      {
         chessBoard[i, 1] = Instantiate(PawnBlack, GetPosition(i + 1, 2), Quaternion.identity, board);
      }

      chessBoard[4, 7] = Instantiate(KingWhite, GetPosition(5, 8), Quaternion.identity, board);
      chessBoard[3, 7] = Instantiate(QueenWhite, GetPosition(4, 8), Quaternion.identity, board);

      chessBoard[2, 7] = Instantiate(BishopWhite, GetPosition(3, 8), Quaternion.identity, board);
      chessBoard[5, 7] = Instantiate(BishopWhite, GetPosition(6, 8), Quaternion.identity, board);

      chessBoard[1, 7] = Instantiate(KnightWhite, GetPosition(2, 8), Quaternion.identity, board);
      chessBoard[6, 7] = Instantiate(KnightWhite, GetPosition(7, 8), Quaternion.identity, board);

      chessBoard[0, 7] = Instantiate(RookWhite, GetPosition(1, 8), Quaternion.identity, board);
      chessBoard[7, 7] = Instantiate(RookWhite, GetPosition(8, 8), Quaternion.identity, board);

      for (int i = 0; i < 8; i++)
      {
         chessBoard[i, 6] = Instantiate(PawnWhite, GetPosition(i + 1, 7), Quaternion.identity, board);
      }

      for (int i = 0; i < 8; i++)
      {
         for (int j = 0; j < 8; j++)
         {
            if (chessBoard[i, j] != null)
            {
               chessBoard[i, j].Position = new Vector2Int(i, j);
            }
         }
      }

      return chessBoard;
   }

   private Vector3 GetPosition(int x, int y)
   {
      x = x - 4;
      y = y - 4;

      return new Vector3(-sideSquare/2 + x * sideSquare, height,-sideSquare/2 + y * sideSquare);
   }
   
   private Vector3 GetPosition(Vector2Int newPos)
   {
      var x = newPos.x - 4;
      var y = newPos.y - 4;

      return new Vector3(-sideSquare/2 + x * sideSquare, height,-sideSquare/2 + y * sideSquare);
   }

   public GameObject SpawnHighLight(int x, int y)
   {
      return Instantiate(highLightPrefab, GetPosition(x + 1, y + 1), Quaternion.identity, board);
   }
}

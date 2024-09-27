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

   [SerializeField] private HighLight highLightBlue;
   [SerializeField] private HighLight highLightRed;
   public ChessPieceBase[,] GenerateBoard(ChessColorType myColor)
   {
      ChessPieceBase[,] chessBoard = new ChessPieceBase[8, 8];

      chessBoard[4, 0] = Instantiate(KingBlack, GetPosition(4,0), Quaternion.identity, board);
      chessBoard[3, 0] = Instantiate(QueenBlack, GetPosition(3, 0), Quaternion.identity, board);

      chessBoard[2, 0] = Instantiate(BishopBlack, GetPosition(2, 0), Quaternion.identity, board);
      chessBoard[5, 0] = Instantiate(BishopBlack, GetPosition(5, 0), Quaternion.identity, board);

      chessBoard[1, 0] = Instantiate(KnightBlack, GetPosition(1, 0), Quaternion.identity, board);
      chessBoard[6, 0] = Instantiate(KnightBlack, GetPosition(6, 0), Quaternion.identity, board);

      chessBoard[0, 0] = Instantiate(RookBlack, GetPosition(0, 0), Quaternion.identity, board);
      chessBoard[7, 0] = Instantiate(RookBlack, GetPosition(7, 0), Quaternion.identity, board);
      
      for (int i = 0; i < 8; i++)
      {
         chessBoard[i, 1] = Instantiate(PawnBlack, GetPosition(i, 1), Quaternion.identity, board);
      }

      chessBoard[4, 7] = Instantiate(KingWhite, GetPosition(4, 7), Quaternion.identity, board);
      chessBoard[3, 7] = Instantiate(QueenWhite, GetPosition(3, 7), Quaternion.identity, board);

      chessBoard[2, 7] = Instantiate(BishopWhite, GetPosition(2, 7), Quaternion.identity, board);
      chessBoard[5, 7] = Instantiate(BishopWhite, GetPosition(5, 7), Quaternion.identity, board);

      chessBoard[1, 7] = Instantiate(KnightWhite, GetPosition(1, 7), Quaternion.identity, board);
      chessBoard[6, 7] = Instantiate(KnightWhite, GetPosition(6, 7), Quaternion.identity, board);

      chessBoard[0, 7] = Instantiate(RookWhite, GetPosition(0, 7), Quaternion.identity, board);
      chessBoard[7, 7] = Instantiate(RookWhite, GetPosition(7, 7), Quaternion.identity, board);

      for (int i = 0; i < 8; i++)
      {
         chessBoard[i, 6] = Instantiate(PawnWhite, GetPosition(i, 6), Quaternion.identity, board);
      }

      for (int i = 0; i < 8; i++)
      {
         for (int j = 0; j < 8; j++)
         {
            if (chessBoard[i, j] != null)
            {
               chessBoard[i, j].Position = new Vector2Int(i, j);
               
               if (chessBoard[i, j].ChessColorType != myColor)
               {
                  var meshCollider = chessBoard[i, j].GetComponent<MeshCollider>();
                  meshCollider.enabled = false;
               }
            }
         }
      }

      return chessBoard;
   }

   public Vector3 GetPosition(int x, int y)
   {
      x = x - 3;
      y = y - 3;

      return new Vector3(-sideSquare/2 + x * sideSquare, height,-sideSquare/2 + y * sideSquare);
   }
   
   public Vector3 GetPosition(Vector2Int newPos)
   {
      var x = newPos.x - 3;
      var y = newPos.y - 3;

      return new Vector3(-sideSquare/2 + x * sideSquare, height,-sideSquare/2 + y * sideSquare);
   }

   public HighLight SpawnHighLightBlue(int x, int y)
   {
      var blue = Instantiate(highLightBlue, GetPosition(x, y), Quaternion.identity, board);
      blue.Position = new Vector2Int(x, y);
      return blue;
   }
   public HighLight SpawnHighLightRed(int x, int y)
   {
      var red = Instantiate(highLightRed, GetPosition(x, y), Quaternion.identity, board);
      red.Position = new Vector2Int(x, y);
      return red;
   }
}

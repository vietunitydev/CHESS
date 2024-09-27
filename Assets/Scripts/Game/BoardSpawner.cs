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

   private List<ChessPieceBase> chesses;
   
   

   private void Start()
   {
      chesses = new List<ChessPieceBase>();
      GenerateBoard();
   }

   private void GenerateBoard()
   {
      Instantiate(KingBlack, GetPosition(5, 1), Quaternion.identity,board);
      Instantiate(QueenBlack, GetPosition(4, 1), Quaternion.identity,board);

      Instantiate(BishopBlack, GetPosition(3, 1), Quaternion.identity,board);
      Instantiate(BishopBlack, GetPosition(6, 1), Quaternion.identity,board);

      Instantiate(KnightBlack, GetPosition(2, 1), Quaternion.identity,board);
      Instantiate(KnightBlack, GetPosition(7, 1), Quaternion.identity,board);

      Instantiate(RookBlack, GetPosition(1, 1), Quaternion.identity,board);
      Instantiate(RookBlack, GetPosition(8, 1), Quaternion.identity,board);

      for (int i = 0; i < 8; i++)
      {
         Instantiate(PawnBlack, GetPosition(i + 1, 2), Quaternion.identity,board);
      }
      
      Instantiate(KingWhite, GetPosition(5, 8), Quaternion.identity,board);
      Instantiate(QueenWhite, GetPosition(4, 8), Quaternion.identity,board);

      Instantiate(BishopWhite, GetPosition(3, 8), Quaternion.identity,board);
      Instantiate(BishopWhite, GetPosition(6, 8), Quaternion.identity,board);

      Instantiate(KingWhite, GetPosition(2, 8), Quaternion.identity,board);
      Instantiate(KnightWhite, GetPosition(7, 8), Quaternion.identity,board);

      Instantiate(RookWhite, GetPosition(1, 8), Quaternion.identity,board);
      Instantiate(RookWhite, GetPosition(8, 8), Quaternion.identity,board);

      for (int i = 0; i < 8; i++)
      {
         Instantiate(PawnWhite, GetPosition(i + 1, 7), Quaternion.identity,board);
      }
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
}

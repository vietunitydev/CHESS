using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{
    public Vector2Int Position { get; set; }
    
    private void OnMouseDown()
    {
        Debug.Log($"--- (High Light) Clicked High Light to Move");
        BoardManager.Instance.MovePiece(Position);
    }

    
}

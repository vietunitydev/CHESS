using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{
    public Vector2Int Position { get; set; }
    
    private void OnMouseDown()
    {
        Debug.Log($"--- (High Light) Clicked to move");
        BoardManager.Instance.MovePiece(Position);
    }
}

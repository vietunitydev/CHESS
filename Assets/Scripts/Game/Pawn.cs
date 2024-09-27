using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPieceBase
{

    [SerializeField] private bool isFirstMove = true;
    public override List<Vector2Int> GetValidMoves(ChessPieceBase[,] board)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();
        // hướng đi 
        int direction = ColorType == ColorType.Black ? 1 : -1;

        // Vị trí hiện tại của quân tốt
        Vector2Int currentPosition = this.Position;

        // 1. Di chuyển 1 ô phía trước
        Vector2Int moveOneStep = new Vector2Int(currentPosition.x, currentPosition.y + direction);
        if (IsInsideBoard(moveOneStep) && board[moveOneStep.x, moveOneStep.y] == null)
        {
            Debug.Log($"--- (Pawn) add move 1 step forward");
            validMoves.Add(moveOneStep);
        }

        // 2. Di chuyển 2 ô nếu là nước đi đầu tiên
        if (isFirstMove)
        {
            Vector2Int moveTwoSteps = new Vector2Int(currentPosition.x, currentPosition.y + (2 * direction));
            Vector2Int moveOneStepAgain = new Vector2Int(currentPosition.x, currentPosition.y + direction);
            Debug.Log($"--- (Pawn) is first move");
            if (IsInsideBoard(moveTwoSteps) && board[moveTwoSteps.x, moveTwoSteps.y] == null && board[moveOneStepAgain.x, moveOneStepAgain.y] == null)
            {
                Debug.Log($"--- (Pawn) add move 2 step forward");
                validMoves.Add(moveTwoSteps);
            }
        }

        // // 3. Ăn quân chéo trái
        // Vector2Int leftDiagonal = new Vector2Int(currentPosition.x - 1, currentPosition.y + direction);
        // if (IsInsideBoard(leftDiagonal) && board[leftDiagonal.x, leftDiagonal.y] != null && board[leftDiagonal.x, leftDiagonal.y].ColorType != this.ColorType)
        // {
        //     validMoves.Add(leftDiagonal);
        // }
        //
        // // 4. Ăn quân chéo phải
        // Vector2Int rightDiagonal = new Vector2Int(currentPosition.x + 1, currentPosition.y + direction);
        // if (IsInsideBoard(rightDiagonal) && board[rightDiagonal.x, rightDiagonal.y] != null && board[rightDiagonal.x, rightDiagonal.y].ColorType != this.ColorType)
        // {
        //     validMoves.Add(rightDiagonal);
        // }
        
        return validMoves;
    }
    
    private bool IsInsideBoard(Vector2Int position)
    {
        // return position.x >= 0 && position.x < 8 && position.y >= 0 && position.y < 8;
        return true;
    }
}

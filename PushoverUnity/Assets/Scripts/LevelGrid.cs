using System;
using UnityEngine;

public class LevelGrid
{
       
    private static readonly float MaxNumberOfRows = 7f;
    private static readonly float MaxNumberOfColumns = 20f;
    
    // ReSharper disable once PossibleLossOfFraction
    private static readonly float RowSize = 0.9f;
    // ReSharper disable once PossibleLossOfFraction
    private static readonly float ColumnSize = 1.41f;
    
    private static LevelGrid _instance;
    public static LevelGrid instance
    {
        get { return _instance ??= new LevelGrid(); } 
    }

    private LevelGrid() {}
    
    public Vector2 Snap(Vector2 currentPosition, Camera camera)
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(currentPosition);
        
        float newX = Mathf.RoundToInt(screenPosition.x / ColumnSize) * ColumnSize;
        float newY = Mathf.RoundToInt(screenPosition.y / RowSize) * RowSize;
        
        // ReSharper disable once InvertIf
        if (Math.Abs(screenPosition.x - newX) > double.Epsilon || Math.Abs(screenPosition.y - newY) > double.Epsilon)
        {
            screenPosition.x = Mathf.RoundToInt(screenPosition.x / ColumnSize) * ColumnSize;
            screenPosition.y = Mathf.RoundToInt(screenPosition.y / RowSize) * RowSize;
            
            Debug.Log("I just snapped");
        }

        
        return camera.ScreenToWorldPoint(screenPosition);
    }
    
    private Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2(x * RowSize, y * ColumnSize);
    }
    
    public void DrawGrid()
    {
        for(var i=0; i < MaxNumberOfColumns; i++)
        {
            for(var j=0; j < MaxNumberOfRows; j++)
            {
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.red, 100f);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.green, 100f);
            }
        }
    }
}

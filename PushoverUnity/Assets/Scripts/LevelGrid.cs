using System;
using UnityEngine;

public class LevelGrid
{
    private static readonly float ScreenHeight = Screen.height;
    private static readonly float ScreenWidth = Screen.width;
        
    private static readonly int MaxNumberOfRows = 10;
    private static readonly int MaxNumberOfColumns = 20;
    private static readonly int RowSize = Mathf.RoundToInt(ScreenHeight / MaxNumberOfRows);
    private static readonly int ColumnSize = Mathf.RoundToInt(ScreenWidth / MaxNumberOfColumns);
    
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
}

using UnityEngine;

public class LevelGrid
{
    private static readonly float ScreenHeight = Screen.height;
    private static readonly float ScreenWidth = Screen.width;
        
    private static readonly int MaxNumberOfRows = 40;
    private static readonly int MaxNumberOfColumns = 40;
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

        screenPosition.x = Mathf.RoundToInt(screenPosition.x / ColumnSize) * ColumnSize;
        screenPosition.y = Mathf.RoundToInt(screenPosition.y / RowSize) * RowSize;
        
        return camera.ScreenToWorldPoint(screenPosition);
    }
}

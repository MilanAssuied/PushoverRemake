using UnityEngine;

public class LevelGrid
{
    private static readonly float _screenHeight = Screen.height;
    private static readonly float _screenWidth = Screen.width;
        
    private static readonly int _maxNumberOfRows = 10;
    private static readonly int _maxNumberOfColumns = 10;
    
    private static int _rowSize = Mathf.RoundToInt(_screenHeight / _maxNumberOfRows);
    private static int _columnSize = Mathf.RoundToInt(_screenWidth / _maxNumberOfColumns);
    
    private static LevelGrid _instance;
    public static LevelGrid instance
    {
        get { return _instance ??= new LevelGrid(); } 
    }

    private LevelGrid() {}
    
    public Vector2 Snap(Vector2 currentPosition, Camera camera)
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(currentPosition);

        screenPosition.x = Mathf.RoundToInt(screenPosition.x / _columnSize) * _columnSize;
        screenPosition.y = Mathf.RoundToInt(screenPosition.y / _rowSize) * _rowSize;
        
        return camera.ScreenToWorldPoint(screenPosition);
    }
}

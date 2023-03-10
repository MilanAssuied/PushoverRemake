using UnityEngine;

public class LevelGrid
{
       
    private static readonly int MaxNumberOfRows = 7;
    private static readonly int MaxNumberOfColumns = 20;
    
    // ReSharper disable once PossibleLossOfFraction
    private static readonly float RowSize = 0.9f;
    // ReSharper disable once PossibleLossOfFraction
    private static readonly float ColumnSize = 1.41f;
    
    private readonly Vector2[,] m_GridPoints = new Vector2[MaxNumberOfColumns,MaxNumberOfRows]; //TODO: Invert rows and colums
    
    private static LevelGrid _instance;
    public static LevelGrid instance
    {
        get { return _instance ??= new LevelGrid(); } 
    }

    private LevelGrid()
    {
        CreateGrid();
    }
    
    public Vector2 Snap(Vector2 currentPosition)
    {
        Vector2 closest = new Vector2(); 
        var diffMemory = float.MaxValue;
        
        foreach(var position in m_GridPoints)
        {
            var diff = (currentPosition-position).magnitude;
            if (diff < diffMemory)
            {
                closest = position;
                diffMemory = diff;
            }
            else
            {
                break;
            }
        }
        Debug.Log("I snapped");
        return closest;
    }
    
    private Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2(x * RowSize, y * ColumnSize);
    }
    
    public void CreateGrid()
    {
        for(var i=0; i < MaxNumberOfColumns; i++)
        {
            for(var j=0; j < MaxNumberOfRows; j++)
            {
                m_GridPoints[i,j] = GetWorldPosition(i,j);
            }
        }
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

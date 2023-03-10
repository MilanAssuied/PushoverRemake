using UnityEngine;
using System;

public class DominoPhysics : MonoBehaviour
{
    private readonly LevelGrid m_Grid = LevelGrid.instance;
    private Camera m_Camera;
    
    private void Awake()
    {
        m_Camera = Camera.main;
        if (m_Camera != null) m_Camera.transform.position = new Vector3(9, 5, -10);
        m_Grid.DrawGrid();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Left push");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Right push");
        }
        
        transform.position = m_Grid.Snap(transform.position);
    }
}

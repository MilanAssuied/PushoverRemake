using System;
using UnityEngine;

public class DominoPhysics : MonoBehaviour
{
    Rigidbody2D rigidBody;
    float thrust = 20f;
    
    private LevelGrid m_Grid = LevelGrid.instance;
    private Camera m_Camera;
    
    private void Awake()
    {
        m_Camera = Camera.main;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.bodyType = RigidbodyType2D.Static;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Invoke(nameof(ActivatePhysicsModel), 0.5f);
    }

    private void ActivatePhysicsModel()
    {
        if (rigidBody.bodyType == RigidbodyType2D.Static)
        {
            rigidBody.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    // Update is called once per frame
    void Update()
    {
        rigidBody.AddForce(transform.right * 0);

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Left push");
            rigidBody.AddForce(transform.right * -thrust);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Right push");
            rigidBody.AddForce(transform.right * thrust);
        }
        
        transform.position = m_Grid.Snap(transform.position, m_Camera);
    }
}

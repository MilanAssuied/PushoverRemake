using UnityEngine;

public class DominoPhysics : MonoBehaviour
{
    Rigidbody2D rigidBody;
    float thrust = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
    }
}

// Expose center of mass to allow it to be set from
// the inspector.
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    public Vector3 centerOfMass;
    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.centerOfMass = centerOfMass;
    }
}
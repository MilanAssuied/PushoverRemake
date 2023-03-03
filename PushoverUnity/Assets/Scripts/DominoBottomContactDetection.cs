using UnityEngine;

public class DominoBottomContactDetection : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
    }
}

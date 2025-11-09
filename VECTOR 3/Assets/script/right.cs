using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float speed = 0.01f;

    private void Update()
    {
        transform.Translate(Vector2.right * speed);
    }
}
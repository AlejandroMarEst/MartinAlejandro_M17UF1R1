using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    public float jumpHeight;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void MoveCharacter(Vector2 direction)
    {
        _rb.linearVelocity = direction * speed;
    }
    public void Jump()
    {
        Vector2 vector = new Vector2();
        vector.y = jumpHeight;
        _rb.linearVelocity += vector;
    }
}

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
        _rb.linearVelocity = new Vector2(direction.normalized.x * speed, _rb.linearVelocity.y);
    }
    public void Jump()
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpHeight);
    }
}

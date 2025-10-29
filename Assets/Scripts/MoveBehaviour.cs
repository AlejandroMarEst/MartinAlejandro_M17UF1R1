using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private AnimationController _anim;
    public float speed;
    public float jumpHeight;
    private bool isGrounded;
    private RaycastHit2D groundCheck;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<AnimationController>();
    }
    void FixedUpdate()
    {
        groundCheck = Physics2D.Raycast(_rb.position, Vector2.down, 1f);
        if (groundCheck.collider != null)
        {
            if (groundCheck.collider.name == "Ground")
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
            Debug.Log(groundCheck.collider.name);
            Debug.DrawRay(_rb.position, Vector2.down, Color.red);
        } else
        {
            isGrounded = false;
        }
    }
    public void MoveCharacter(Vector2 direction)
    {
        _rb.linearVelocity = new Vector2(direction.normalized.x * speed, _rb.linearVelocity.y);
        _anim.RunAnimation(direction);


    }
    public void Jump()
    {
        if (true)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpHeight);
        }
    }
}

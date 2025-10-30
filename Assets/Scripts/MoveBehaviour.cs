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
        groundCheck = Physics2D.Raycast(new Vector2(_rb.position.x, _rb.position.y - 0.7f), Vector2.down, 0.1f);
        if (groundCheck.collider != null && groundCheck.collider.gameObject.layer == 6)
        {
            if (!isGrounded)
            {
                _anim.LandAnimation();
            }
            isGrounded = true;
        } else
        {
            isGrounded = false;
            _anim.FallAnimation();
        }
        Debug.DrawRay(new Vector2(_rb.position.x, _rb.position.y - 0.7f), Vector2.down * 0.1f, Color.red);
    }
    public void MoveCharacter(Vector2 direction)
    {
        _rb.linearVelocity = new Vector2(direction.normalized.x * speed, _rb.linearVelocity.y);
        _anim.RunAnimation(direction);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpHeight);
            _anim.JumpAnimation();
        }
    }
}

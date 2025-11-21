using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private AnimationController _anim;
    public float speed;
    public float jumpHeight;
    private bool isGrounded;
    private bool isFlipped = false;
    private RaycastHit2D groundCheck;
    public LayerMask _ground;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<AnimationController>();
        isFlipped = _rb.transform.localScale.y < 0;
    }
    void FixedUpdate()
    {
        float raycastOffset = isFlipped ? -1.2f : 0.7f;
        groundCheck = Physics2D.Raycast(new Vector2(_rb.position.x, _rb.position.y - raycastOffset), -transform.up, 1f, _ground);
        if (groundCheck.collider != null)
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
        Debug.DrawRay(new Vector2(_rb.position.x, _rb.position.y - raycastOffset), -transform.up * 1f, Color.red);
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
    public void FlipGravity()
    {
        if (isGrounded)
        {
            _rb.gravityScale = -_rb.gravityScale;
            _rb.transform.localScale = new Vector3(_rb.transform.localScale.x, -_rb.transform.localScale.y, _rb.transform.localScale.z);
            isFlipped = !isFlipped;
            jumpHeight = -jumpHeight;
        }
    }
}

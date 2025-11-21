using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class Enemy : Character
{
    public float speed;
    private Vector2 direction;
    public LayerMask _ground;
    private bool groundForward;
    private bool wallCheck;
    public float maxTimeBetweenFlip;
    private float currentTimeBetweenFlip;
    private bool flipped;
    public bool flips = false;
    void Start()
    {
        currentTimeBetweenFlip = maxTimeBetweenFlip;
        direction = new Vector2(speed, 0);
        flipped = transform.localScale.y < 0;
    }
    void FixedUpdate()
    {
        float raycastOffsetX = direction.x < 0 ? -1.2f : 1.2f;
        float raycastOffsetY = flipped ? 1.2f : -0.5f;

        groundForward = Physics2D.Raycast(new Vector2(transform.position.x + raycastOffsetX, transform.position.y + raycastOffsetY), -transform.up, 2f, _ground);
        wallCheck = Physics2D.Raycast(new Vector2(transform.position.x + raycastOffsetX, transform.position.y), direction, 0.5f, _ground);
        if (groundForward)
        {
            _mb.MoveCharacter(direction);
        } else
        {
            ChangeDirection();
        }
        if (wallCheck)
        {
            ChangeDirection();
        }
        if (Time.time >= currentTimeBetweenFlip & flips)
        {
            _mb.FlipGravity();
            flipped = !flipped;
            currentTimeBetweenFlip += maxTimeBetweenFlip;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer ==   9 || collision.gameObject.layer == 10)
        {
            gameObject.SetActive(false);
        }
    }
    private void ChangeDirection()
    {
        direction *= -1;
    }
}

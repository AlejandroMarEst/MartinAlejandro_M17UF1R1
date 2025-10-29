using UnityEngine;
[RequireComponent(typeof(Animator))]

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void RunAnimation(Vector2 direction)
    {
        if (direction.x > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (direction.x < 0)
        {
            _spriteRenderer.flipX = false;
        }
        _animator.SetFloat("Velocity", direction.magnitude);
    }

    public void JumpAnimation()
    {
        _animator.SetBool("Jumping", true);
    }
}

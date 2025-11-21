using UnityEngine;
using UnityEngine.Windows;
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
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        } 
        else if (direction.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        _animator.SetFloat("Velocity", direction.magnitude);
    }

    public void JumpAnimation()
    {
        _animator.SetBool("Jumping", true);
    }
    public void FallAnimation()
    {
        _animator.SetBool("Jumping", false);
        _animator.SetBool("Falling", true);
    }
    public void LandAnimation()
    {
        _animator.SetBool("Falling", false);
        _animator.SetTrigger("Landing");
    }
    public void Respawn()
    {
        _animator.SetTrigger("Respawned");
    }
    public void DeadAnimation()
    {
        _animator.SetTrigger("Dying");
    }
}

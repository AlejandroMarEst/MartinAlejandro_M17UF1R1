using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : Character, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputAction;
    private Vector2 input;
    public GameObject spawnPoint;
    [SerializeField] private AudioSource audio;
    [SerializeField] private SoundManager sounds;
    private void Awake()
    {
        base.Awake();
        inputAction = new InputSystem_Actions();
        inputAction.Player.SetCallbacks(this);
    }

    void FixedUpdate()
    {
        _mb.MoveCharacter(input);
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }
    private void OnDisable()
    {
        inputAction.Disable();
    }

    // OnUserInput

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && _mb.isGrounded)
        {
            _mb.FlipGravity();
            audio.PlayOneShot(sounds.AudioDictionary[SoundManager.AudioClips.Flip]);
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && _mb.isGrounded)
        {
            _mb.Jump();
            audio.PlayOneShot(sounds.AudioDictionary[SoundManager.AudioClips.Jump]);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }
    public void StopPlayer()
    {
        inputAction.Disable();
    }
    public void ResumePlayer()
    {
        inputAction.Enable();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
        {
            audio.PlayOneShot(sounds.AudioDictionary[SoundManager.AudioClips.Death]);
            _mb.Respawn(spawnPoint.transform.position);
        }
    }
}

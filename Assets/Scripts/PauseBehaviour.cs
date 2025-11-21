using UnityEngine;
using UnityEngine.InputSystem;

public class PauseBehaviour : MonoBehaviour, InputSystem_Actions.IUIActions
{
    private InputSystem_Actions _actions;
    [SerializeField] private GameObject pauseMenu;
    private bool _paused = false;
    private void Awake()
    {
        _actions = new InputSystem_Actions();
        _actions.UI.SetCallbacks(this);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    private void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        _paused = true;
    }
    private void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        _paused = false;
    }
    private void OnEnable()
    {
        _actions.Enable();  
    }
    private void OnDisable()
    {
        _actions.Disable();
    }
    private void TogglePause()
    {
        if (!_paused)
            Pause();
        else
            Resume();
    }
    public void OnNextDialogue(InputAction.CallbackContext context)
    {
    }

    public void OnSkipDialogue(InputAction.CallbackContext context)
    {
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TogglePause();
        }
    }
}

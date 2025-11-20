using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour, InputSystem_Actions.IUIActions
{
    [SerializeField] private List<string> dialogues;
    [SerializeField] private DialogueBehaviour diagBehaviour;
    [SerializeField] private Player player;
    private InputSystem_Actions inputAction;
    private int _currentDiag = 0;
    private bool _inDiag = false;
    private bool _nextDiag = false;
    private bool _activated = false;
    private bool _skipped = false;
    void Start()
    {
        inputAction = new InputSystem_Actions();
        inputAction.UI.SetCallbacks(this);
        inputAction.Disable();
    }
    void Update()
    {
        if (_inDiag)
        {
            player.StopPlayer();
            diagBehaviour.WriteDialogue(dialogues[_currentDiag]);
            if (_skipped)
            {
                diagBehaviour.CloseDialogue();
                player.ResumePlayer();
                _inDiag = false;
                inputAction.Disable();
            }
            if (_nextDiag && _currentDiag + 1 < dialogues.Count)
            {
                _currentDiag++;
                _nextDiag = false;
            }
            else if (_nextDiag && _currentDiag + 1 == dialogues.Count )
            {
                diagBehaviour.CloseDialogue();
                player.ResumePlayer();
                _inDiag = false;
                inputAction.Disable();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 && _activated == false)
        {
            _inDiag = true;
            _activated = true;
            inputAction.Enable();
        }
    }
    public void OnNextDialogue(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _nextDiag = true;
        }
    }
    public void OnSkipDialogue(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _skipped= true;
        }
    }
}

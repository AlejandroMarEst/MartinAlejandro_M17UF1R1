using TMPro;
using UnityEngine;

public class DialogueBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject TextBox;
    [SerializeField] private TextMeshProUGUI dialogue;
    [SerializeField] private GameObject portrait;
    private void Awake()
    {
        CloseDialogue();
    }
    public void WriteDialogue(string message)
    {
        portrait.SetActive(true);
        TextBox.SetActive(true);
        dialogue.text = message;
    }
    public void CloseDialogue()
    {
        portrait.SetActive(false);
        TextBox.SetActive(false);
        dialogue.text = "";
    }
}

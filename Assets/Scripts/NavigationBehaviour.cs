using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationBehaviour : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }
}

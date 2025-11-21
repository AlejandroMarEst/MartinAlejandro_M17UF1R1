using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField] private NavigationBehaviour gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            gameManager.FinishGame();
        }
    }
}

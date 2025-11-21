using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 _direction;
    public Spawner spawner;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            spawner.stack.Push(gameObject);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.layer == 7)
        {
            spawner.stack.Push(gameObject);
            gameObject.SetActive(false);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject target;
    public Stack<GameObject> stack = new Stack<GameObject>();
    private Vector2 distanceToSpawnerTarget;
    private float maxTimeBetweenShots;
    private float currentTimeShots;
    private float ang;
    void Start()
    {
        maxTimeBetweenShots = 1.5f;
        currentTimeShots = maxTimeBetweenShots;
        distanceToSpawnerTarget = target.transform.position - transform.position;
        ang = (Mathf.Atan2(distanceToSpawnerTarget.y, distanceToSpawnerTarget.x) * 180f / Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= currentTimeShots)
        {
            if (stack.Count == 0)
            {
                GameObject enem = Instantiate(projectile, transform.position, Quaternion.identity);
                enem.GetComponent<Rigidbody2D>().linearVelocity = distanceToSpawnerTarget;
                enem.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, ang);
                enem.GetComponent<Bullet>()._direction = distanceToSpawnerTarget;
                enem.GetComponent<Bullet>().spawner = this;

            } else
            {
                GameObject bull = stack.Pop();
                bull.SetActive(true);
                bull.transform.position = transform.position;
                bull.GetComponent<Rigidbody2D>().linearVelocity = distanceToSpawnerTarget;
            }
            Debug.Log(distanceToSpawnerTarget);
                currentTimeShots += maxTimeBetweenShots;
        }
    }
}

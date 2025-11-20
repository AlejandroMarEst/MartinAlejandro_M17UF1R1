using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;
    public GameObject camera;
    public float parallax;
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void FixedUpdate()
    {
        float dist = (camera.transform.position.x * parallax);
        transform.position = new Vector3(startPos + dist, camera.transform.position.y, transform.position.z);
        
    }
}

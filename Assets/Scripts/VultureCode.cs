using UnityEngine;

public class VultureCode : MonoBehaviour
{
    public float maxPosition = 1.0f;
    public float minPosition = -2.0f;

    Vector3 direction = new Vector3(0.0f, 0.01f, 0.0f);

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y > maxPosition)
        {
            direction = new Vector3(0.0f, -0.01f, 0.0f);
        }
        if (transform.position.y < minPosition)
        {
            direction = new Vector3(0.0f, 0.01f, 0.0f);
        }

        transform.position += direction;
    }
}

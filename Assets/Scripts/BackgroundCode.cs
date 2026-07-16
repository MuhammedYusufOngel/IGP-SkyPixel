using UnityEngine;

public class BackgroundCode : MonoBehaviour
{
    public Transform _cameraTransform;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, _cameraTransform.position.y, 0.0f);
    }
}

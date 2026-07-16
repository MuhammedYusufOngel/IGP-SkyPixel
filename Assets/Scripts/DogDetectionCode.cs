using UnityEngine;

public class DogDetectionCode : MonoBehaviour
{
    private DogCode _dog;
    void Start()
    {
        _dog = GetComponentInParent<DogCode>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _dog.isAware = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _dog.isAware = false;
        }
    }

    void Update()
    {
        
    }
}

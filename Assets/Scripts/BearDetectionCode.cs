using UnityEngine;

public class BearDetectionCode : MonoBehaviour
{
    private BearCode _bear;

    void Start()
    {
        _bear = GetComponentInParent<BearCode>();   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _bear.isAware = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _bear.isAware = false;
        }
    }

    void Update()
    {
        
    }
}

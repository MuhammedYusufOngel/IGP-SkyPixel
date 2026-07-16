using UnityEngine;

public class GemCode : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            ScoreManager._instance.AddScore_Diamond();
        }
    }

    void Update()
    {
        
    }
}

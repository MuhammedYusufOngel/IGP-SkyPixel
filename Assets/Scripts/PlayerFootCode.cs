using UnityEngine;

public class PlayerFootCode : MonoBehaviour
{
    Rigidbody2D _rb;
    public GameObject _death;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Up" && _rb.linearVelocityY < -0.001f)
        {
            Instantiate(_death).transform.position = collision.transform.parent.position;
            Debug.Log("Çarpışma gerçekleşti::collision.transform.parent.position: " + collision.transform.parent.position);
            collision.transform.parent.gameObject.SetActive(false);
            //Destroy(collision.transform.parent.gameObject);
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 5);
            ScoreManager._instance.AddScore_Enemy();
            Destroy(_death);
        }
    }
    void Start()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

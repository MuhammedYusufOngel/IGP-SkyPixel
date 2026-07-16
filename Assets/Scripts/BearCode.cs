using UnityEngine;

public class BearCode : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;

    public Transform _playerTransform;

    public float maxPosition;
    public float minPosition;

    public float _velocity;
    public bool isAware;

    Vector3 direction;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        direction = new Vector3(_velocity, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction;

        if (isAware)
        {
            if (_playerTransform.position.x - transform.position.x > 0)
            {
                direction = new Vector3(_velocity * 2, 0.0f, 0.0f);

                _spriteRenderer.flipX = false;
            }
            else
            {
                direction = new Vector3(-_velocity * 2, 0.0f, 0.0f);

                _spriteRenderer.flipX = true;
            }
        }
        else
        {
            if (transform.position.x - maxPosition > 0)
            {
                direction = new Vector3(-_velocity, 0.0f, 0.0f);
                _spriteRenderer.flipX = true;
                return;
            }

            if (transform.position.x - minPosition < 0)
            {
                direction = new Vector3(_velocity, 0.0f, 0.0f);
                _spriteRenderer.flipX = false;
                return;
            }
        }
    }
}

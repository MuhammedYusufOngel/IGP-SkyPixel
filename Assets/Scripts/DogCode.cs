using UnityEngine;

public class DogCode : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rb;
    public Transform _playerTransform;
    SpriteRenderer _spriteRenderer;

    public bool isAware;
    public float _velocity;
    float elapsedTime = 0.0f;

    void Start()    
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        isAware = false;
    }
    void Update()
    {
        if(transform.position.y < -30.0f)
        {
            transform.gameObject.SetActive(false);
            ScoreManager._instance.AddScore_Enemy();
        }

        if (isAware)
        {
            elapsedTime += Time.deltaTime;

            _animator.SetBool("isRunning", true);
            
            if(_playerTransform.position.x - transform.position.x > 0.0f)
            {
                _rb.AddForce(Vector2.right * _velocity / 100, ForceMode2D.Impulse);
                
                if(elapsedTime > 3.0f)
                {
                    _rb.AddForce(Vector2.right * _velocity, ForceMode2D.Impulse);
                    elapsedTime = 0.0f;
                }
                _spriteRenderer.flipX = true;
            }
            else
            {
                _rb.AddForce(Vector2.left * _velocity / 100, ForceMode2D.Impulse);

                if (elapsedTime > 2.0f)
                {
                    _rb.AddForce(Vector2.left * _velocity, ForceMode2D.Impulse);
                    elapsedTime = 0.0f;
                }
                _spriteRenderer.flipX = false;
            }

            elapsedTime = 0.0f;
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }
}

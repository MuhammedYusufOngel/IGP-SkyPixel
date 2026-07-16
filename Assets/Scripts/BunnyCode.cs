using UnityEngine;

public class BunnyCode : MonoBehaviour
{
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rb;
    float elapsedTime = 0.0f;
    int counter = 0;
    Vector2 direction = Vector2.right;

    public LayerMask _groundMask;

    [SerializeField]
    Transform _transformForGroundControl;

    [SerializeField]
    float _jumpingVelocity = 100.0f;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > 2.0f)
        {
            counter++;
            _rb.AddForce(Vector2.up * _jumpingVelocity, ForceMode2D.Impulse);

            Debug.Log("counter: " + counter);

            if (counter == 3)
            {
                direction = Vector2.left;
                _spriteRenderer.flipX = true;
            }
            if(counter == 5)
            {
                direction = Vector2.right;
                _spriteRenderer.flipX = false;
                counter = 1;
            }

            _rb.AddForce(direction * _jumpingVelocity, ForceMode2D.Impulse);
            elapsedTime = 0.0f;
        }

        JumpingControl();
    }

    void JumpingControl()
    {
        float y = _rb.linearVelocityY;

        //Debug.Log("_rb.linearVelocityY: " + y);

        if (y > 0.001f)
        {
            _animator.SetBool("isJumping", true);
            _animator.SetBool("isFalling", false);
        }
        else if (y < -0.001f && !GroundControl())
        {
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isFalling", true);
        }
        else
        {
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isFalling", false);
        }
    }

    bool GroundControl()
    {
        return Physics2D.OverlapCircle(_transformForGroundControl.position, 0.2f, _groundMask);
    }
}

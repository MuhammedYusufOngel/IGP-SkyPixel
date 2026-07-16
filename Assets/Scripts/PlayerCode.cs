using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    public Rigidbody2D _rb;
    public LayerMask _groundMask;

    [SerializeField]
    Transform _transformForGroundControl;


    [SerializeField] 
    float _velocity = 2.0f;
    [SerializeField]
    float _jumpVelocity;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_transformForGroundControl.position, 0.2f);
    }

    void Update()
    {
        _animator.SetBool("isOnGround", GroundControl());

        float x = Input.GetAxisRaw("Horizontal");

        if(x > 0.0f)
        {
            _rb.linearVelocity = new Vector2(_velocity, _rb.linearVelocityY);
            _spriteRenderer.flipX = false;
            _animator.SetBool("isWalking", true);
        }
        else if(x < 0.0f)
        {
            _rb.linearVelocity = new Vector2(-_velocity, _rb.linearVelocityY);
            _spriteRenderer.flipX = true;
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _rb.linearVelocity = new Vector2(0, _rb.linearVelocityY);
            _animator.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && GroundControl())
        {
            _rb.AddForce(Vector2.up * _jumpVelocity, ForceMode2D.Impulse);
        }

        JumpingControl();
    }

    void JumpingControl()
    {
        float y = _rb.linearVelocityY;

        if (y > 0.001f)
        {
            _animator.SetBool("isJumping", true);
            _animator.SetBool("isFalling", false);
        }
        else if (y < -0.001f)
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

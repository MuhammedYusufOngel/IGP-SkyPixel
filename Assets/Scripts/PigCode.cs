using UnityEngine;

public class PigCode : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;

    public float maxPosition = -27.0f;
    public float minPosition = -37.0f;

    Vector3 direction = new Vector3(0.01f, 0.0f, 0.0f);

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction;

        if (transform.position.x - maxPosition > 0)
        {
            direction = new Vector3(-0.01f, 0.0f, 0.0f);
            _spriteRenderer.flipX = true;
            return;
        }

        if (transform.position.x - minPosition < 0)
        {
            direction = new Vector3(0.01f, 0.0f, 0.0f);
            _spriteRenderer.flipX = false;
            return;
        }

    }
}

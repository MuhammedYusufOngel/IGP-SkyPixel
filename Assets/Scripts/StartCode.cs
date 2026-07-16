using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartCode : MonoBehaviour
{
    public float _velocity = 5.0f;

    void Start()
    {

    }
    void Update()
    {
        transform.position -= new Vector3(_velocity * Time.deltaTime, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }
}

using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHitboxCode : MonoBehaviour
{
    int health = 5;
    public Image[] _hearts;
    public GameObject _death;
    Rigidbody2D _rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(_death).transform.position = collision.gameObject.transform.position;
            health--;

            _hearts[health].enabled = false;

            if (health <= 0)
                transform.parent.gameObject.SetActive(false);
        }
    }
    void Start()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
    }

    public void SavePlayer()
    {
        int score = ScoreManager._instance.GetScore();
        SaveSystem.SavePlayer(health, transform.parent.position, score, transform.parent.gameObject.activeSelf, SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer(SceneManager.GetActiveScene().buildIndex);

        this.health = data.health;

        for(int i = health; i < 5; i++)
        {
            _hearts[i].enabled = false;
        }

        for (int i = 0; i < health; i++)
        {
            _hearts[i].enabled = true;
        }

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.parent.position = position;
        transform.parent.gameObject.SetActive(data.isDead);
        ScoreManager._instance.SetScore(data.score);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            SavePlayer();
        }

        if(Input.GetKey(KeyCode.R))
        {
            LoadPlayer();
        }

        if(Input.GetKey(KeyCode.L))
        {
            SceneManager.LoadScene(1);
        }
    }
}

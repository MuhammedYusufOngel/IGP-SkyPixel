using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager _instance;
    int _score;
    public TMP_Text _scoreText;

    private void Awake()
    {
        if( _instance == null )
            _instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        
    }

    public void AddScore_Diamond()
    {
        _score += 10;
        _scoreText.text = "Puan: " + _score.ToString();
    }

    public void AddScore_Enemy()
    {
        _score += 10;
        _scoreText.text = "Puan: " + _score.ToString();
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int score)
    {
        _score = score;
        _scoreText.text = "Puan: " + _score.ToString();
    }
    void Update()
    {
    }
}

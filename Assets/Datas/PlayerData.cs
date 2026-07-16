using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public float[] position;
    public int score;
    public bool isDead;

    public PlayerData(int health, float x, float y, float z, int score, bool isDead)
    {
        this.health = health;
        this.position = new float[3];
        this.position[0] = x;
        this.position[1] = y;
        this.position[2] = z;
        this.score = score;
        this.isDead = isDead;
    }

    public PlayerData()
    {
        this.health = 5;
        this.position = new float[3];
        this.position[0] = 0;
        this.position[1] = 0;
        this.position[2] = 0;
        this.score = 0;
    }
}

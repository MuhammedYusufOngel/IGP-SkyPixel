using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public bool isDead;
    public float[] position;

    public EnemyData(bool isDead, float x, float y, float z)
    {
        this.isDead = isDead;
        position = new float[3];
        position[0] = x;
        position[1] = y;
        position[2] = z;
    }
}

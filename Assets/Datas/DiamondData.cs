using UnityEngine;

[System.Serializable]
public class DiamondData
{
    public float[] position;
    public bool activeSelf;

    public DiamondData(float x, float y, float z, bool activeSelf)
    {
        position = new float[3];
        position[0] = x;
        position[1] = y;
        position[2] = z;
        this.activeSelf = activeSelf;
    }
}

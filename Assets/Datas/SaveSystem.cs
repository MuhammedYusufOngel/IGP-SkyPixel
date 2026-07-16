using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayer(int health, Vector3 position, int score, bool isDead, int bolum)
    {
        BinaryFormatter _formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player_" + bolum + ".data";

        using(FileStream file = new FileStream(path, FileMode.Create))
        {
            PlayerData playerData = new PlayerData(health, position.x, position.y, position.z, score, isDead);
            _formatter.Serialize(file, playerData);
        }
    }
    public static void SaveEnemies(bool[] isDeads, Vector3[] positions, int bolum)
    {
        BinaryFormatter _formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/enemies_" + bolum + ".data";

        using (FileStream file = new FileStream(path, FileMode.Create))
        {
            if(isDeads.Length == positions.Length)
            {
                List<EnemyData> enemies = new List<EnemyData>();

                for (int i = 0; i < isDeads.Length; i++)
                {
                    enemies.Add(new EnemyData(
                        isDeads[i],
                        positions[i].x,
                        positions[i].y,
                        positions[i].z
                    ));

                    //Debug.Log("Düşmanlar kaydediliyor::position(" + positions[i].x + ", " + positions[i].y + ", " + positions[i].z + ")");
                }

                _formatter.Serialize(file, enemies);
            }
        }
    }
    public static void SaveGems(bool[] activeSelfs, Vector3[] positions, int bolum)
    {
        BinaryFormatter _formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gems_" + bolum + ".data";

        using (FileStream file = new FileStream(path, FileMode.Create))
        {
            Debug.Log("Toplam Ödül Sayısı: " + activeSelfs.Length);
            Debug.Log("Toplam Ödül Sayısı: " + positions.Length);
            if (activeSelfs.Length == positions.Length)
            {
                List<DiamondData> gems = new List<DiamondData>();

                for (int i = 0; i < activeSelfs.Length; i++)
                {
                    gems.Add(new DiamondData(
                        positions[i].x,
                        positions[i].y,
                        positions[i].z,
                        activeSelfs[i]
                    ));

                    Debug.Log("Ödüller kaydediliyor::position(" + positions[i].x + ", " + positions[i].y + ", " + positions[i].z + ")");
                }

                _formatter.Serialize(file, gems);
            }
        }
    }
    
    public static PlayerData LoadPlayer(int bolum)
    {
        string path = Application.persistentDataPath + "/player_" + bolum + ".data";
        if (File.Exists(path))
        {
            BinaryFormatter _formatter = new BinaryFormatter();

            using(FileStream file = new FileStream(path, FileMode.Open))
            {
                PlayerData playerData = _formatter.Deserialize(file) as PlayerData;
                return playerData;
            }
        }
        else
        {
            Debug.LogError("Kaydedilen bir dosya bulunamadı..." + path);
            return null;
        }
    }
    public static List<EnemyData> LoadEnemies(int bolum)
    {
        List<EnemyData> enemies;
        string path = Application.persistentDataPath + "/enemies_" + bolum + ".data";
        if (File.Exists(path))
        {
            BinaryFormatter _formatter = new BinaryFormatter();

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                enemies = (List<EnemyData>)_formatter.Deserialize(file);
                return enemies;
            }
        }
        else
        {
            Debug.LogError("Kaydedilen bir dosya bulunamadı..." + path);
            return null;
        }
    }
    public static List<DiamondData> LoadGems(int bolum)
    {
        List<DiamondData> gems;
        string path = Application.persistentDataPath + "/gems_" + bolum + ".data";
        if (File.Exists(path))
        {
            BinaryFormatter _formatter = new BinaryFormatter();

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                gems = (List<DiamondData>)_formatter.Deserialize(file);
                return gems;
            }
        }
        else
        {
            Debug.LogError("Kaydedilen bir dosya bulunamadı..." + path);
            return null;
        }
    }
}

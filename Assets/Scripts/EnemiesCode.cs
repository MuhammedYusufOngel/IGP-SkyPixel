using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesCode : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            int numberOfEnemies = transform.childCount;

            bool[] isDeads = new bool[numberOfEnemies];
            Vector3[] positions = new Vector3[numberOfEnemies];

            for (int i = 0; i < numberOfEnemies; i++)
            {
                Transform childTransform = transform.GetChild(i);

                positions[i] = childTransform.position;
                isDeads[i] = childTransform.gameObject.activeSelf;
            }

            SaveSystem.SaveEnemies(isDeads, positions, SceneManager.GetActiveScene().buildIndex);
        }

        if(Input.GetKey(KeyCode.R))
        {
            List<EnemyData> enemies = SaveSystem.LoadEnemies(SceneManager.GetActiveScene().buildIndex);

            int i = 0;
            foreach (Transform child in transform)
            {
                Vector3 position;
                position.x = enemies[i].position[0];
                position.y = enemies[i].position[1];
                position.z = enemies[i].position[2];

                child.position = position;
                child.gameObject.SetActive(enemies[i].isDead);
                i++;
            }
        }
    }
}

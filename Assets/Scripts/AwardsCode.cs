using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AwardsCode : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            int numberOfGems = transform.childCount;

            bool[] activeSelfs = new bool[numberOfGems];
            Vector3[] positions = new Vector3[numberOfGems];

            for (int i = 0; i < numberOfGems; i++)
            {
                Transform childTransform = transform.GetChild(i);

                positions[i] = childTransform.position;
                activeSelfs[i] = childTransform.gameObject.activeSelf;
            }

            SaveSystem.SaveGems(activeSelfs, positions, SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey(KeyCode.R))
        {
            
            List<DiamondData> gems = SaveSystem.LoadGems(SceneManager.GetActiveScene().buildIndex);

            int i = 0;
            foreach (Transform child in transform)
            {
                Vector3 position;
                position.x = gems[i].position[0];
                position.y = gems[i].position[1];
                position.z = gems[i].position[2];

                child.position = position;
                child.gameObject.SetActive(gems[i].activeSelf);
                i++;
            }
        }
    }
}

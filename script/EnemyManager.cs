using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab; // 出現させたいEnemyプレハブ
    public Vector2 spawnAreaMin = new Vector2(-33, 5);
    public Vector2 spawnAreaMax = new Vector2(-25, 7);

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        int enemyCount = Random.Range(1, 4); // 1～6体

        for (int i = 0; i < enemyCount; i++)
        {
            float x = Random.Range(-33.8f, -25.8f);
            float y = Random.Range(9.0f,16.0f);
            Vector3 spawnPos = new Vector3(x, y, 0);

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}

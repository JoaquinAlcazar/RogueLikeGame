using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; 
    public int minEnemies = 2;
    public int maxEnemies = 4;

    public Vector2 spawnAreaMin; 
    public Vector2 spawnAreaMax; 

    private bool hasSpawned = false;

    private RoomController parentRoom;

    void Awake()
    {
        if (parentRoom == null)
        {
            parentRoom = GetComponentInParent<RoomController>();
        }
    }

    public void TrySpawn()
    {
        if (!hasSpawned && parentRoom != null && parentRoom.playerInside)
        {
            SpawnEnemies();
            hasSpawned = true;
        }
    }

    public void SpawnEnemies()
    {
        if (hasSpawned) return;

        int enemiesToSpawn = Random.Range(minEnemies, maxEnemies + 1);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPos = parentRoom.transform.position + new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                0f);

            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, Quaternion.identity, parentRoom.transform);
        }

        hasSpawned = true;
    }

}

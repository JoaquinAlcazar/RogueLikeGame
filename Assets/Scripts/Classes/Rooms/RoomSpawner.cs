using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject emptyRoomPrefab;  // Prefab de sala vacía
    public GameObject bossRoomPrefab;   // Prefab de sala jefe

    public int numberOfRoomsToSpawn = 10; // Total de salas, incluyendo boss

    public float roomWidth = 16f;
    public float roomHeight = 9f;

    private Dictionary<Vector2Int, RoomController> spawnedRooms = new Dictionary<Vector2Int, RoomController>();

    private bool bossPlaced = false;

    private void Start()
    {
        SpawnRooms();
    }

    void SpawnRooms()
    {
        Vector2Int startRoomPos = Vector2Int.zero;

        SpawnRoom(startRoomPos, false);

        Vector2Int[] directions = new Vector2Int[]
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };

        int roomsSpawned = 1; 
        Queue<Vector2Int> positionsToCheck = new Queue<Vector2Int>();
        positionsToCheck.Enqueue(startRoomPos);

        while (roomsSpawned < numberOfRoomsToSpawn && positionsToCheck.Count > 0)
        {
            Vector2Int currentPos = positionsToCheck.Dequeue();

            Shuffle(directions);

            foreach (Vector2Int dir in directions)
            {
                Vector2Int newPos = currentPos + dir;

                if (!spawnedRooms.ContainsKey(newPos))
                {
                    bool spawnBoss = false;

                    if (!bossPlaced && roomsSpawned == numberOfRoomsToSpawn - 1)
                    {
                        spawnBoss = true;
                        bossPlaced = true;
                    }

                    SpawnRoom(newPos, spawnBoss);
                    positionsToCheck.Enqueue(newPos);
                    roomsSpawned++;

                    if (roomsSpawned >= numberOfRoomsToSpawn)
                        break;
                }
            }
        }
    }

    void SpawnRoom(Vector2Int gridPos, bool isBoss)
    {
        Vector3 worldPos = new Vector3(gridPos.x * roomWidth, gridPos.y * roomHeight, 0f);
        GameObject prefabToSpawn = isBoss ? bossRoomPrefab : emptyRoomPrefab;

        GameObject roomInstance = Instantiate(prefabToSpawn, worldPos, Quaternion.identity);
        RoomController roomController = roomInstance.GetComponent<RoomController>();

        if (roomController != null)
        {
            spawnedRooms.Add(gridPos, roomController);
            roomController.isBossRoom = isBoss; 
        }
        else
        {
        }
    }

    void Shuffle(Vector2Int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int rnd = Random.Range(i, array.Length);
            Vector2Int temp = array[rnd];
            array[rnd] = array[i];
            array[i] = temp;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public List<AEnemy> enemiesInRoom = new List<AEnemy>();
    public Transform cameraTarget;
    public bool isBossRoom = false;

    public bool playerInside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !playerInside)
        {
            playerInside = true;
            ActivateSpawners();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerInside)
        {
            playerInside = false;
        }
    }

    void ActivateSpawners()
    {
        Debug.Log($"Activating spawners in room {gameObject.name}");

        EnemySpawner[] spawners = GetComponentsInChildren<EnemySpawner>();
        foreach (var spawner in spawners)
        {
            Debug.Log($"Calling TrySpawn() on spawner in {gameObject.name}");
            spawner.TrySpawn();
        }
    }


    public void OnRoomEntered()
    {
    }

    public void OnRoomExited()
    {
    }
}

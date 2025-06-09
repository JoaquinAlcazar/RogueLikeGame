using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoorTrigger : MonoBehaviour
{
    public RoomController parentRoom; // la sala que contiene esta puerta

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El jugador ha entrado en esta sala
            RoomManager.Instance.SetCurrentRoom(parentRoom);
        }
    }
}

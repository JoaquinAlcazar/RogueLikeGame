using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance { get; private set; }

    private RoomController currentRoom;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetCurrentRoom(RoomController newRoom)
    {
        if (currentRoom != null)
        {
            currentRoom.OnRoomExited();
        }

        currentRoom = newRoom;

        if (currentRoom != null)
        {
            currentRoom.OnRoomEntered();

            if (Camera.main != null)
            {
                CameraController cameraController = Camera.main.GetComponent<CameraController>();
                if (cameraController != null && currentRoom != null)
                {
                    cameraController.SetTarget(currentRoom.cameraTarget);
                }
            }

        }
    }

    public RoomController GetCurrentRoom()
    {
        return currentRoom;
    }

}

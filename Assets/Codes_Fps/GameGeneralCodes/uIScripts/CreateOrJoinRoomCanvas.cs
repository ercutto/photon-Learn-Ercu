using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;

    [SerializeField]
    private RoomListingMenu _roomListingMenu;
    private RoomsCanvases _roomsCanvases;
    public void FirstInitialize(RoomsCanvases canvasses)
    {
        _roomsCanvases = canvasses;
        _createRoomMenu.FirstInitialize(canvasses);
        _roomListingMenu.FirstInitialize(canvasses);
    }
}

﻿using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public RoomInfo RoomInfo { get; private set;}

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        _text.text = roomInfo.Name + " : " + roomInfo.MaxPlayers;
    }
    public void SetFakeRoomInfo(string name, int players)
    {
        _text.text = name + " : " + players;
    }

}

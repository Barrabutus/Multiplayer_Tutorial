using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public Text txt; 

    void Start()
    {
        SetRoomName();
    }

    public void SetRoomName()
    {
        txt.text = PhotonNetwork.CurrentRoom.Name;
    }


}

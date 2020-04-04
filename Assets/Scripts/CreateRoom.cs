using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    public Text txt; 

    public DebugConsole _console;

    public bool _allowEmptyRooms;

    public void OnClickCreateRoom()
    {
        if(_allowEmptyRooms)
        {
            PhotonNetwork.CreateRoom(txt.text.ToUpper(), new RoomOptions{EmptyRoomTtl = 3000, MaxPlayers = Convert.ToByte(UnityEngine.Random.Range(2, 20)) });
        }else{
            PhotonNetwork.CreateRoom(txt.text.ToUpper(), new RoomOptions{MaxPlayers = Convert.ToByte(UnityEngine.Random.Range(2, 20)) });
        }

    }

    public override void OnCreatedRoom()
    {

        _console.AddText("Room Created!...");

    }
    
}

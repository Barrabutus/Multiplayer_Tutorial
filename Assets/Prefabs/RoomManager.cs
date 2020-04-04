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


    // public void OnClickCreateRoom()
    // {

    //     PhotonNetwork.CreateRoom(txt.text, new RoomOptions{EmptyRoomTtl = 3000, MaxPlayers = Convert.ToByte(UnityEngine.Random.Range(2, 20)) });

    // }
    
}

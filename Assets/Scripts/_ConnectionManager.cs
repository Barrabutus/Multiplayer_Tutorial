using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class _ConnectionManager : MonoBehaviourPunCallbacks
{

    public string namePrefix;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Joined Master....Going to lobby");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("We have joined the lobby getting list of rooms....");
        //Append a random number to a name so we can identify the user in the room scene.
        PhotonNetwork.NickName = namePrefix+Random.Range(0000,99999);
        Debug.Log("Welcome " + PhotonNetwork.NickName);
    }
}

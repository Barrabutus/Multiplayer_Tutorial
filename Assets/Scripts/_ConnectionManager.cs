using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class _ConnectionManager : MonoBehaviourPunCallbacks
{

    public string namePrefix;
    private static bool isConnected;

    public string playerName;

    public _ConnectionManager instance;
    public _ChatManager chatManager;


    void Start()
    {   
        instance = this;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        isConnected = true;
        Debug.Log("Joined Master....Going to lobby");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("We have joined the lobby getting list of rooms....");
        //Append a random number to a name so we can identify the user in the room scene.
        this.playerName = namePrefix+Random.Range(0000,99999);
        PhotonNetwork.NickName = this.playerName;
        Debug.Log("Welcome " + PhotonNetwork.NickName);
    }

    public string GetPlayerName()
    {
        return this.playerName;
    }


}

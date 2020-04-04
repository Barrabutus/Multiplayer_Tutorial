using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Connection : MonoBehaviourPunCallbacks
{

    public DebugConsole _console;

    // Start is called before the first frame update
    void Start()
    {
        _console.AddText("Connecting...");
        PhotonNetwork.ConnectUsingSettings();
        
        
    }
    public override void OnConnectedToMaster()
    {
        _console.AddText("Connected to master");
        PhotonNetwork.JoinLobby();

    }
    public override void OnJoinedLobby()
    {
        _console.AddText("Connected to lobby");
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}

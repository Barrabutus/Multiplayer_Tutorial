using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Photon.Chat;
using System;
using UnityEngine.EventSystems;





public class _LobbyManager : MonoBehaviourPunCallbacks
{
        public Transform userPanel;
        public Transform listingsPanel;
        public GameObject listingPrefab;
        [Header("Room Creation Settings")]
        public Text roomName;
        public Text username;
    
        public List<String> currentRoomList = new List<string>();
        public _ChatManager chatManager;
        public _ConnectionManager connectionManager;

    private void Awake() {
        
       
        chatManager = GameObject.Find("ChatManager").GetComponent<_ChatManager>();
        connectionManager = GameObject.Find("ConnectionManager").GetComponent<_ConnectionManager>();
        
    }

    private void Start() {

        JoinChat();
        Debug.Log("Welcome to the lobby " + PhotonNetwork.NickName);

    }
    public void JoinChat()
    {
        chatManager.ConnectToChatServer();
        //chatManager.SetChatClientName();

    }

    public void OnClickCreateRoom()
    {
        // byte players = Convert.ToByte(playerAmt.value+1);
        PhotonNetwork.CreateRoom(roomName.text, new RoomOptions{EmptyRoomTtl = 3000, MaxPlayers = Convert.ToByte(2) });
        //Automatically Sync the scene across users so all users are on the same "page" and seeing t he same thing.
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel("GameScene2");
        
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed " + message);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("ROOM Created OK");
    }

    public void OnClickJoinRoom(string roomname)
    {          
        Debug.Log(roomname);
        PhotonNetwork.JoinRoom(roomname);
        PhotonNetwork.LoadLevel("GameScene2");       
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //Did the OnRoomListUpdate actually occur??
        Debug.Log("FIRED");
        foreach(RoomInfo info in roomList)
        {
            //If the room does not exist we create a button for it.
            if(!currentRoomList.Contains(info.Name))
            {
                CreateNewRoomListItem(info);
            }else if(currentRoomList.Contains(info.Name))
            {
                UpdateRoomListItem(info);
            }         
        }
    }

    public void UpdateRoomListItem(RoomInfo info)
    {
        GameObject listing = GameObject.Find(info.Name);
        if(listing != null)
        {
            Text txt = listing.GetComponentInChildren<Text>();
            if(info.PlayerCount == info.MaxPlayers)
            {
                txt.text = "ROOM FULL";
                Button btn = listing.GetComponent<Button>();
                btn.interactable = false;

            }else{
                txt.text = info.Name + " - "+ info.PlayerCount + " / " + info.MaxPlayers;
            }
        }else{
            Debug.Log("Cannot find a gameobject with the name of " + info.Name);
        }
    }

    public void CreateNewRoomListItem(RoomInfo info)
    {
        //Double check that the room does not exist.
        if(!currentRoomList.Contains(info.Name))
        {
            GameObject listing = Instantiate(listingPrefab, listingsPanel.transform);
            Text btnText = listing.GetComponentInChildren<Text>();
            listing.GetComponent<Button>().onClick.AddListener(() => { OnClickJoinRoom(info.Name); });
            btnText.text = info.Name + " - "+ info.PlayerCount + " / " + info.MaxPlayers;
            listing.transform.SetParent(listingsPanel.transform);
            Debug.Log("ROOM NAME"  + info.Name);
            listing.name = info.Name;
            currentRoomList.Add(info.Name);
        }
    }

    // public void RoomFull(RoomInfo room)
    // {

    //     if(currentRoomList.Contains(room.Name))
    //     {
    //          GameObject listing = GameObject.Find(room.Name);
    //          Button btn = listing.GetComponent<Button>();
    //         if(listing != null)
    //         {
    //             Text txt = listing.GetComponentInChildren<Text>();
    //             txt.text = "ROOM FULL";
    //             btn.interactable = false;
                
    //         }else{
    //             Debug.Log("Cannot find a button in the list with " +room.Name);
    //         }
            


    //     }


    // }
}

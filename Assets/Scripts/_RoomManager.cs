﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class _RoomManager : MonoBehaviourPunCallbacks
{

    
        public Transform userPanel;
        public GameObject userPrefab;
        private int numPlayers;
        public List<int> currentRoomPlayers =new List<int>();

        public override void OnJoinedRoom()
        {
            Debug.Log("User " + PhotonNetwork.NickName + " has joined the room...");
            StartCoroutine(RunUserListUpdate());
            numPlayers  = PhotonNetwork.CurrentRoom.PlayerCount;         
        }

        
        IEnumerator RunUserListUpdate()
        {
            while(true)
            {
                if(PhotonNetwork.CurrentRoom.PlayerCount != numPlayers)
                {
                    Dictionary<int, Photon.Realtime.Player> pList = Photon.Pun.PhotonNetwork.CurrentRoom.Players;
                    foreach (KeyValuePair<int, Photon.Realtime.Player> p in pList)
                    {
                        if(!currentRoomPlayers.Contains(p.Value.ActorNumber))
                        {
                            GameObject listing = Instantiate(userPrefab, userPanel.transform);
                            listing.name = p.Value.ActorNumber.ToString();
                            Text btnText = listing.GetComponent<Text>();     
                            btnText.text = p.Value.NickName;
                            listing.transform.SetParent(userPanel.transform);
                             //Add to the list of current players in the room.
                            currentRoomPlayers.Add(p.Value.ActorNumber);
                            numPlayers = PhotonNetwork.CurrentRoom.PlayerCount; 
                        }
                    }                                 
                }
                yield return new WaitForSeconds(2f);
            }
        }

        
    public override void OnDisconnected(DisconnectCause cause){
        Debug.Log(PhotonNetwork.NickName + " has disconnected. " + cause.ToString());
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + " has left, disconnected or closed the game");
        //Stop the routine because we are modifying the list. 
        StopCoroutine(RunUserListUpdate());
        foreach(int x in currentRoomPlayers)
        {
            if(x == otherPlayer.ActorNumber)
            {
                //currentRoomPlayers.Remove(x);
                GameObject playerListItem = GameObject.Find(otherPlayer.ActorNumber.ToString());
                Destroy(playerListItem);
            }
        }
        //restart the routine
        StartCoroutine(RunUserListUpdate());
    }

    
}

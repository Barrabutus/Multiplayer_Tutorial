using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
 [SerializeField]
    private PlayerListing _playerListing;
    

    [SerializeField]
    private Transform _content;

    [Header("Create Fake Rooms")]
    public int _numFakePlayers;
    
    public bool _fakePlayers;

    public List<PlayerListing> listings = new List<PlayerListing>();
    private void Start() 
    {

        if(_fakePlayers)
        {
            for(int x = 0; x < _numFakePlayers; x++)
            {
            
            PlayerListing listing = Instantiate(_playerListing,_content);
            if(listing != null)
                listing.SetFakePlayerInfo(x.ToString(), Random.Range(100, 100000));
                listings.Add(listing);

                
            }

        }

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        newPlayer.NickName = "TestingName";
          PlayerListing listing = Instantiate(_playerListing,_content);
                if(listing != null)
                    listing.SetPlayerInfo(newPlayer);
                    listings.Add(listing);

        


    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
           int index = listings.FindIndex(x => x.Player == otherPlayer);
           Debug.Log("Player left the room");

                if(index != -1)
                {
                    //Destroy(listings[index]);
                    listings[index].gameObject.SetActive(false);
                        
                    //Clean up the inactive rooms.
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index); 
                    
                }

    }

}

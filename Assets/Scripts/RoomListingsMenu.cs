using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private RoomListing _roomListingBtn;
    [SerializeField]
    private GameObject _roomListinggo;

    [SerializeField]
    private Transform _content;

    [Header("Create Fake Rooms")]
    public int _numFakeRooms;
    
    public bool _fakeRooms;

    public List<RoomListing> listings = new List<RoomListing>();


    private void Start() 
    {

        if(_fakeRooms)
        {
            for(int x = 0; x < _numFakeRooms; x++)
            {
            
            RoomListing listing = Instantiate(_roomListingBtn,_content);
            if(listing != null)
                listing.SetFakeRoomInfo("Room " + x.ToString(), Random.Range(2, 10));
                listings.Add(listing);

                
            }

        }

    }



    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        foreach(RoomInfo info in roomList)
        {

            if(info.RemovedFromList)
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                Debug.Log("Removed room name "+ info.Name);

                if(index != -1)
                {
                    //Destroy(listings[index]);
                    listings[index].gameObject.SetActive(false);
                        
                    //Clean up the inactive rooms.
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index); 
                    
                }


            }else{
                
                RoomListing listing = Instantiate(_roomListingBtn,_content);
                if(listing != null)
                    listing.SetRoomInfo(info);
                    listings.Add(listing);


            }


        }

    }




}

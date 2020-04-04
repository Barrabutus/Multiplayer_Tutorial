using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    //public RoomInfo RoomInfo { get; private set;}
    public Player Player { get ; private set;}

    public void SetPlayerInfo(Player player)
    {
       Player = player;
        _text.text = player.NickName;
    }
    public void SetFakePlayerInfo(string name, int score)
    {
        _text.text = name +":"+"score :" + score ;
    }


}

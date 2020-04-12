using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class _GameManager : MonoBehaviour, IPunObservable
{

    public List<Player> Players = new List<Player>();
    public bool isRoomFull;
    public Player currentDrawer;
    public string playerDrawingName;
    public int currentRound;
    public Room ourRoom;
    public GameObject readyUpBtn;

    public Text guessWord;

    // Start is called before the first frame update
    void Start()
    {     
        ourRoom = PhotonNetwork.CurrentRoom;
        currentRound = 0;
    }

    // Update is called once per frame
    void Update()
    {

 
    }

    public void StartGame()
    {
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(currentDrawer.NickName == playerDrawingName)
        {   
             _BrushManager bm = GameObject.Find("Brush").GetComponent<_BrushManager>();
            if(stream.IsWriting)
            {
                stream.SendNext(bm.BrushPositions);
            }else{
                bm.BrushPositions = (List<Vector2>)stream.ReceiveNext();
            }

        }
    }
}

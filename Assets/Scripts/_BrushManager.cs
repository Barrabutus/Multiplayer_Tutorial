using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class _BrushManager : MonoBehaviourPunCallbacks
{

    private bool isPainting;
    public GameObject paint;
    public GameObject _brushObj;
    public List<Color> colors = new List<Color>();
    public List<Vector2> BrushPositions = new List<Vector2>();

    // Start is called before the first frame update
    private void Start() 
    {
              
    }
    void Update()
    {
        if(photonView.IsMine)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                if(!isPainting)
                {
                    isPainting = true;
                    PhotonNetwork.Instantiate(_brushObj.name, new Vector3(0f,0f,0f), Quaternion.identity, 0);


                }
            }
            if(Input.GetButtonUp("Fire1"))
            {
                if(isPainting)
                {
                    isPainting = false;
                }
            }   
    
        }
    }
}



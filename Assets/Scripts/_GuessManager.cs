using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class _GuessManager : MonoBehaviourPun, IPunObservable
{
    public InputField GuessWord; 
    public Text GuessWordPrefab;

    public GameObject GuessWordsContentPanel;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;
using ExitGames.Client.Photon;
using UnityEngine.UI;
using Photon.Pun;


public class _ChatManager : MonoBehaviour, IChatClientListener
{
    //will fill this at a later date.
  
    [Header("Test Properties")]
    [SerializeField]
    public ChatClient client;
    public string ChatAppID;
    public string playerName;

    [Header("User Settings.")]
    //USE FOR IF YOU WANT USER TO INPUT NAME
    //public InputField playerNameInput;
    public InputField userInputMsg;

    [Header("Connection Settings")]
    public Text playerNameLabel;
    public Text connectionState;
    public bool isConnected;
    public string roomChannel;

    [Header("ChatBox Window")]
    public Text chatboxWindow;
    public List<string> __Users = new List<string>();


    public _ChatManager instance;
    // Start is called before the first frame update
    private void Awake() {
        instance = this;
        Debug.Log("CHAT MANAGER");
        
        
    }
    void Start()
    {
        instance = this;
        Application.runInBackground = true;
        if(string.IsNullOrEmpty(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat))
        {
            print ("No Chat ID Provided");
            return;
        }
    }
    
    public void SetChatChannelName(string roomName)
    {
        if(roomChannel =="")
        {
            roomChannel = roomName;
        }else{
            Debug.Log("Room already has a name...");
        }
    }

    public void SetChatClientName(string name)
    {
        Debug.Log("Name passed is "+ PhotonNetwork.NickName);
        this.playerName = name;
        __Users.Add(name);
        
       
    }

    public void ConnectToChatServer()
    {
        ConnectionProtocol connectionProtocol = ConnectionProtocol.Udp;
        this.client = new ChatClient(this, connectionProtocol);
        AuthenticationValues authenticationValues = new AuthenticationValues();
        authenticationValues.AuthType = CustomAuthenticationType.None;
        this.client.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, "0", authenticationValues);
        this.connectionState.text = "Connecting to chat server...";
        Debug.Log("Attempting to Connect to Chat.");
    }

    public void OnConnected()
    {

        this.connectionState.text = "Connected to Chat server...";

        this.playerNameLabel.text = this.playerName;

        this.client.Subscribe(new string[] {roomChannel});

        this.client.SetOnlineStatus(ChatUserStatus.Online);

        this.client.PublishMessage(roomChannel, this.playerName + " has connected.");
        isConnected = true;

        //isConnected=true;

    }

    // public void OnClickSetUsername()
    // {

    //     this.playerName = playerNameInput.text;
    //     this.connectionState.text = "Connecting...";
    //     this.chatboxWindow.text = "";
    //     worldChannel = "global";
    //     Connect();


    // }

    // Update is called once per frame
    void Update()
    {
        if(this.client != null)
        this.client.Service();
            
    }



    public void clearInput()
    {
        userInputMsg.text = "";
    }

    // public void OnClickPostMessage()
    // {
    //     this.client.PublishMessage(worldChannel, this.playerName + " : " + userInputMsg.text);
    //     clearInput();
    //     Debug.Log("CLICKED TO POST");
    // }


    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
            int count = messages.Length;
            for(int x = 0; x < count; x++)
            {
                //msg = string.Format("{0}{1}={2}", msg, senders[x],messages[x]);
                chatboxWindow.text += messages[x] + "\n";
                //Debug.Log(msg);
            }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {  
        // this.client.PublishMessage(worldChannel,this.playerName + " has joined the room...");
        
    }
    
    // void OnApplicationQuit() {

    //     OnDisconnected();    
    // }

    
    public void OnDisconnected()
    {
       // isConnected = false;
        //Debug.Log("OnDisconnected fired");
        //Display a user leaving the channel message. 
        //Unsubcribe the user from the channel.
        //this.client.Unsubscribe(new string[] {worldChannel});
        //client.Disconnect();
        
    }

    public void leaveRoomMsg()
    {

        //chatboxWindow.text += this.playerName " has left the room.";

    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        Debug.Log(this.playerName + " has left the room222");
    }

    public void OnUnsubscribed(string[] channels)
    {
      
        //Inform the editor user is unsubscribed.
        Debug.Log("user is unsubscribed from channel");
    }

    public void OnUserSubscribed(string channel, string user)
    {
   
        

    }


    public void DebugReturn(DebugLevel level, string message)
    {
    }

    public void OnChatStateChange(ChatState state)
    {

    }

 
}

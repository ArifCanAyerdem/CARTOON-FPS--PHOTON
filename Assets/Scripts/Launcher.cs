using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    
   [SerializeField] TMP_InputField roomNameInputField;
   [SerializeField] TMP_Text errorText;
[SerializeField] TMP_Text roomNameText;

void Start()
    {
         Debug.Log("Connecting to master server");
        PhotonNetwork.ConnectUsingSettings();
    }
      


   
public override void  OnConnectedToMaster() 
{
    
    Debug.Log("Connected to master server");
    PhotonNetwork.JoinLobby();
    
    
    
    }


public override void OnJoinedLobby() 
{
MenuManager.Instance.OpenMenu("title");
        Debug.Log("joined lobby");

}



public void CreateRoom(){


if(string.IsNullOrEmpty(roomNameInputField.text))
{
return;

}
PhotonNetwork.CreateRoom(roomNameInputField.text);
MenuManager.Instance.OpenMenu("loading");

}

    public override void OnJoinedRoom()
    {
         MenuManager.Instance.OpenMenu("room");
         roomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Failed to create room: " + message;
        MenuManager.Instance.OpenMenu("error");
    }

    

    public void LeaveRoom(){

        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    
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

        Debug.Log("joined lobby");

}



void Update()
    {
        
        
    
    }
}

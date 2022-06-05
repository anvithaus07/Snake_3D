using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace Snake3D
{
    public class PhotonConnector : MonoBehaviourPunCallbacks
    {
        public void ConnectToPhotonNetwork()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }
       
        public override void OnJoinedLobby()
        {
            SceneManager.LoadScene(GameConstants.kLobbyScene);
        }
    }
}

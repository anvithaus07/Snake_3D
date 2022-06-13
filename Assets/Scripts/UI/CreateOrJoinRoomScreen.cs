using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Snake3D
{
    public class CreateOrJoinRoomScreen : MonoBehaviourPunCallbacks
    {

        [Header("Create Room")]
        [SerializeField] private Button m_createRoomBtn;
        [SerializeField] private Text m_roomCodeTxt;

        [Header("Join Room")]
        [SerializeField] private Button m_joinRoomBtn;
        [SerializeField] private InputField m_roomCodeIp;

        [Header("Back Button")]
        [SerializeField] private Button m_backBtn;

        public override void OnEnable()
        {
            m_createRoomBtn.onClick.AddListener(OnCreateRoomBtnClicked);
            m_joinRoomBtn.onClick.AddListener(OnJoinRoomBtnClicked);
            m_backBtn.onClick.AddListener(OnBackBtnClicked);
            base.OnEnable();
        }
        public override void OnDisable()
        {
            m_createRoomBtn.onClick.RemoveAllListeners();
            m_joinRoomBtn.onClick.RemoveAllListeners();
            m_backBtn.onClick.RemoveAllListeners();

            base.OnDisable();
        }

        void OnCreateRoomBtnClicked()
        {
            if (PhotonNetwork.IsConnected)
            {
                RoomOptions op = new RoomOptions();
                op.MaxPlayers = 2;
                string roomCode = UnityEngine.Random.Range(1001, 99999).ToString();
                Debug.Log("Room Code is: " + roomCode);
                PhotonNetwork.CreateRoom(roomCode, op);
            }
        }

        void OnJoinRoomBtnClicked()
        {
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRoom(m_roomCodeIp.text);
            }
            else
            {
                Debug.Log("Photon Network is not connected");
            }
        }

        public override void OnCreatedRoom()
        {
            m_roomCodeTxt.text = string.Format("{0} : {1} ","ROOM CODE ", PhotonNetwork.CurrentRoom.Name);
        }
        public override void OnJoinedRoom()
        {
            Debug.Log("OnJoinedRoom OnJoinedRoom " + PhotonNetwork.CurrentRoom.PlayerCount);
            TakePlayerToGame();
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            base.OnJoinRoomFailed(returnCode, message);
            Debug.Log("OnJoinRoomFailed OnJoinRoomFailed " + message);
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.Log("OnPlayerEnteredRoom OnPlayerEnteredRoom " + PhotonNetwork.CurrentRoom.PlayerCount);
            TakePlayerToGame();
        }
        void OnBackBtnClicked()
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene(GameConstants.kMenuScene);
        }

        void TakePlayerToGame()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                SceneManager.LoadScene(GameConstants.kSinglePlayerGameScene);
            }
        }
    }
}
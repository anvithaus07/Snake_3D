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

        public override void OnEnable()
        {
            m_createRoomBtn.onClick.AddListener(OnCreateRoomBtnClicked);
            m_joinRoomBtn.onClick.AddListener(OnJoinRoomBtnClicked);
            base.OnEnable();
        }
        public override void OnDisable()
        {
            m_createRoomBtn.onClick.RemoveAllListeners();
            m_joinRoomBtn.onClick.RemoveAllListeners();

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
        }

        public override void OnCreatedRoom()
        {
            m_roomCodeTxt.text = string.Format("{0} : {1} ","ROOM CODE ", PhotonNetwork.CurrentRoom.Name);
        }
        public override void OnJoinedRoom()
        {
            Debug.Log("OnJoinedRoom OnJoinedRoom " + PhotonNetwork.CurrentRoom.PlayerCount);
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                SceneManager.LoadScene(GameConstants.kSinglePlayerGameScene);
            }
        }
    }
}
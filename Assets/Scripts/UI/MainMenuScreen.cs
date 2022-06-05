using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Snake3D
{
    public class MainMenuScreen : MonoBehaviour
    {
        [SerializeField] private Button m_singlePlayerBtn;
        [SerializeField] private Button m_multiPlayerBtn;
        [SerializeField] private PhotonConnector m_photonConnector;
        [SerializeField] private LoadingIndicator m_loadingIndicator;

        private void OnEnable()
        {
            m_singlePlayerBtn.onClick.AddListener(OnSinglePlayerBtnClicked);
            m_multiPlayerBtn.onClick.AddListener(OnMultiPlayerBtnClicked);
        }

        private void OnDisable()
        {
            m_singlePlayerBtn.onClick.RemoveAllListeners();
            m_multiPlayerBtn.onClick.RemoveAllListeners();
        }

        void OnSinglePlayerBtnClicked()
        {
            SceneManager.LoadScene(GameConstants.kSinglePlayerGameScene);
        }

        void OnMultiPlayerBtnClicked()
        {
            m_loadingIndicator.ShowLoadingIndiactor("Connecting...");
            m_photonConnector.ConnectToPhotonNetwork();
        }
    }
}
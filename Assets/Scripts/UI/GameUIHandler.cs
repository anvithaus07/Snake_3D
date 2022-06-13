using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Snake3D
{
    public class GameUIHandler : MonoBehaviour
    {
        [SerializeField] private Text m_playerScoreTxt;
        [SerializeField] private Text m_playerHighScoreTxt;

        [Header("Countdown Timer")]
        [SerializeField] private GameObject m_countdownHolder;
        [SerializeField] private Text m_countdownTxt;

        [Header("Button")]
        [SerializeField] private Button m_quitBtn;

        [Header("Game End Screen")]
        [SerializeField] private GameObject m_gameEndScreen;

        private void OnEnable()
        {
            ResetUI();
            PlayerDataHandler.Instance().OnScoreUpdated += SetPlayerScoreText;
            m_quitBtn.onClick.AddListener(OnQuitBtnTapped);
        }

        private void OnDisable()
        {
            PlayerDataHandler.Instance().OnScoreUpdated -= SetPlayerScoreText;
            m_quitBtn.onClick.RemoveAllListeners();
        }
        void SetPlayerScoreText()
        {
            m_playerScoreTxt.text = string.Format("{0} : {1}", "SCORE", PlayerDataHandler.Instance().CurrentScore.ToString());
            m_playerHighScoreTxt.text = string.Format("{0} : {1}", "HIGHSCORE", PlayerDataHandler.Instance().HighScore.ToString());
        }

        void ResetUI()
        {
            m_playerScoreTxt.text = string.Format("{0} : {1}", "SCORE", "0");
            m_playerHighScoreTxt.text = string.Format("{0} : {1}", "HIGHSCORE", PlayerDataHandler.Instance().HighScore.ToString());
        }

        #region Timer

        int timeLeft = 0;
        public void ShowGameStartCountDown(int seconds)
        {
            timeLeft = seconds;
            StartCoroutine(ShowTimer());

            IEnumerator ShowTimer()
            {
                m_countdownHolder.SetActive(true);
                while (timeLeft > 0)
                {
                    if (m_countdownTxt.text != timeLeft.ToString())
                        m_countdownTxt.text = timeLeft.ToString();

                    timeLeft--;
                    yield return new WaitForSeconds(1);

                }
                m_countdownHolder.SetActive(false);
                GamePlayController.Instance.HasGameStarted = true;
            }
        }
        #endregion

        #region Button Handlers

        void OnQuitBtnTapped()
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene(GameConstants.kMenuScene);
        }
        #endregion

        public void ShowGameEndScreen()
        {
            m_gameEndScreen.SetActive(true);
        }
    }
}

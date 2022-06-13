using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Snake3D
{
    public class GameEndScreen : MonoBehaviour
    {
        [SerializeField] private Button m_exitBtn;

        private void OnEnable()
        {
            m_exitBtn.onClick.AddListener(OnExitBtnClicked);
        }

        private void OnDisable()
        {
            m_exitBtn.onClick.RemoveAllListeners();
        }

        void OnExitBtnClicked()
        {
            SceneManager.LoadScene(GameConstants.kMenuScene);
        }
    }
}

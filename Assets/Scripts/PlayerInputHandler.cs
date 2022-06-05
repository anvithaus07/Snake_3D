using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Snake3D
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [Header("Control Button")]
        [SerializeField] private Button m_leftBtn;
        [SerializeField] private Button m_rightBtn;
        [SerializeField] private Button m_upBtn;
        [SerializeField] private Button m_downBtn;

        private Vector3 m_playerInputDirection = Vector3.left;

        private void OnEnable()
        {
            m_leftBtn.onClick.AddListener(() => { PlayerInputDirection = Vector3.left; });
            m_rightBtn.onClick.AddListener(() => { PlayerInputDirection = Vector3.right; });
            m_upBtn.onClick.AddListener(() => { PlayerInputDirection = Vector3.up; });
            m_downBtn.onClick.AddListener(() => { PlayerInputDirection = Vector3.down; });
        }

        private void OnDisable()
        {
            m_leftBtn.onClick.RemoveAllListeners();
            m_rightBtn.onClick.RemoveAllListeners();
            m_upBtn.onClick.RemoveAllListeners();
            m_downBtn.onClick.RemoveAllListeners();
        }
        private void Update()
        {
            if (!GameManager.Instance.HasGameEnded && GameManager.Instance.HasGameStarted)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                    PlayerInputDirection = Vector3.up;

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                    PlayerInputDirection = Vector3.down;

                else if (Input.GetKeyDown(KeyCode.RightArrow))
                    PlayerInputDirection = Vector3.right;

                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    PlayerInputDirection = Vector3.left;
            }
        }

        public Vector3 PlayerInputDirection
        {
            get
            {
                return m_playerInputDirection;
            }
            set
            {
                m_playerInputDirection = value;
            }
        }
    }
}
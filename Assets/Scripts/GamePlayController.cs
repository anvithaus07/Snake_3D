using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake3D
{
    public class GamePlayController : MonoBehaviour
    {
        [SerializeField] private GameUIHandler m_gameUIHandler;
        [SerializeField] private SnakeHandler m_snakeHandler;
        [SerializeField] private FoodHandler m_foodHandler;
        public static GamePlayController Instance;
        private bool _hasGameEnded;

        public Action OnGameEnded; 

        private void Awake()
        {
            Instance = this;
        }
       
        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            HasGameStarted = false;
            DestroyFoodParticle();
            m_gameUIHandler.ShowGameStartCountDown(3);
            InstantiateSnake();
            m_foodHandler.CalculaterPositionAndSpawnFood();
        }

        private void InstantiateSnake()
        {
            GameObject go = null;
            if (GameManager.Instance().PlayMode == PlayMode.MultiPlayer)
            {
                go = PhotonNetwork.Instantiate(m_snakeHandler.name, new Vector3(1, 0, -10), Quaternion.identity);
            }
            else
                go = Instantiate(m_snakeHandler.gameObject, this.transform);
           
            SnakeHandler snakeHandler = go.GetComponent<SnakeHandler>();

            if (snakeHandler != null)
            {
                snakeHandler.InitailizeSnake();
            }
        }

        public void DestroyFoodParticle()
        {
            m_foodHandler.DestroyFoodObject();
        }

        public void ShowGameEndScreen()
        {
            m_gameUIHandler.ShowGameEndScreen();
        }
        public void EndGame()
        {
            OnGameEnded?.Invoke();
        }

        public bool HasGameStarted { get; set; }
        
        public bool HasGameEnded
        {
            get
            {
                return _hasGameEnded;
            }
            set
            {
                _hasGameEnded = value;
                if (_hasGameEnded)
                    EndGame();
            }
        }

        
    }
}
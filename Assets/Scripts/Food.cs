using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake3D
{
    public abstract class Food : MonoBehaviour
    {
        [HideInInspector] public int ScorePerUnitConsumption;

        public abstract void SpawnFood(Action onFoodConsumed);
        public abstract void OnTriggerEnter(Collider collision);

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void InitializeFoodData(int scorePerUnitConsumption)
        {
            ScorePerUnitConsumption = scorePerUnitConsumption;
        }

        public virtual void UpdateScoreOnFoodConsumption()
        {
            GamePlayController.Instance.DestroyFoodParticle();
            PlayerDataHandler.Instance().CurrentScore += ScorePerUnitConsumption;
        }

        void OnGameEnded()
        {
            GamePlayController.Instance.DestroyFoodParticle();
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if(scene.name == GameConstants.kMultiPlayerGameScene || scene.name == GameConstants.kSinglePlayerGameScene )
            {
                GamePlayController.Instance.OnGameEnded -= OnGameEnded;
                GamePlayController.Instance.OnGameEnded += OnGameEnded;
            }
        }
    }

    
}
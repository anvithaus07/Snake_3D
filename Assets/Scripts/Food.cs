using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake3D
{
    public abstract class Food : MonoBehaviour
    {
        [HideInInspector] public Vector3 MaxBoundaryPoint;
        [HideInInspector] public Vector3 MinBoundaryPoint;
        [HideInInspector] public int ScorePerUnitConsumption;



        public abstract void SpawnFood(Action onFoodConsumed);
        public abstract void OnTriggerEnter(Collider collision);

        private void OnEnable()
        {
            GameManager.Instance.OnGameEnded += OnGameEnded;
        }

        private void OnDisable()
        {

            GameManager.Instance.OnGameEnded -= OnGameEnded;

        }

        public void InitializeFoodData(Vector3 minPoint, Vector3 maxPoints, int scorePerUnitConsumption)
        {
            MaxBoundaryPoint = maxPoints;
            MinBoundaryPoint = minPoint;
            ScorePerUnitConsumption = scorePerUnitConsumption;
        }

        public virtual void UpdateScoreOnFoodConsumption()
        {
            PlayerDataHandler.Instance().CurrentScore += ScorePerUnitConsumption;
        }

        public Vector3 GetFoodSpawnPosition()
        {
            float xPos = UnityEngine.Random.Range(MinBoundaryPoint.x, MaxBoundaryPoint.x);
            float zPos = UnityEngine.Random.Range(MinBoundaryPoint.z, MaxBoundaryPoint.z);

            return new Vector3(Mathf.Round(xPos),0.0f, Mathf.Round(zPos));
        }

        void OnGameEnded()
        {
            Destroy(this.gameObject);
        }
    }

    
}
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Snake3D
{
    public class FoodHandler : MonoBehaviour
    {
        [SerializeField] private BoxCollider m_gridArea;
        [SerializeField] private GameObject m_staticFoodParticle;
        [SerializeField] private GameObject m_movingFoodParticle;
        [SerializeField] private PhotonView m_photonView;

        private Bounds mGridAreaBounds;

        private int mCurrentFoodCount = 0;
        GameObject mInstantiatedFoodObject = null;

        PlayMode mPlayMode;

        private void Start()
        {
            mPlayMode = GameManager.Instance().PlayMode;
        }
        public void CalculaterPositionAndSpawnFood()
        {
            mCurrentFoodCount = 0;
            mGridAreaBounds = m_gridArea.bounds;
            SpawnFood();
        }

        void SpawnFood()
        {
            if ((mPlayMode == PlayMode.MultiPlayer && m_photonView.IsMine) || mPlayMode == PlayMode.SinglePlayer)
            {
                if (mCurrentFoodCount % 2 == 0)
                {
                    SpawnStaticFood();
                }
                else
                {
                    SpawnMovingFood();
                }
                mCurrentFoodCount++;
            }
        }

        void SpawnStaticFood()
        {
            GameObject food = null;
            if (GameManager.Instance().PlayMode == PlayMode.MultiPlayer)

                food = PhotonNetwork.Instantiate(m_staticFoodParticle.name, GetFoodSpawnPosition(), Quaternion.identity);
            else
                food = Instantiate(m_staticFoodParticle, GetFoodSpawnPosition(), Quaternion.identity, this.transform);

            StaticFood staticFood = food.GetComponent<StaticFood>();
            mInstantiatedFoodObject = food;
            if (staticFood != null)
            {
                staticFood.InitializeFoodData(GameConstants.ScoreForFixedFood);
                staticFood.SpawnFood(SpawnFood);
            }
        }

        void SpawnMovingFood()
        {
            GameObject food = null;
            if (GameManager.Instance().PlayMode == PlayMode.MultiPlayer)

                food = PhotonNetwork.Instantiate(m_movingFoodParticle.name, GetFoodSpawnPosition(), Quaternion.identity);
            else
                food = Instantiate(m_movingFoodParticle, GetFoodSpawnPosition(), Quaternion.identity, this.transform);

            MovingFoodParticle movingFood = food.GetComponent<MovingFoodParticle>();


            mInstantiatedFoodObject = food;

            if (movingFood != null)
            {
                movingFood.InitializeFoodData(GameConstants.ScoreForMovingFood);
                movingFood.SpawnFood(SpawnFood);
            }
        }
        public Vector3 GetFoodSpawnPosition()
        {
            float xPos = Random.Range(mGridAreaBounds.min.x, mGridAreaBounds.max.x);
            float zPos = Random.Range(mGridAreaBounds.min.z, mGridAreaBounds.max.z);

            return new Vector3(Mathf.Round(xPos), 0.0f, Mathf.Round(zPos));
        }

        public void DestroyFoodObject()
        {
            if ((mPlayMode == PlayMode.MultiPlayer && m_photonView.IsMine) || mPlayMode == PlayMode.SinglePlayer)
            {
                if (mInstantiatedFoodObject != null)
                    Destroy(mInstantiatedFoodObject);
            }
        }
    }
}
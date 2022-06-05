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

        private Bounds mGridAreaBounds;

        private int mCurrentFoodCount = 0;

        public void CalculaterPositionAndSpawnFood()
        {
            mCurrentFoodCount = 0;
            mGridAreaBounds = m_gridArea.bounds;
            SpawnFood();
        }

        void SpawnFood()
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

        void SpawnStaticFood()
        {
            GameObject go = Instantiate(m_staticFoodParticle);
            StaticFood staticFood = go.GetComponent<StaticFood>();

            if (staticFood != null)
            {
                staticFood.InitializeFoodData(mGridAreaBounds.min, mGridAreaBounds.max, GameConstants.ScoreForFixedFood);
                staticFood.SpawnFood(SpawnFood);
            }
        }

        void SpawnMovingFood()
        {
            GameObject go = Instantiate(m_movingFoodParticle);
            MovingFoodParticle movingFood = go.GetComponent<MovingFoodParticle>();

            if (movingFood != null)
            {
                movingFood.InitializeFoodData(mGridAreaBounds.min, mGridAreaBounds.max, GameConstants.ScoreForMovingFood);
                movingFood.SpawnFood(SpawnFood);
            }
        }
    }
}
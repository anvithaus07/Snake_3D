using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Snake3D
{
    public class SnakeHandler : MonoBehaviour
    {
        [SerializeField] private Transform m_snakeBodySegment;
        [SerializeField] private PlayerInputHandler m_playerInputHandler;

        private List<Transform> mSnakeSegments = new List<Transform>();

        private int mInitializeSnakeSegmentCount = 5;

        

        private void FixedUpdate()
        {
            if (!GameManager.Instance.HasGameEnded && GameManager.Instance.HasGameStarted)
            {
                for (int i = mSnakeSegments.Count - 1; i > 0; i--)
                {
                    mSnakeSegments[i].position = mSnakeSegments[i - 1].position;

                }
                Vector3 currentPos = this.transform.position;
                float currectXpos = Mathf.Round(currentPos.x) + m_playerInputHandler.PlayerInputDirection.x;
                float currectZpos = Mathf.Round(currentPos.z) + m_playerInputHandler.PlayerInputDirection.y;

                transform.position = new Vector3(currectXpos,0.0f, currectZpos);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!GameManager.Instance.HasGameEnded && GameManager.Instance.HasGameStarted)
            {
                if (other.tag == GameConstants.kMovingFoodTag || other.tag == GameConstants.kStaticFoodTag)
                {
                    AddSegementToSnake();
                }
                if (other.tag == GameConstants.kObstacleTag)
                {
                    GameManager.Instance.HasGameEnded = true;
                    StartCoroutine(ShowCollidedEffect());
                }
            }
        }
        IEnumerator ShowCollidedEffect()
        {
            yield return new WaitForSeconds(3.0f);
            ResetState();
        }

        public void InitailizeSnake()
        {
            GameManager.Instance.HasGameEnded = false;
            mSnakeSegments = new List<Transform>();
            mSnakeSegments.Add(this.transform);
            PlayerDataHandler.Instance().CurrentScore = 0;

            this.transform.position = new Vector3(1, 0, -10);
            for (int i = 0; i < mInitializeSnakeSegmentCount; i++)
            {
                AddSegementToSnake();
            }
        }
        void AddSegementToSnake()
        {
            Transform snakeSegment = Instantiate(m_snakeBodySegment);
            snakeSegment.position = mSnakeSegments[mSnakeSegments.Count - 1].position;
            mSnakeSegments.Add(snakeSegment);
        }
        void ResetState()
        {
            for (int i = 1; i < mSnakeSegments.Count; i++)
            {
                Destroy(mSnakeSegments[i].gameObject);
            }
            mSnakeSegments.Clear();
            mSnakeSegments.Add(this.transform);

            GameManager.Instance.StartGame();
        }
    }
}

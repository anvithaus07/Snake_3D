using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake3D
{
    public class MovingFoodParticle : Food
    {
        Action OnFoodConsumed;
        public override void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == GameConstants.kPlayerTag)
            {
                base.UpdateScoreOnFoodConsumption();
                OnFoodConsumed?.Invoke();
                Destroy(this.gameObject);
            }
        }

        public override void SpawnFood(Action onFoodConsumed)
        {
            OnFoodConsumed = onFoodConsumed;
        }
    }
}
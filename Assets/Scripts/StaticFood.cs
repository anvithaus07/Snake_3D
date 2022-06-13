using System;
using UnityEngine;
namespace Snake3D
{
    public class StaticFood : Food
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
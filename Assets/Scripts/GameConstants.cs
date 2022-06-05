using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Snake3D
{
    public static class GameConstants
    {
        public static string kPlayerTag = "Player";
        public static string kStaticFoodTag = "StaticFood";
        public static string kMovingFoodTag = "MovingFood";
        public static string kObstacleTag = "Obstacle";

        public static int ScoreForFixedFood = 1;
        public static int ScoreForMovingFood = 2;


        public static string kSinglePlayerGameScene = "GameScene";
        public static string kMultiPlayerGameScene = "";
        public static string kMenuScene = "MainMenuScene";
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Snake3DMenu : MonoBehaviour
{
    [MenuItem("Snake3D/Launch Game")]
    public static void LaunchGame()
    {
        OpenScene("Assets/Scenes/MainMenuScene.unity",true);
    }

    [MenuItem("Snake3D/Scenes/Lobby Scene")]
    public static void OpenLobbyScene()
    {
        OpenScene("Assets/Scenes/LobbyScene.unity", false);
    }
    
    [MenuItem("Snake3D/Scenes/Game Scene")]
    public static void OpenGameScene()
    {
        OpenScene("Assets/Scenes/GameScene.unity", false);
    }

    private static void OpenScene(string scenePath,bool shouldPlayScene =false)
    {
        if(EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene(scenePath);
        EditorApplication.isPlaying = shouldPlayScene;
    }
}

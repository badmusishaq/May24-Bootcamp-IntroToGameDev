using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void GotoScene(string sceneName)
    {
        //Debug.Log("Button clicked");
        SceneManager.LoadScene(sceneName);
    }

    public void GotoSceneIndex(int sceneIndex)
    {
        //Debug.Log("Button clicked");
        SceneManager.LoadScene(sceneIndex);
    }

}

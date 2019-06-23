using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    public void LoadScene(string sceneName) {
        print(sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance = null;

    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Persistent")
        {
                LoadScene("ShaderDemos");
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadNewScene(sceneName));
    }

    IEnumerator LoadNewScene(string sceneName)
    {
        UnityEngine.AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            yield return null;
        }
    }
}

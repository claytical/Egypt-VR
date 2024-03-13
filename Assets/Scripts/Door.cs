using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Inspect()
    {
        Debug.Log("Inspecting Door");
    }

    public void Open()
    {
        Debug.Log("Opening Door to " + scene);
        StartCoroutine(LoadSceneAsyncCoroutine(scene));
    }

    // Coroutine to asynchronously load a new scene
    private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        // Start loading the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous loading is completed
        while (!asyncLoad.isDone)
        {
            // You can implement a progress bar or loading spinner here
            Debug.Log("Loading progress: " + (asyncLoad.progress * 100f) + "%");

            yield return null;
        }

        Debug.Log("Scene loaded successfully!");
    }
}

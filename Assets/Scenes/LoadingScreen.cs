using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public string String1;
    public string String2;
    public string String3;
    public Text textComponent;
    public float loadingDelay = 2.0f; // Set the loading delay time here

    private void Start()
    {
        string[] strings = { String1, String2, String3 };
        int index = Random.Range(0, strings.Length);
        string randomString = strings[index];
        textComponent.text = randomString;
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        // Wait for the loading delay before starting to load the scene
        //yield return new WaitForSeconds(loadingDelay);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        // Show the loading screen
        loadingScreen.SetActive(true);

        // Disable the loading screen after the scene is loaded
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // Set the slider value with a delay
            while (slider.value < operation.progress)
            {
                slider.value += Time.deltaTime / loadingDelay;
                yield return null;
            }

            // Update the progress text
            float progress = Mathf.Clamp01(operation.progress / .9f);


            // If the scene is fully loaded, enable scene activation
            if (operation.progress >= 0.9f)
            {
                slider.value = 1f;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}

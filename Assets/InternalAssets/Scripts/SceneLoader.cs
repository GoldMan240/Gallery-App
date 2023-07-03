using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class SceneLoader
{
    public static string ImageURL {  get; private set; }

    private static readonly WaitForSeconds oneSecond = new WaitForSeconds(1);

    private static Scene targetScene;
    
    public static void Load(Scene targetScene)
    {
        SceneLoader.targetScene = targetScene;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoadWithoutLoadingScreen(Scene targetScene)
    {
        if (targetScene == Scene.Exit)
        {
            Application.Quit();

            return;
        }

        SceneManager.LoadScene(targetScene.ToString());
    }

    public static void LoadWithImage(Scene targetScene, string url)
    {
        ImageURL = url;

        LoadWithoutLoadingScreen(targetScene);
    }

    public static IEnumerator LoaderCallback(Image progressBarImage, TextMeshProUGUI progressText)
    {
        yield return oneSecond;

        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(targetScene.ToString());

        float loadingPercentage = progressBarImage.fillAmount;
        float percentageForLoadingScene = 1 - loadingPercentage;

        while (!sceneLoading.isDone)
        {
            float sceneLoadingProgressValue = Mathf.Clamp01(sceneLoading.progress / 0.9f) * percentageForLoadingScene;
            float sceneLoadingProgressValueNomalized = loadingPercentage + sceneLoadingProgressValue;

            if (progressBarImage != null && progressText != null)
            {
                progressBarImage.fillAmount = sceneLoadingProgressValueNomalized;
                progressText.text = $"{sceneLoadingProgressValueNomalized * 100}%";
            }

            yield return null;
        }

        yield return oneSecond;
    }
}

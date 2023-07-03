using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoaderCallback : MonoBehaviour
{
    private const int IMAGE_COUNT = 8;

    [SerializeField] private Image progressBarImage;
    [SerializeField] private TextMeshProUGUI progressText;

    private string[] imageURLs = new string[IMAGE_COUNT];
    private List<string> downloadedImagesURLList = new List<string>();
    private bool startCoroutine = true;

    private void Awake()
    {
        progressBarImage.fillAmount = 0;
        progressText.text = "0%";

        int iterationShiftCompensation = 1;
        for (int i = 0; i < IMAGE_COUNT; i++)
        {
            imageURLs[i] = $"http://data.ikppbb.com/test-task-unity-data/pics/{i + iterationShiftCompensation}.jpg";
        }
    }

    private void Start()
    {
        foreach (string url in imageURLs)
        {
            if (!SpriteCache.HasSprite(url)) StartCoroutine(ImageDownloader.Download(url));
        }
    }

    private void Update()
    {
        foreach (string url in imageURLs)
        {
            if (SpriteCache.HasSprite(url) && !downloadedImagesURLList.Contains(url))
            {
                downloadedImagesURLList.Add(url);

                float loadingProgressValue = (float)downloadedImagesURLList.Count / imageURLs.Count();
                progressBarImage.fillAmount = loadingProgressValue;
                progressText.text = Math.Truncate(loadingProgressValue * 100) + "%";
            }
        }

        if (imageURLs.All(url => SpriteCache.HasSprite(url)) && startCoroutine)
        {
            startCoroutine = false;

            StartCoroutine(SceneLoader.LoaderCallback(progressBarImage, progressText));
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageViewUI : MonoBehaviour
{
    [SerializeField] private Image image;

    private void Awake()
    {
        image.sprite = SpriteCache.Get(SceneLoader.ImageURL);
        image.gameObject.SetActive(true);
    }
}

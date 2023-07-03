using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ImageUI : MonoBehaviour
{
    [SerializeField] private Image image;

    public string ImageURL { get; set; }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => 
        {
            if (SpriteCache.HasSprite(ImageURL))
            {
                SceneLoader.LoadWithImage(Scene.ImageViewScene, ImageURL);
            }
        });
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<TriggerArea>() != null)
        {
            if (SpriteCache.HasSprite(ImageURL))
            {
                image.sprite = SpriteCache.Get(ImageURL);
                image.gameObject.SetActive(true);
                Debug.Log("Load");
            }
            else
            {
                StartCoroutine(DonwloadAndLoadImage(ImageURL));
                Debug.Log("Create!");
            }
        }
    }

    private IEnumerator DonwloadAndLoadImage(string imageUrl)
    {
        yield return StartCoroutine(ImageDownloader.Download(imageUrl));

        image.sprite = SpriteCache.Get(ImageURL);
        image.gameObject.SetActive(true);
    }
}

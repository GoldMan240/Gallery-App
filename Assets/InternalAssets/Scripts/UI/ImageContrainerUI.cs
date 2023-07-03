using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class ImageContrainerUI : MonoBehaviour
{
    private int IMAGE_COUNT = 66;

    [SerializeField] private GameObject mainParent;
    [SerializeField] private ImageUI imageTemplate;
    [SerializeField] private GameObject triggerArea;

    private bool isFirst = true;

    private void Awake()
    {
        float containerWidth = mainParent.GetComponent<RectTransform>().rect.width;
        GridLayoutGroup gridLayoutGroup = GetComponent<GridLayoutGroup>();
        float horizontalPadding = gridLayoutGroup.padding.horizontal;
        float xSpacing = gridLayoutGroup.spacing.x;
        
        float cellWidth = (containerWidth - horizontalPadding - xSpacing) / 2;
        Vector2 cellSize = new Vector2 (cellWidth, cellWidth);
        gridLayoutGroup.cellSize = cellSize;

        int iterationShiftCompensation = 1;
        for (int i = 0; i < IMAGE_COUNT; i++)
        {
            ImageUI imageUI = Instantiate(imageTemplate.gameObject, gameObject.transform).GetComponent<ImageUI>();
            imageUI.ImageURL = $"http://data.ikppbb.com/test-task-unity-data/pics/{i + iterationShiftCompensation}.jpg";

            imageUI.AddComponent<BoxCollider2D>().size = cellSize;
        }
    }

    private void Update()
    {
        if (isFirst)
        {
            isFirst = false;

            triggerArea.SetActive(true);
        }
        
    }
}

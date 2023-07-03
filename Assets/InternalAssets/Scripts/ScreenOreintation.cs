using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOreintation : MonoBehaviour
{
    [SerializeField] private Orientation screenOrientation;

    private enum Orientation
    {
        Horizontal,
        Vertical,
        Both,
    }

    private void Start()
    {
        switch (screenOrientation)
        {
            case Orientation.Horizontal:
                Screen.autorotateToPortrait = false;
                Screen.autorotateToPortraitUpsideDown = false;
                Screen.autorotateToLandscapeLeft = true;
                Screen.autorotateToLandscapeRight = true;
                break;
            case Orientation.Vertical:
                Screen.autorotateToPortrait = true;
                Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = false;
                Screen.autorotateToLandscapeRight = false;
                break;
            case Orientation.Both:
                Screen.autorotateToPortrait = true;
                Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = true;
                Screen.autorotateToLandscapeRight = true;
                break;
        }
    }
}

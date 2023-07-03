using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Scene targetOfTransition;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneLoader.LoadWithoutLoadingScreen(targetOfTransition);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingIconUI : MonoBehaviour
{
    private void Update()
    {
        float speed = 50f;
        transform.Rotate(new Vector3(0, 0, -5) * speed * Time.deltaTime);
    }
}

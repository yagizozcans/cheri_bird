using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public SpriteRenderer rink;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetFloat("orthoSize", 0) == 0)
        {
            float orthoSize = rink.bounds.size.x * Screen.height / Screen.width * 0.5f;
            PlayerPrefs.SetFloat("orthoSize", orthoSize);
        }
        gameObject.GetComponent<Camera>().orthographicSize = PlayerPrefs.GetFloat("orthoSize");
        PlayerPrefs.SetFloat("orthoSize", 0);
    }
}

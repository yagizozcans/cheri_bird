using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float returnDistance = 2;

    public float scrollVelocity = 2;

    public GameObject camera;

    private void Start()
    {
        returnDistance = this.transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float distance = this.transform.position.x - camera.transform.position.x;

        transform.Translate(scrollVelocity * Time.deltaTime * Vector2.left);

        if (Mathf.Abs(distance) > returnDistance)
        {
            this.transform.position = new Vector3(0, -4.286325f, 0);
        }
    }
}

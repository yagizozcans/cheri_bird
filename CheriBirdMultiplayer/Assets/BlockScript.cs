using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    public float scrollVelocity = 2;

    public void Update()
    {
        transform.Translate(scrollVelocity * Time.deltaTime * Vector2.left);
    }

    private void Start()
    {
        Invoke("DestroyThisObject", 5);
    }

    void DestroyThisObject()
    {
        Destroy(this.gameObject);
    }
}

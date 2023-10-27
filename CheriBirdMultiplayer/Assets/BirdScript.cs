using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public float velocity = 1;
    private Rigidbody2D rb2D;

    private AudioSource audio;

    private float velocityF = 0;

    float smoothedRotation = 0;

    public InGameManager inGameManager;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //rb2D.AddForce(Vector2.up * velocity * Time.deltaTime);
            rb2D.velocity = Vector2.up * velocity;
            audio.Play();
        }

        if(rb2D.velocity.y > 0)
        {
            smoothedRotation = Mathf.Lerp(smoothedRotation, -30 , 0.3f);
            this.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Clamp(smoothedRotation,-30,30));
        }
        else
        {
            smoothedRotation = Mathf.Lerp(smoothedRotation, 30, 0.15f);
            this.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Clamp(smoothedRotation, -30, 30));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pipe")
        {
            if(InGameManager.score > PlayerPrefs.GetInt("highscore",0))
            {
                PlayerPrefs.SetInt("highscore", InGameManager.score);
            }

            inGameManager.EndGame();
        }
        if (collision.tag == "Score")
        {
            InGameManager.score += 1;
        }
    }
}

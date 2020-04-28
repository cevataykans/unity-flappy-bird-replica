using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Rigidbody2D birdBody;
    Vector2 flySpeed;
    Animator animationController;

    public Vector2 jumpForce;

    // Start is called before the first frame update
    void Awake()
    {
        birdBody = GetComponent<Rigidbody2D>();
        animationController = GetComponent<Animator>();
        //jumpForce = new Vector2(0, 500);
        flySpeed = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Space))
        {
            // Add velocity
            birdBody.velocity = flySpeed;
            birdBody.AddForce( jumpForce);
            animationController.SetTrigger("Fly");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EventHandler.TriggerOnBirdDied();
        animationController.SetTrigger("Die");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventHandler.TriggerOnBirdScore();
    }
}

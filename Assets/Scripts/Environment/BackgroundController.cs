using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    Transform skyTransform;
    float horizontalLength;
    Vector3 transformAmount;
    Rigidbody2D rb;

    Vector2 stopVector = new Vector2(0, 0);
    Vector2 moveVector = new Vector2(-2, 0);

    private void Start()
    {
        skyTransform = transform;
        horizontalLength = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        transformAmount = new Vector3(horizontalLength * 2, 0, 0);
        rb = GetComponent<Rigidbody2D>();

        EventHandler.OnBirdDied += StopBackGround;
        EventHandler.OnGameStart += MoveBackGround;
    }

    // Update is called once per frame
    private void Update()
    {
        if (skyTransform.position.x < -horizontalLength )
        {
            skyTransform.position = skyTransform.position + transformAmount;
        }
    }

    private void StopBackGround()
    {
        rb.velocity = stopVector;
    }

    private void MoveBackGround()
    {
        rb.velocity = moveVector;
    }
}

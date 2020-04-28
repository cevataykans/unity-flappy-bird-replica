using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    Rigidbody2D pipeBody;
    Vector2 moveSpeed;

    private void Awake()
    {
        pipeBody = GetComponent<Rigidbody2D>();
        moveSpeed = new Vector2(-5, 0);
    }

    private void OnEnable()
    {
        EventHandler.OnBirdDied += StopMoveSpeed;
        pipeBody.velocity = moveSpeed;
        Invoke("Disable", 5);
    }

    private void OnDisable()
    {
        EventHandler.OnBirdDied -= StopMoveSpeed;
        CancelInvoke();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void StopMoveSpeed()
    {
        CancelInvoke();
        pipeBody.velocity = new Vector2(0, 0);
    }
}

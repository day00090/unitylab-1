using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPaddle : MonoBehaviour
{
    [SerializeField] private Transform paddle;
    [SerializeField] private float yMaximum;
    [SerializeField] private float yMinimum;
    [SerializeField] private KeyCode keyUp;
    [SerializeField] private KeyCode keyDown;
    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyUp))
        {
            if(paddle.position.y < yMaximum) {
                paddle.position = new Vector2(paddle.position.x, paddle.position.y + moveSpeed);
            }
        }

        if (Input.GetKey(keyDown))
        {
            if(paddle.position.y > yMinimum)
            {
                paddle.position = new Vector2(paddle.position.x, paddle.position.y - moveSpeed);
            }
        }
    }
}
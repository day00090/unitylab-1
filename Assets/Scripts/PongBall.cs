using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PongBall : MonoBehaviour
{
    [SerializeField] private Transform pongBall;
    [SerializeField] private Rigidbody2D mainRigidBody;
    [SerializeField] private Vector3 origin;
    //These two fields handle the movement speed and the velocity of the ball.
    [SerializeField] private float moveSpeed;
    private Vector2 newVelocity;

    public static WaitForSeconds wait = new WaitForSeconds(1f);

    void Awake()
    {
        newVelocity = new Vector2(Random.Range(-4f, 4f), Random.Range(-0.5f, 0.5f));
        mainRigidBody.velocity = newVelocity.normalized * moveSpeed;
    }

    public void Restart()
    {
        mainRigidBody.velocity = Vector2.zero;
        mainRigidBody.position = origin;
        StartCoroutine(RestartBall());
    }

    public void Stop()
    {
        mainRigidBody.velocity = Vector2.zero;
        mainRigidBody.simulated = false;
    }

    private IEnumerator RestartBall()
    {
        yield return wait;
        newVelocity = new Vector2(Random.Range(-4f, 4f), Random.Range(-0.5f, 0.5f));
        mainRigidBody.velocity = newVelocity.normalized * moveSpeed;
    }

}
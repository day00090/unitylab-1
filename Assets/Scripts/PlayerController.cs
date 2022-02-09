using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mainRigidbody;
    [SerializeField] private SpriteRenderer mainSpriteRenderer;
    [SerializeField] int moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            mainSpriteRenderer.flipX = false;
            mainRigidbody.AddForce(new Vector2(-moveSpeed * Time.deltaTime, 0));
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            mainSpriteRenderer.flipX = true;
            mainRigidbody.AddForce(new Vector2(+moveSpeed * Time.deltaTime, 0));
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            mainRigidbody.AddForce(new Vector2(0, 50));
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            mainRigidbody.AddForce(new Vector2(0, 50));
        }
    }
}

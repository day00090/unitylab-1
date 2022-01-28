using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Transform mainTransform;
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireRoutine());
    }

     IEnumerator FireRoutine() {
        
        float elapsedTime = 0;
        while(elapsedTime < 5)
        {
            mainTransform.position += mainTransform.up * moveSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

}

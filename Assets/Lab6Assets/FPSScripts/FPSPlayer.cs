using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayer : MonoBehaviour
{
    [SerializeField] private Transform shootPosition;
    [Range(0, 200)]
    [SerializeField] private GameObject[] bullets;
    private int bulletCount;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Fire()
    {
        if(bulletCount < 8)
        {
            GameObject bulletPrefab = bullets[Random.Range(0, bullets.Length)];
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.SetPositionAndRotation(shootPosition.position, shootPosition.rotation);
            bulletCount++;
        }
    }

    void Reload()
    {
        if(bulletCount != 0) {
            bulletCount = 0;
        }
    }
}

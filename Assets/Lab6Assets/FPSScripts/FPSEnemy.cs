using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSEnemy : MonoBehaviour
{
    [SerializeField] Transform mainTransform;
    [SerializeField] float moveSpeed;

    void Update() {
        Vector3 playerPos = FPSPlayer.instance.transform.position;
        mainTransform.LookAt(playerPos);
        Vector3 currentRotation = mainTransform.rotation.eulerAngles;
        mainTransform.eulerAngles = currentRotation;
        Vector3 directionToPlayer = (playerPos - mainTransform.position).normalized;
        mainTransform.position += (directionToPlayer * moveSpeed * Time.deltaTime).SetY(0);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Bullet")) {
            Destroy(gameObject);
            Destroy(other.gameObject);
            FPSPlayer.instance.HandleEnemyDefeat();
        }
    }

}
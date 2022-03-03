using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSPlayer : MonoBehaviour
{
    [SerializeField] private Transform shootPosition;
    [Range(0, 200)]
    [SerializeField] private GameObject[] bullets;
    private int bulletCount = 8;
    [SerializeField] private TMP_Text bulletCounter;
    [SerializeField] private AudioSource firingSound;
    [SerializeField] private FPSUI fpsUI;
    [SerializeField] private int maxHealth;
    [SerializeField] private Transform head;

    //Here, we define an instance of the player:
    public static FPSPlayer instance;
     void Awake()
    {
        instance = this;
        Health = maxHealth;
    }
    
    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
    }

    void Fire() {
        if(bulletCount > 0) {
            GameObject bulletPrefab = bullets[Random.Range(0, bullets.Length)];
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.SetPositionAndRotation(shootPosition.position, shootPosition.rotation);
            bulletCount--;
            if(bulletCount >= 1) {
                bulletCounter.text = "Bullets: " + bulletCount;
            }
            else {
                bulletCounter.text = "Reload!";
            }
            firingSound.Play();
        }
    }

    void Reload() {
        if(bulletCount == 0) {
            bulletCount = 8;
            bulletCounter.text = "Bullets: " + bulletCount;
        }
    }

    //This method deals with collisions
    private float lastHitTime;
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.CompareTag("Enemy") && (Time.time - lastHitTime > 1f)) {
            lastHitTime = Time.time;
            Destroy(hit.gameObject);
            if (Health > 0) {
                Health--;
            }
        }
    }

    //Meanwhile, this section manages the player's health.
    private int health;
    private int Health {
        get {
            return health;
        }
        set {
            health = value;
            fpsUI.ShowHealthFraction((float)Health / (float)maxHealth);
            if(health <= 0) {
                LoadingScreen.LoadScene("Lab2");
            }
        }
    }

    //Here, the count of the enemies defeated gets tracked.
    private int enemyDefeatCount;
    public void HandleEnemyDefeat() {
        enemyDefeatCount++;
        fpsUI.ShowEnemyDefeatCount(enemyDefeatCount);
    }

    //But, one also has to consider the direction the player is facing.
        public bool ShouldSpawn(Vector3 pos) {
        Vector3 posDiff = pos - transform.position;

        Vector3 faceDirection = head.forward;

        float distanceFromPlayer = posDiff.magnitude;

        return (Vector3.Dot(posDiff.normalized, faceDirection) < 0.5f) && (distanceFromPlayer > 10f);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private AudioSource audioSource;
    private float lastHitTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Sets the color of the MeshRenderer's material to a specified color
    public void SetColor(UnityEngine.Color c)
    {
        meshRenderer.material.SetColor("_Color", c);
    }

    private void OnCollisionEnter(Collision collision) {
        if((Time.time - lastHitTime) > 0.25f) {
            lastHitTime = Time.time;
            audioSource.volume = Mathf.InverseLerp(0, 10, collision.relativeVelocity.magnitude);
            audioSource.pitch = Random.Range(0.75f, 1.25f);
            audioSource.Play();
    }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}

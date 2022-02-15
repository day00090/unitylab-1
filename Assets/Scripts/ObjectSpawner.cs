using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private SpawnObject objectPrefab;
    [SerializeField] private TMP_Text objectCountText;
    private int objectCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Spawn the piranha
            SpawnObject newObject = Instantiate(objectPrefab);
            newObject.SetColor(Random.ColorHSV(0, 1, 0.75f, 1, 0.5f, 1, 1, 1));
            newObject.transform.position = spawnLocation.position;
            newObject.transform.rotation = Random.rotation;
            //Indicate how many piranhas have been spawned
            objectCount++;
            objectCountText.text = "Object Count: " + objectCount;
        }
    }
}

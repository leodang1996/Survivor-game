using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomize : MonoBehaviour
{
    [SerializeField] List<GameObject> probSpawnPoints;
    [SerializeField] List<GameObject> probPrefabs;


    // Start is called before the first frame update
    void Start()
    {
        SpawnProps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProps()
    {
        foreach (GameObject sp in probSpawnPoints)
        {
            int rand = Random.Range(0, probPrefabs.Count);
            GameObject prob = Instantiate(probPrefabs[rand], sp.transform.position, Quaternion.identity);
            prob.transform.parent = sp.transform;

        }
    }
}

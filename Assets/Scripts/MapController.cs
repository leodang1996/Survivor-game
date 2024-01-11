using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] List<GameObject> terrainChunk;
    [SerializeField] GameObject player;
    [SerializeField] float checkerRadius;
    [SerializeField] LayerMask terrainMask;

    PlayerMovement pm;
    Vector3 noTerrainPosition;
    void Awake()
    {
       pm = FindObjectOfType<PlayerMovement>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
    }
    void ChunkChecker()
    {
        if(pm.moveDirection.x > 0 || pm.moveDirection.y == 0) //right
        {
            if (Physics2D.OverlapCircle(player.transform.position + new Vector3(20, 0, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(20, 0, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.x < 0 || pm.moveDirection.y == 0) //left
        {
            if (Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, 0, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-20, 0, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.x == 0 || pm.moveDirection.y > 0) //up
        {
            if (Physics2D.OverlapCircle(player.transform.position + new Vector3(0, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(0, 20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.x == 0 || pm.moveDirection.y < 0) //down
        {
            if (Physics2D.OverlapCircle(player.transform.position + new Vector3(0, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(0, -20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.x > 0 || pm.moveDirection.y > 0) //right up
        {
            if (Physics2D.OverlapCircle(player.transform.position + new Vector3(20, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(20, 20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.x > 0 || pm.moveDirection.y < 0) //right down
        {
            if (Physics2D.OverlapCircle(player.transform.position + new Vector3(20, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(20, -20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.x < 0 || pm.moveDirection.y > 0) //left up
        {
            if (Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-20, 20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDirection.x < 0 || pm.moveDirection.y < 0) //left down
        {
            if (Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-20, -20, 0);
                SpawnChunk();
            }
        }

    }

    void SpawnChunk()
    {
        Debug.Log("SpawnMap");
        int rand = Random.Range(0, terrainChunk.Count);
        Instantiate(terrainChunk[rand], noTerrainPosition, Quaternion.identity);
    }
}

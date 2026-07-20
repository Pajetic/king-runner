using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform chunkParent;
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private int initialChunkNum = 12;
    [SerializeField] private float chunkLength = 10f;
    [SerializeField] private float moveSpeed = 10f;
    
    private List<GameObject> chunkList = new List<GameObject>();

    private void Start()
    {
        SpawnInitialChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    private void SpawnInitialChunks()
    {
        for (int chunkNum = 0; chunkNum < initialChunkNum; chunkNum++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, CalculateSpawnPosZ());
        chunkList.Add(Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent));
    }

    private float CalculateSpawnPosZ()
    {
        if (chunkList.Count == 0)
        {
            return transform.position.z;
        }
        
        return chunkList[chunkList.Count - 1].transform.position.z + chunkLength;
    }

    private void MoveChunks()
    {
        for (int chunkNum = chunkList.Count - 1; chunkNum >= 0; chunkNum--)
        {
            GameObject chunk = chunkList[chunkNum];
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if (chunk.transform.position.z < Camera.main.transform.position.z - chunkLength)
            {
                chunkList.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}

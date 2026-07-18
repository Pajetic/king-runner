using UnityEngine;
using UnityEngine.Serialization;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform chunkParent;
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private int initialChunkNum = 12;
    [SerializeField] private float chunkLength = 10f;

    private void Start()
    {
        float spawnPosZ;
        Vector3 chunkSpawnPos;
        for (int i = 0; i < initialChunkNum; i++)
        {
            spawnPosZ = transform.position.z + chunkLength * i;
            
            chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPosZ);
            Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
        }
        
        
    }
}

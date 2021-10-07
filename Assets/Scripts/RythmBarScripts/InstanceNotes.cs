using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class InstanceNotes : MonoBehaviour
{
    public GameObject prefab;
    public GameObject instanceOn;
    
    [Range(0, 16)]
    public int numberToCreate;
    
      private void Start()
      {
          InstanceObjects();
      }
      
    public void InstanceObjects()
    {
        MeshCollider spawnArea = instanceOn.GetComponent<MeshCollider>();
        float areaX, areaY;
        Vector2 pos;
        
        for (int i = 0; i < numberToCreate; i++)
        {
            areaX = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            areaY = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            pos = new Vector2(areaX, areaY);
            Instantiate(prefab,  instanceOn.transform);
        }
    }
}

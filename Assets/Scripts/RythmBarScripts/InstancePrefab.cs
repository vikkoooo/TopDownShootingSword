using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RythmBarScripts
{
    public class InstancePrefab : MonoBehaviour
    {
        public GameObject prefab;
        public GameObject area;
    
        [Range(0, 16)]
        public int numberToCreate;
        
        public void InstanceObjects()
        {
            BoxCollider2D spawnArea = area.GetComponent<BoxCollider2D>();
            float areaX, areaY;
            Vector2 pos;
            
            for (int i = 0; i < numberToCreate; i++)
            {
                areaX = spawnArea.bounds.min.x + ( spawnArea.bounds.max.x - spawnArea.bounds.min.x ) / numberToCreate * i;
                areaY = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                pos = new Vector2(areaX, areaY);
                Instantiate (prefab, pos, new Quaternion(), area.transform);
            }
        }
    }
}

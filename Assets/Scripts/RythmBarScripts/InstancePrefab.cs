using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RythmBarScripts
{
    public class InstancePrefab : MonoBehaviour
    {
        public GameObject prefab;
        public GameObject instanceOn;
    
        [Range(0, 16)]
        public int numberToCreate;
    
        private void Start()
        {
            InstanceObjects();
        }

        private void Update()
        {
            
        }

        public void InstanceObjects()
        {
            // BoxCollider2D spawnArea = instanceOn.GetComponent<BoxCollider2D>();
            // GameObject instance;
            // float areaX, areaY;
            // Vector2 pos;
        
            for (int i = 0; i < numberToCreate; i++)
            {
                // instance = prefab;
                // areaX = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                // areaY = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                // Debug.Log($"Xarea={areaX},Yarea={areaY}");
                // pos = new Vector2(areaX, areaY);
                Instantiate(prefab, instanceOn.transform);
            }
        }
    }
}
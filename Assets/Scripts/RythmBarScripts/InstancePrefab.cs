using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RythmBarScripts
{
    public class InstancePrefab : MonoBehaviour
    {
        public GameObject prefab;
        public GameObject area;
        // private BoxCollider2D area_collider;
    
        [Range(0, 16)]
        public int numberToCreate;
    
        private void Start()
        {
            // area_collider = area.GetComponent<BoxCollider2D>();
            InstanceObjects();
        }
        
        public void InstanceObjects()
        {
            // BoxCollider2D spawnArea = area.GetComponent<BoxCollider2D>();
            // GameObject instance;
            // float areaX, areaY;
            // Vector3 pos;
            //
            // for (int i = 0; i < numberToCreate; i++)
            // {
            //     instance = prefab;
            //     // areaX = spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            //     areaY = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            //     pos = new Vector3(areaX, areaY, 0);
            //     Instantiate(prefab, pos, new Quaternion());
            // }
        }
        
        // private Vector2 RandomizePosition(BoxCollider2D area)
        // {
        //     Vector2 minBounds = area.bounds.min;
        //     Vector2 maxBounds = area.bounds.max;
		      //
        //     float x = Random.Range(minBounds.x, maxBounds.x);
        //     float y = Random.Range(minBounds.y, maxBounds.y);
        //
        //     return new Vector2(x, y);
        // }
        
    }
}

// Diffen mellan max och min 
//
// Placera ut instanser, på en grid, inte ha samma y värde som någon annan, och randomize position vid varje start
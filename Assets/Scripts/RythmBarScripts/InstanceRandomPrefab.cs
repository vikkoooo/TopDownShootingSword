using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RythmBarScripts
{
    public class InstanceRandomPrefab : MonoBehaviour
    {
        public GameObject[] prefabs;
        public Transform area;


        private void Start()
        {
            InstanceObjects();
        }
        
        public void InstanceObjects()
        {
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], area.transform);
        }
    }
}


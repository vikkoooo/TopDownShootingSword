using UnityEngine;
using UnityEngine.UI;

public class InstanceOnGrid : MonoBehaviour
{
    public GameObject prefab;
    [Range(3, 48)]
    public int numberToCreate;
    
    public void InstanceObjects()
    {
        GameObject newObject;
        for (int i = 0; i < numberToCreate; i++)
        {
            newObject = Instantiate(prefab, transform);
        }
    }
}

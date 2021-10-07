using UnityEngine;
using UnityEngine.UI;

public class InstanceNotes : MonoBehaviour
{
    public GameObject prefab;
    public Transform instanceOn;
    [Range(0, 16)]
    public int numberToCreate;
    
    public void InstanceObjects()
    {
        GameObject newInstance;
        for (int i = 0; i < numberToCreate; i++)
        {
            newInstance = Instantiate(prefab, instanceOn);
        }
    }
}

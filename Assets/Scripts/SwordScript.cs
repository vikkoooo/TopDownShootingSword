using UnityEngine;

public class SwordScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.CompareTag("Player"))
        {
            Debug.Log("Player gick på svärd!");
        }    
    }

}

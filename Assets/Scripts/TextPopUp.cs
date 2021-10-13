using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopUp : MonoBehaviour
{
    private float time = 3f;
    public Vector3 offset = new Vector3(0, 2, 0);
    void Start()
    {
        Destroy(gameObject, time);
        transform.localPosition += offset;
    }
}

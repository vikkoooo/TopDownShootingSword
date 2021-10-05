using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // The object the camera should follow
    private Vector3 offset; // Keep original offset and tweak possible

    void Start()
    {
        offset = this.transform.position - player.transform.position;
    }

    // LateUpdate looks to be common when controlling cameras
    void LateUpdate()
    {
        this.transform.position = player.transform.position + offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float xOffset;
    public float zOffset;
    public float YOffset;
    public float Xangle;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
        offset.x = xOffset;
        offset.y = YOffset;
        offset.z = zOffset;

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x + Xangle,
            transform.eulerAngles.y,
            transform.eulerAngles.z
            );
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position - offset;
    }
}

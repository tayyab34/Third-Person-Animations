using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontallook = Input.GetAxis("Mouse X");
        float verticallook = Input.GetAxis("Mouse Y");
        ////cam.transform.position = player.transform.position + offset;
        //cam.rotation = Quaternion.Euler(verticallook, horizontallook, 0);
        player.Rotate(Vector3.up * horizontallook);
        Vector3 dirOffset = player.transform.TransformDirection(offset);
        cam.transform.position = player.transform.position + dirOffset;
    }
}

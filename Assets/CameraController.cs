using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    public Vector3 offset;
    public Transform Gun;
    private float yrotation;
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
        //yrotation-=verticallook;
        //cam.rotation = Quaternion.Euler(yrotation,0, 0);
        player.Rotate(Vector3.up * horizontallook);
        player.Rotate(Vector3.right * -verticallook);
        Vector3 dirOffset = player.transform.TransformDirection(offset);
        cam.transform.position = player.transform.position + dirOffset;
        if (Input.GetKey(KeyCode.Tab))
        {
            cam.transform.position = player.transform.position+new Vector3(0.95f,1.36f,0.26f);
        }
    }
    
}

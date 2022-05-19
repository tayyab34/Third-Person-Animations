using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public LayerMask layer;
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        SphereCast();
        CastRay();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        anim.SetFloat("Mouse X", horizontal);
        anim.SetFloat("Mouse Y", vertical);
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }
    void SphereCast()
    {
        RaycastHit hit;
        if(Physics.SphereCast(transform.position+Vector3.up,0.05f,transform.forward,out hit, 1f,layer,QueryTriggerInteraction.UseGlobal))
        {
            Debug.Log(hit.transform.name);
            Destroy(hit.transform.gameObject);
            anim.SetBool("Jump", true);
        }
    }
    void CastRay()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit attack;
            if (Physics.Raycast(ray, out attack, Mathf.Infinity))
            {
                Destroy(attack.transform.gameObject);
            }
        }
        
    }
}

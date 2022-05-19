using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent nav;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float rand_Radius = Random.Range(3, 10000);

        Vector3 randDir = Random.insideUnitSphere * rand_Radius;
        randDir += transform.position;
        nav.SetDestination(randDir);

        SphereCast();
        
    }
    void SphereCast()
    {
        RaycastHit hitinfo;
        if (Physics.SphereCast(transform.position + Vector3.up, 0.05f, transform.forward, out hitinfo, 1f, layer, QueryTriggerInteraction.UseGlobal))
        {
            Debug.Log(hitinfo.transform.name);
            Destroy(hitinfo.transform.gameObject);
        }
    }
}

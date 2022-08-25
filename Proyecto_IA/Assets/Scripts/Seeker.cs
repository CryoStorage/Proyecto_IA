using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{

    [SerializeField] GameObject target;
    [SerializeField] private float speed;
    Vector3 dir = (Vector3.zero);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    Vector3 Seek(Vector3 targetPos)
    {

        Vector3 desiredV = targetPos - transform.position;
        Vector3 steeringForce = desiredV + dir;
        Vector3 result = (Vector3.Normalize((desiredV + steeringForce) * speed));
        return result;
    }

    void Move()
    {
        Vector3 steering = Seek(target.transform.position);
        transform.position += (dir + steering) * Time.deltaTime;

    }
}

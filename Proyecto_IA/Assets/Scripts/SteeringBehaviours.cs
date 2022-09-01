using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour
{

    protected Vector3 targetVector;
    public Vector3 target;
    bool needsTarget;
    [SerializeField] private float speed;
    [SerializeField] private float mass;
    Vector3 currentVector;

    // Start is called before the first frame update
    void Start()
    {
        Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        // mathF.clamp()
    }

    Vector3 Seek(Vector3 targetPos)
    {
        Vector3 distanceVector = targetPos - transform.position;
        Vector3 steeringForce = distanceVector + currentVector;
        Vector3 result = Vector3.Normalize(distanceVector + steeringForce);
        return result;
    }

    public virtual Vector3 Flee(Vector3 targetPos)
    {
        Vector3 distanceVector = transform.position - targetPos;
        Vector3 steeringForce = distanceVector + currentVector;
        Vector3 result = Vector3.Normalize(distanceVector + steeringForce);
        return result;

    }

    float Arrival(Vector3 targetPos)
    {
        float result;
        Vector3 distanceVector = targetPos - transform.position;
        switch (distanceVector.magnitude)
        {
            case float n when(n > 30f):
                result = 0f;
                break;

            case float n when(n < 30f && n > 20f):
                 result = 3f;
                 break;

            case float n when (n < 20 && n > 10):
                result = 2f;
                break;
            
            case float n when (n < 10 && n > 0):
                result = .33f;
                break;

            default:
                result = 0f;
                break; 
        }
        return result;
    }

    void Prepare()
    {
        if (needsTarget && target == null)
        {
            try
            {
                GameObject.Find("Target");
            }
            catch
            {
                Debug.LogWarning("Could not locate target");
            }
        }else
        {
            return;
        }

    }
    

    void Move()
    {

        Vector3 steering = Seek(targetVector);
        speed = Arrival(targetVector) * mass;
        transform.position += (currentVector + steering * speed) * Time.fixedDeltaTime;

    }
}
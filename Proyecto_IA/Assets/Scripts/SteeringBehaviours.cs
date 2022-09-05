using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour
{
    
    [HideInInspector]public Vector3 targetVector;
    bool needsTarget = true;
    private float speed;
    [SerializeField] private float mass;
    [SerializeField] string behaviour = "seek";
    Vector3 currentVector;

    Vector3 minVector = new Vector3(-71.1699982f,-39f,1.799999f);
    Vector3 maxVector = new Vector3(71.1699982f,41.0009995f,1.799999f);
    // Start is called before the first frame update
    void Start()
    {
        GetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Mathf.Clamp(transform.position.x, minVector.x, maxVector.x);
        Mathf.Clamp(transform.position.y, minVector.y, maxVector.y);
    }

    Vector3 Seek(Vector3 targetPos)
    {
        Vector3 distanceVector = targetPos - transform.position;
        Vector3 steeringForce = distanceVector + currentVector;
        Vector3 result = Vector3.Normalize(distanceVector + steeringForce);
        return result;
    }

    Vector3 Flee(Vector3 targetPos)
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

    void Move()
    {
        Vector3 steering;
        switch(behaviour)
        {
            case "seek":
            needsTarget = true;
            GetTarget();
            steering = Seek(targetVector);
            break;

            case "flee":
            needsTarget = true;
            GetTarget();
            steering = Flee(targetVector);
            break;

            case "wander":
            steering = Flee(targetVector);
            break;

            default:
            steering = Vector3.zero;
            break;
        }
        speed = Arrival(targetVector) * mass;
        transform.position += (currentVector + steering * speed) * Time.fixedDeltaTime;

        if (transform.position.x < -71.17 || transform.position.x > 71.17)
        {
            Vector3 boundPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            transform.position = boundPos;
        }

        
    }

    Vector3 Wander(Vector3 targetPos)
    {
        Vector3 distanceVector = targetPos - transform.position;
        Vector3 steeringForce = distanceVector + currentVector;

        Vector3 result = Vector3.Normalize(distanceVector + steeringForce);
        return result;


    }

    void RandomizeTarget()
    {
        for (int i = 0; i < 2; i++)
        {
            float r = Random.Range(10,40);
            Vector3 randomTarget = new Vector3 (r,r,r);
            Debug.Log("Randomized to: " + randomTarget.x +randomTarget.y + randomTarget.z);
        }

    }

    IEnumerator CorRandomize()
    {
        while (true)
        {
            RandomizeTarget();
            yield return new WaitForSeconds(2);
        }
    }

    void GetTarget()
    {
        if (needsTarget)
        {
            try
            {
                targetVector = GameObject.Find("Target").transform.position;

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
}

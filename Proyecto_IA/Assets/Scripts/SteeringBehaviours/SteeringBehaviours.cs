using UnityEngine;

public class SteeringBehaviours : MonoBehaviour
{
    public float Speed = 4f;
    [SerializeField]public float wanderCircleDistance = 1f;
    [SerializeField]public float circleRadius = 1f;
    public GameObject target;
    public Vector3 CurrentVector;
    public bool dynamicPursuit;
    public bool dynamicAvoid;
    
    //SteeringBehaviours returns normalized vectors
    public Vector3 Seek(Vector3 targetPos)
    {
        Vector3 distanceVector = targetPos - transform.position;
        Vector3 steeringForce = distanceVector + CurrentVector;
        Vector3 result = Vector3.Normalize(distanceVector + steeringForce);
        return result;
    }
    public Vector3 Flee(Vector3 targetPos)
    {
        Vector3 result = Seek(targetPos) * -1;
        return result;
    }
    public float Arrival(Vector3 targetPos)
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
                result = 1f;
                break; 
        }
        return result;
    }
    public Vector3 Pursuit(Vector3 targetPos)
    {
        float t = 5;
        if (dynamicPursuit)
        {
            t = (targetPos - transform.position).magnitude / Speed;
        }
        Vector3 targetFrameVelocity = target.GetComponent<Mouse_Follow>().velocity;
        Vector3 futureTarget = targetPos + targetFrameVelocity * t;
        Vector3 result = Seek(futureTarget);
        return result;
    }
    public Vector3 Avoidance(Vector3 targetPos)
    {
        float t = 5;
        if (dynamicAvoid)
        {
            t = (targetPos - transform.position).magnitude / Speed;
        }
        Vector3 targetFrameVelocity = target.GetComponent<Mouse_Follow>().velocity;
        Vector3 futureTarget = targetPos + targetFrameVelocity * t;
        Vector3 result = Flee(futureTarget);
        return result;
    }
    public Vector3 Wander(Vector3 targetPos)
    {
        Vector3 circleCenter = (targetPos + CurrentVector.normalized) * wanderCircleDistance;
        Vector3 rotVector = Quaternion.AngleAxis(0f, Vector3.forward) * CurrentVector.normalized;
        Vector3 targetOnCircle = circleCenter + (rotVector * circleRadius);

        Vector3 result = (Seek(targetOnCircle));
        return result;
    }
}

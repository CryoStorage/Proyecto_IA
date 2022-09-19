using UnityEngine;

public class SteeringBehaviours : MonoBehaviour
{
    protected float speed = 4f;
    protected Vector3 currentVector;
    public GameObject target;
    public bool dynamicPursuit;
    
    //SteeringBehaviours returns normalized vectors
    protected Vector3 Seek(Vector3 targetPos)
    {
        Vector3 distanceVector = targetPos - transform.position;
        Vector3 steeringForce = distanceVector + currentVector;
        Vector3 result = Vector3.Normalize(distanceVector + steeringForce);
        return result;
    }
    protected Vector3 Flee(Vector3 targetPos)
    {
        Vector3 result = Seek(targetPos) * -1;
        return result;
    }
    protected float Arrival(Vector3 targetPos)
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

    protected Vector3 Pursuit(Vector3 targetPos)
    {
        float t = 5;
        if (dynamicPursuit)
        {
            t = (targetPos - transform.position).magnitude / speed;
            
        }
        
        Vector3 targetFrameVelocity = target.GetComponent<Mouse_Follow>().velocity;
        Vector3 futureTarget = targetPos + targetFrameVelocity * t;
        Vector3 result = Vector3.Normalize(Seek(futureTarget));
        return result;
    }
    
    // Wandering behaviour shelved for now
    // protected Vector3 Wander(Vector3 targetPos)
    // {
    //     Vector3 distanceVector = targetPos - transform.position;
    //     Vector3 steeringForce = distanceVector + currentVector;
    //
    //     Vector3 result = Vector3.Normalize(distanceVector + steeringForce);
    //     return result;
    //
    //
    // }
    // public void RandomizeTarget()
    // {
    //     for (int i = 0; i < 2; i++)
    //     {
    //         float r = Random.Range(10,40);
    //         Vector3 randomTarget = new Vector3 (r,r,r);
    //         Debug.Log("Randomized to: " + randomTarget.x +randomTarget.y + randomTarget.z);
    //     }
    //
    // }
    //
    // public IEnumerator CorRandomize()
    // {
    //     while (true)
    //     {
    //         RandomizeTarget();
    //         yield return new WaitForSeconds(2);
    //     }
    // }
    
}

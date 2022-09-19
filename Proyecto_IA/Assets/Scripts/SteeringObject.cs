using UnityEngine;

public class SteeringObject : SteeringBehaviours
{
    [SerializeField] private float mass;
    [SerializeField] private string behaviour;

    private Vector3 steering;
    // Update is called once per frame
    void Update()
    {
        Move();

    }
    void Move()
    {
        Vector3 steering;
        switch(behaviour)
        {
            case "seek":
                steering = Seek(target.transform.position);
                break;

            case "flee":
                steering = Flee(target.transform.position);
                break;

            case "wander":
                steering = Flee(target.transform.position);
                break;
            
            case "pursuit":
                steering = Pursuit(target.transform.position);
                break;
            
            case "avoidance":
                steering = Flee(target.transform.position);
                break;

            default:
                steering = Vector3.zero;
                break;
        }
        

        //speed = Arrival(targetVector) * mass;
        transform.position += (currentVector + steering * speed) * Time.fixedDeltaTime;
    }
}

using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class SteeringObject : SteeringBehaviours
{
    [SerializeField] private float mass;
    [SerializeField] private string behaviour;
    private Vector3 wanderTarget;
    private Vector3 steering;

    private void Start()
    {
        StartCoroutine(CorRandomize());
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public IEnumerator CorRandomize()
    {
        while (true)
        {
            RandomizeTarget();
            yield return new WaitForSeconds(2);
        }
    }  
    public void RandomizeTarget()
    {
        float x = Random.Range(10,40);
        float y = Random.Range(10,40);
        float z = Random.Range(10,40);
        wanderTarget = new Vector3(x, y, z);
    }
    void Move()
    {
        switch(behaviour)
        {
            case "seek":
                steering = Seek(target.transform.position);
                break;

            case "flee":
                steering = Flee(target.transform.position);
                break;

            case "wander":
                steering = Wander(wanderTarget);
                break;
            
            case "pursuit":
                steering = Pursuit(target.transform.position);
                break;
            
            case "avoidance":
                steering = Avoidance(target.transform.position);
                break;

            default:
                steering = Vector3.zero;
                break;
        }
        speed = Arrival(target.transform.position) * mass;
        transform.position += currentVector + steering * (speed * Time.fixedDeltaTime);
        currentVector = steering * (speed * Time.fixedDeltaTime);
    }
}

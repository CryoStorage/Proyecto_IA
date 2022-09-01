using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : SteeringBehaviours
{
    Vector3 randomTarget;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CorRandomize());
    }

    // Update is called once per frame
    void Update()
    {
        
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
}

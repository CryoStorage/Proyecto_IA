using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Follow : MonoBehaviour
{
    private Vector3 screnPos;
    private Vector3 worldPos;
    private Vector3 prevPos;
    public Vector3 velocity;
    private float offset = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseToWorld();
        GetVelocity();
    }

    void MouseToWorld()
    {
        screnPos = Input.mousePosition;
        screnPos.z = Camera.main.nearClipPlane + offset;
        worldPos = Camera.main.ScreenToWorldPoint(screnPos);
        transform.position = worldPos;

    }

    private void GetVelocity()
    {
        
        velocity = transform.position - prevPos / Time.deltaTime;
        velocity = Vector3.Lerp(transform.position, prevPos, 0.1f);
        prevPos = transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Follow : MonoBehaviour
{
    Vector3 screnPos;
    Vector3 worldPos;
    float offset = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseToWorld();
    }

    void MouseToWorld()
    {
        screnPos = Input.mousePosition;
        screnPos.z = Camera.main.nearClipPlane + offset;
        worldPos = Camera.main.ScreenToWorldPoint(screnPos);
        transform.position = worldPos;

    }
}

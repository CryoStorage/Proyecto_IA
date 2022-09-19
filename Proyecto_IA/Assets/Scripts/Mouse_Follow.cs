using UnityEngine;

public class Mouse_Follow : MonoBehaviour
{
    private Vector3 screnPos;
    private Vector3 worldPos;
    private Vector3 prevPos;
    public Vector3 velocity;
    private float offset = 30;
    private Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera != null) return;
        try
        {
            mainCamera = Camera.main;
        }
        catch { Debug.Log("Could not find Camera.main"); }
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
        screnPos.z = mainCamera.nearClipPlane + offset;
        worldPos = mainCamera.ScreenToWorldPoint(screnPos);
        transform.position = worldPos;

    }
    private void GetVelocity()
    {
        velocity = transform.position - prevPos / Time.deltaTime;
        velocity = Vector3.Lerp(transform.position, prevPos, 0.1f);
        prevPos = transform.position;
    }
}

using UnityEngine;

public class Mouse_Follow : MonoBehaviour
{
    protected Vector3 _screenPos;
    protected Vector3 _worldPos;
    protected Vector3 _prevPos;
    [HideInInspector]public Vector3 velocity;
    protected float _offset = 30;
    protected Camera _mainCamera;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Prepare();
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position = MouseToWorld();
        GetVelocity();
    }
    protected Vector3 MouseToWorld()
    {
        _screenPos = Input.mousePosition;
        _screenPos.z =_mainCamera.nearClipPlane + _offset;
        _worldPos =_mainCamera.ScreenToWorldPoint(_screenPos);
        return _worldPos;

    }
    protected void GetVelocity()
    {
        velocity = transform.position - _prevPos / Time.deltaTime;
        velocity = Vector3.Lerp(transform.position, _prevPos, 0.1f);
        _prevPos = transform.position;
    }

    protected virtual void Prepare()
    {
        if (_mainCamera != null) return;
        try
        {
            _mainCamera = Camera.main;
        }
        catch { Debug.Log("Could not find Camera.main"); }
        
    }
}

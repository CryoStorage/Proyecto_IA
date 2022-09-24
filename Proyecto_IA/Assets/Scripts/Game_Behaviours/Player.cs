using System;
using UnityEngine;
using System.Collections.Generic;

public class Player : Mouse_Follow
{
    private SteeringBehaviours _steeringBehaviours;
    private Vector3 _targetPos;
    private Vector3 _steering;
    [SerializeField] private float _speed;

    protected override void Start()
    {
        base.Start();
        Prepare();
        _targetPos = transform.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        Move();
        SetTargetPos();

    }

    void Move()
    {
        float targetDistance = Vector3.Distance(transform.position, _targetPos);
        switch (targetDistance)
        {
            case > 0.1f:
                _steering = _steeringBehaviours.Seek(_targetPos);
                break;
            case < 0.1f:
                _steering = Vector3.zero;
                break;
            default:
                _steering = Vector3.zero;
                break;
        }
        transform.position += Vector3.Lerp(transform.position,_steering * (_speed * Time.fixedDeltaTime),1.3f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -20f, 20f),
            Mathf.Clamp(transform.position.y, -10f, 10), transform.position.z);
    }

    void SetTargetPos()
    {
        if (Input.GetMouseButton(1))
        {
            _targetPos = MouseToWorld();
        }
    }

    protected override void Prepare()
    {
        Application.targetFrameRate = 60;
        base.Prepare();
        if (_steeringBehaviours != null) return;
        try
        {
            _steeringBehaviours = GetComponent<SteeringBehaviours>();
        }
        catch { Debug.LogWarning("could not find SteeringBehaviours"); }
    }
}

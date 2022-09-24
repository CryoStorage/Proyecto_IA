using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : SteeringObject
{
    
    private Player_CollectibleManager _collectibleManager;
    private bool _isFollower;
    private MeshRenderer _rend;

    // Start is called before the first frame update
    void Start()
    {
        Prepare();
        target = gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        if (_isFollower) return;
        StartFollow();
 
    }

    public void StartFollow()
    {
        if (_collectibleManager.Collectibles.Peek() == gameObject)
        {
            target = GameObject.FindGameObjectWithTag("Player");;
            behaviour = "seek";
            _isFollower = true;
            mass = 1;
            _collectibleManager.Collect(gameObject);
            _rend.material.color = Color.green;
        }
        else
        {
            mass = 1;
            target = _collectibleManager.Collectibles.Dequeue();
            behaviour = "seek";
            _isFollower = true;
            _collectibleManager.Collect(gameObject);
            _rend.material.color = Color.green;
        }
        
    }

    public void StopFollow()
    {
        target = gameObject;
        _isFollower = false;
        _collectibleManager.UnCollect(gameObject);
        _rend.material.color = Color.white;

    }

    public void StartFlee()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        behaviour = "avoidance";
        _isFollower = false;
        mass = .5f;
        _rend.material.color = Color.cyan;

    }   
    
    public void StartAvoid()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        behaviour = "avoidance";
        _isFollower = false;
        mass = .8f;
        _rend.material.color = Color.blue;

    }

    public void StartChase()
    {
        // Debug.Log("Starting chase");
        // StopAllCoroutines();
        // CorStartChase();
        target = GameObject.FindGameObjectWithTag("Player");
        behaviour = "pursuit";
        _isFollower = true;
        mass = .1f;
        dynamicAvoid = true;
        _rend.material.color = Color.red;

    }

    private void Prepare()
    {
        if (_collectibleManager != null) return;
        try
        {
            _collectibleManager = FindObjectOfType<Player>().GetComponent<Player_CollectibleManager>();
        }
        catch { Debug.LogWarning("Could not find _collectibleManager");}

        if (_rend != null) return;
        try
        {
            _rend = GetComponentInChildren<MeshRenderer>();
        }
        catch { Debug.Log("Could not find _material");}
    }
}

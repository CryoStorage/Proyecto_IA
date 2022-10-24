using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Rts_FloodPath : MonoBehaviour
{
    private Queue<Rts_Block> _frontier;
    private Dictionary<Rts_Block, Rts_Block> _path;

    private Rts_Map _map;
    private Rts_MapManager _mapManager;

    private void Awake()
    {
        Prepare();
    }


    // Update is called once per frame
    void Update()
    {
                
    }

    public void GetPath()
    {
        
        
    }

    private void GetNeighbors()
    {
        
    }

    private bool CheckLimits(int xCord, int yCord)
    {
        
        
        bool result = true;
        return result;
    }

    private void AddNext(Rts_Block block, int xCord, int yCord)
    {
        
        
    }

    private void PrintPath(Rts_Block block, int xCord, int yCord)
    {
        
        
    }
    
    private void Prepare()
    {
        try
        {
            _mapManager = GetComponent<Rts_MapManager>();
        }
        catch { Debug.Log("Could not find Rts_MapManager"); }
        try
        {
            _map  = GetComponent<Rts_Map>();
        }
        catch { Debug.Log("Could not find Rts_Map"); }
    }
}

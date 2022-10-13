using System;
using UnityEngine;

public class Rts_MapManager : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;

    private Vector2Int _size;

    private bool _iso;

    private float _offset;

    private Color _selectedColor;
    private Color _startColor;
    private Color _goalColor;

    private bool _gotSelected;

    private Rts_Terrains _terrains;
    private Rts_Map _m;
    
    void Start()
    {
        Prepare();
        Initialize();
        

        _m.Map = _m.CreateMap(blockPrefab);

    }

    void Update()
    {
        
    }

    void Initialize()
    {
        
    }

    void Prepare()
    {
            Debug.Log("Enter Prepare");
        if (_terrains != null) return;
            Debug.Log("terrains is null");
        try
        {
            Debug.Log("getting terrains");
            _terrains = GetComponent<Rts_Terrains>();
            Debug.Log("got terrains");
        }
        catch { Debug.Log("Could not find Rts_Terrains"); }
        if (_m != null) return;
            Debug.Log("m is null");
        try
        {
            Debug.Log("getting m");
            _m = GetComponent<Rts_Map>();
            Debug.Log("got m");
        }
        catch { Debug.Log("Could not find Rts_Map"); }
            Debug.Log("Exit Prepare");
    }
}

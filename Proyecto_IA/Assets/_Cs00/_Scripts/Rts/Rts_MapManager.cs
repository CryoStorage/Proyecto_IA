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
    
    private Rts_Map _m;

    [SerializeField] private bool iso;

    void Start()
    {
        Prepare();
        Initialize(iso);

    }

    void Initialize(bool isIso)
    {
        switch (isIso)
        {
            case true:
                _m.Map = _m.IsoMap(blockPrefab);
                break;
            case false:
                _m.Map = _m.FlatMap(blockPrefab);
                break;
        }
    }
    

    void Prepare()
    {
        if (_m != null) return;
        try
        {
            _m = GetComponent<Rts_Map>();
        }
        catch { Debug.Log("Could not find Rts_Map"); }
    }
}

using UnityEngine;

public class FloodFill_Tile : MonoBehaviour
{
    protected FloodFill_BoardManager BoardManager;
    [HideInInspector]public MeshRenderer meshRenderer;
    [HideInInspector]public int i;
    [HideInInspector]public int j;
    [HideInInspector] public bool filled;
    
    protected virtual void Start()
    {
        Prepare();
        GetId();
    }

    public virtual void Fill()
    {
        if (filled) return;
        meshRenderer.material.color = Color.black;
        filled = true;

    }

    void GetId()
    {
        string[] n = name.Split(",", 2);
        i = int.Parse(n[0]);
        j = int.Parse(n[1]);

    }
    
    protected virtual void Prepare()
    {
        if (meshRenderer != null) return;
        try
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        catch { Debug.LogWarning("Could not find meshRenderer"); }
    }
}

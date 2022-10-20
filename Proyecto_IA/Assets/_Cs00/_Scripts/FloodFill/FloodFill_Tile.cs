using UnityEngine;

public class FloodFill_Tile : MonoBehaviour
{
    private FloodFill_BoardManager _boardManager;
    [HideInInspector]public MeshRenderer meshRenderer;
    [HideInInspector]public int i;
    [HideInInspector]public int j;
    [HideInInspector] public bool filled;
    
    private void Start()
    {
        Prepare();
        GetId();
    }

    public void Fill()
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
            
    // public void Flood()
    // {
    //     Debug.LogFormat("flooding");
    //     Tiles[i + 1, j].GetComponent<FloodFill_Tile>().Fill();
    //     Tiles[i - 1, j].GetComponent<FloodFill_Tile>().Fill();
    //     Tiles[i, j -1].GetComponent<FloodFill_Tile>().Fill();
    //     Tiles[i, j +1].GetComponent<FloodFill_Tile>().Fill();
    //     
    // }

    void Prepare()
    {
        if (meshRenderer != null) return;
        try
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        catch { Debug.LogWarning("Could not find meshRenderer"); }
    }
}

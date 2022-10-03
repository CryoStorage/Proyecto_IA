using UnityEngine;

public class FloodFill_Tile : MonoBehaviour
{
    private FloodFill_BoardManager _boardManager;
    [HideInInspector]public MeshRenderer meshRenderer;
    [HideInInspector] public Color tileColor;
    [HideInInspector]public int i;
    [HideInInspector]public int j;
    
    private void Start()
    {
        Prepare();
        GetId();
    }

    public void Fill()
    {
        meshRenderer.material.color = Color.black;

    }

    public void Flood()
    {
        if (i == 0 && i == _boardManager.width) return;
        if (j == 0 && j == _boardManager.height) return;

        if (_boardManager.Tiles[i + 1, j + 1].GetComponent<FloodFill_Tile>().tileColor == this.tileColor) return;
        _boardManager.Tiles[i +1, j+1].GetComponent<FloodFill_Tile>().Fill();
        if (_boardManager.Tiles[i - 1, j - 1].GetComponent<FloodFill_Tile>().tileColor == this.tileColor) return;
        _boardManager.Tiles[i -1, j-1].GetComponent<FloodFill_Tile>().Fill();
        
    }

    void GetId()
    {
        string[] n = name.Split(",", 2);
        i = int.Parse(n[0]);
        j = int.Parse(n[1]);

    }

    void Prepare()
    {
        if (meshRenderer != null) return;
        try
        {
            meshRenderer = GetComponent<MeshRenderer>();
            tileColor = meshRenderer.material.color;
        }
        catch { Debug.LogWarning("Could not find meshRenderer"); }
    }
}

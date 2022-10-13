using UnityEngine;

public class FloodFill_BoardManager : MonoBehaviour
{
    public int width = 1;
    public int height = 1;
    [SerializeField] private float tileOffset = 1f;
    [SerializeField] private GameObject tile;
    public GameObject[,] Tiles;
    
    // Start is called before the first frame update
    void Start()
    {
        Centering();
        MakeTiles();    
    }
    private void Centering()
    {
        transform.position = Vector3.zero;
        
        Vector3 center = new Vector3(width *-.5f, height*.5f, 0);
        Vector3 pivot = new Vector3(transform.lossyScale.x, transform.localScale.y, 0);
        transform.position += (center);
        transform.position -= pivot *.5f;

    }
    private void MakeTiles()
    {
        Tiles = new GameObject[width,height];
        for (int i = 0; i < height; i++)
        {
            GameObject cellX = Instantiate(tile);
            cellX.name = "0," + i;
            cellX.transform.position = transform.position + Vector3.down * i * tileOffset;
            Tiles[0, i] = cellX;
            
            for (int j = 1; j < width; j++)
            {
                
                GameObject cellY = Instantiate(tile);   
                cellY.transform.position = transform.position  + Vector3.right  * j * tileOffset;
                cellY.transform.position += Vector3.down * i * tileOffset; 
                cellY.name = j +"," + i;
                Tiles[j, i] = cellY;

            }
        }
        
    }
}

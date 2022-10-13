using UnityEngine;

public class Rts_Map : MonoBehaviour
{
    public GameObject[,] Map;
    
    private int _height = 60;
    private int _width = 100;

    private Vector3 _rotX;
    private Vector3 _rotY;

    private int _offset = 1;
    private bool _iso;
    private int _order;

    private GameObject _startBlock;
    private GameObject _goalBlock;

    public GameObject[,] CreateMap(GameObject prefab, Sprite s = null, bool iso = false)
    {
        GameObject[,] Map = new GameObject[_width, _height];
        for (int i = 0; i < _height; i++)
        {
            GameObject cellX = Instantiate(prefab);
            cellX.name = "0," + i;
            cellX.transform.position = transform.position + Vector3.down * i * _offset;
            Map[0, i] = cellX;
            
            for (int j = 0; j < _width; j++)
            {
                GameObject cellY = Instantiate(prefab);   
                cellY.name = j +"," + i;
                cellY.transform.position = transform.position  + Vector3.right  * j * _offset;
                cellY.transform.position += Vector3.down * i * _offset; 
                Map[j, i] = cellY;
            }
        }
        return Map;
    }

}

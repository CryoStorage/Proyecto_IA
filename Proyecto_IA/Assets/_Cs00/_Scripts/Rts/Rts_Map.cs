using UnityEngine;

public class Rts_Map : MonoBehaviour
{
    public GameObject[,] Map;
    
    private int _height = 30;
    private int _width = 50;

    private Vector3 _rotX;
    private Vector3 _rotY;

    private float _offset = 1.1f;
    private bool _iso;
    private int _order;

    private GameObject _startBlock;
    private GameObject _goalBlock;

    public GameObject[,] CreateMap(GameObject prefab, Sprite s = null, bool iso = false)
    {
        transform.position -= new Vector3((_width *.5f) + _offset,0,0);
        transform.position += new Vector3(0, (_height*.5f) + _offset,0);
        GameObject[,] Map = new GameObject[_width, _height];
        for (int i = 0; i < _height; i++)
        {
            GameObject cellX = Instantiate(prefab);
            cellX.name = "0," + i;
            cellX.transform.position = transform.position + Vector3.down * i * _offset;
            Map[0, i] = cellX;
            
            for (int j = 1; j < _width; j++)
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

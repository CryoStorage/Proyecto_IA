using UnityEngine;

public class Rts_Map : MonoBehaviour
{
    public GameObject[,] Map;
    public Rts_Block[,] Blocks;
    private int _height = 60;
    private int _width = 60;

    private Vector3 _rotX;
    private Vector3 _rotY;

    private float _offset = 1f;
    private bool _iso;
    private int _order;

    private GameObject _startBlock;
    private GameObject _goalBlock;

    public GameObject[,] IsoMap(GameObject prefab, Sprite s = null)
    {
        Map = new GameObject[_width, _height];
        Blocks = new Rts_Block[_width, _height];
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                GameObject cell = Instantiate(prefab);
                cell.transform.SetParent(gameObject.transform);
                cell.name = j + "," + i;
                cell.transform.position = IsoTransform(i, j, cell);
                Map[j, i] = cell;
                Rts_Block block = cell.GetComponent<Rts_Block>();
                block.Rend.sortingOrder = _order;
                Blocks[j, i] = block;
                _order++;
            }
        }
        return Map;
    }

    private Vector3 IsoTransform(int xCord, int yCord, GameObject tile)
    {
        Vector3 scale = tile.transform.lossyScale;
        float newX = (xCord - yCord) * (scale.x * .69f);
        float newY = (xCord + yCord) * (scale.y * .4f);
        Vector3 result = new Vector3(newX + (_width * .16f), -newY + (_height * .5f), 0);
        return result;

    }
    
    public GameObject[,] FlatMap(GameObject prefab, Sprite s = null, bool iso = false)
    {
        transform.position -= new Vector3((_width * .5f) + _offset, 0, 0);
        transform.position += new Vector3(0, (_height * .5f) + _offset, 0);
        GameObject[,] Map = new GameObject[_width, _height];
        for (int i = 0; i < _height; i++)
        {
            GameObject cellX = Instantiate(prefab);
            cellX.name = "0," + i;
            cellX.transform.position = transform.position + (Vector3.down * i * _offset);
            Map[0, i] = cellX;

            for (int j = 1; j < _width; j++)
            {
                GameObject cell = Instantiate(prefab);
                cell.name = j + "," + i;
                cell.transform.position = transform.position + (Vector3.right * j * _offset) +
                                          (Vector3.down * i * _offset);
                Map[j, i] = cell;
            }
        }
        return Map;
    }

}

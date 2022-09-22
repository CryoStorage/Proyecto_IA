using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodFill : MonoBehaviour
{
    [SerializeField] private int width = 1;
    [SerializeField] private int height = 1;
    [SerializeField] private float tileOffset = 1f;
    [SerializeField] private GameObject tile;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[,] tiles = new GameObject[width,height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject cellY = (Instantiate(tile));
                cellY.transform.position = (transform.localScale * (i + tileOffset));
                cellY.name = i.ToString() + j.ToString();


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

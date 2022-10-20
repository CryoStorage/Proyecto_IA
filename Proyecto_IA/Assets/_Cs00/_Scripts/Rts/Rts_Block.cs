using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rts_Block : FloodFill_Tile
{
    private SpriteRenderer _rend;

    [SerializeField] private Sprite[] sprites;
    // Start is called before the first frame update
    protected override void Start()
    {
        Prepare();
        
    }

    public override void Fill()
    {
        if (filled) return;
        _rend.sprite = sprites[1];
        filled = true;
    }

    protected override void Prepare()
    {
        try
        {
            _rend = GetComponent<SpriteRenderer>();
        }
        catch { Debug.Log("Could not find SpriteRenderer");}
    }   
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rts_Block : FloodFill_Tile
{
    private SpriteRenderer _rend;
    private int _order;

    public int Order
    {
        get { return _order;}
        set { _rend.sortingOrder = value; }
    }
    public SpriteRenderer Rend { get{return _rend;}  }

    [SerializeField] private Sprite[] sprites;

    private void Awake()
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

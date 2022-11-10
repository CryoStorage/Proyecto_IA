using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rts_Block : FloodFill_Tile
{
    private Rts_Terrains _terrains;
    private Sprite[] _sprites;
    private SpriteRenderer _rend;
    private int _order;

    public int Order
    {
        get { return _order;}
        set { _rend.sortingOrder = value; }
    }
    public SpriteRenderer Rend { get{return _rend;}  }

    private void Awake()
    {
        Prepare();
    }

    public void SelectInteractions(Sprite sprite)
    {
        switch (filled)
        {
            case false:
                Select(sprite);
                break;
                
            case true:
                DeSelect(sprite);
                break;
        }
    }

    public void Fill(Sprite sprite)
    {
        _rend.sprite = _sprites[2];
    }
    private void DeSelect(Sprite sprite)
    {
        if (!filled) return;
        _rend.sprite = _sprites[0];
        filled = false;
    }
    
    private void Select(Sprite sprite)
    {
        if (filled) return;
        _rend.sprite = _sprites[1];
        filled = true;
    }


    protected override void Prepare()
    {
        try
        {
            _rend = GetComponent<SpriteRenderer>();
        }
        catch { Debug.Log("Could not find SpriteRenderer");}

        try
        {
            _terrains = GetComponent<Rts_Terrains>();
            _sprites = _terrains.sprites;
        }
        catch
        {
            Debug.Log("Could not find SpriteRenderer");
        }

    }   
}

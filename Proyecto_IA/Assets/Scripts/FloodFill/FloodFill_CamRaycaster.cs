using UnityEngine;

public class FloodFill_CamRaycaster : MonoBehaviour
{
    private bool _selected;

    public GameObject selectedTile;
    // Start is called before the first frame update
    void Start()
    {
        Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        CheckClick();
        CheckSpace();


    }

    void CheckSpace()
    {
        if (! Input.GetKeyDown (KeyCode.Space)) return;
        
    }

    void CheckClick()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        SelectTile();
    }

    void SelectTile()
    {
        if (_selected) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) return;
        try
        {
            selectedTile = hit.collider.gameObject;
            Debug.Log(selectedTile.name);
            hit.collider.gameObject.GetComponent<FloodFill_Tile>().Fill();
            _selected = true;
        }
        catch { Debug.LogWarning("not a tile"); }
    }

    void Prepare()
    {
        try
        {
            transform.position =  Camera.main.transform.position;
            transform.rotation = Camera.main.transform.rotation;
        }
        catch{ Debug.Log("Could not find Camera.main"); }
    }
}

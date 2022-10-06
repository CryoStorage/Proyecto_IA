using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketsController : MonoBehaviour
{
    private Brackets myBrackets = new Brackets();
    [SerializeField] private string BracketsValue;
    
    
    // Start is called before the first frame update
    void Start()
    {
        myBrackets.brackets = BracketsValue;
        Debug.Log(myBrackets.Show());
        Debug.Log(myBrackets.IsComplete());
        Debug.Log( BracketsValue.IndexOf(')'));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

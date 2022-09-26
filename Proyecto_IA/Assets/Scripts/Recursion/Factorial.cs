using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factorial : MonoBehaviour
{
    int result = 0;

    [SerializeField] private int n = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        result = DoFactorial(n);
        Debug.Log(result);
    }

    private int DoFactorial(int n)
    {
        if (n == 1) return 1;
        return n * (DoFactorial(n-1));
    }
}
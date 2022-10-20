using System.Collections.Generic;
using UnityEngine;

public class RecursiveFunctions : MonoBehaviour
{

    [SerializeField] private int n = 5;
    [SerializeField] private int[] array;
    [SerializeField] private List<float> floatList;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Fibonacci: "+DoFibonacci(n)); 
        Debug.Log("Factorial: " + DoFactorial(n));
        Debug.Log("ArrayCount: " + ArrayCount(array));
        Debug.Log("ListSum: " + ListSum(floatList));
    }

    
    private int DoFactorial(int aN)
    {
        if (aN == 1) return aN;
        return aN * (DoFactorial(aN-1));
    }
    
    private int DoFibonacci(int aN)
    {
        if (aN <= 1) return aN;
        return DoFibonacci(aN - 1) + DoFibonacci(aN - 2);
    
    }
    
    private int ArrayCount(int[] aArray)
    {
        if (aArray.Length == 0) return 0;
        return 1 + ArrayCount(aArray[1..]);
    }

    private float ListSum(List<float> aFloatList)
    {
        if (aFloatList.Count == 0) return 0;
        // Q: Porque no funciona de esta manera?
        //return aFloatList[0] + ListSum(aFloatList[aFloatList.Count - 1]);
        return aFloatList[0] + ListSum(aFloatList.GetRange(1, aFloatList.Count - 1));

    }

    
}
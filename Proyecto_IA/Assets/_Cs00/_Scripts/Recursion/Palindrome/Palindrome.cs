using System;
using System.Collections.Generic;
using UnityEngine;

public class Palindrome : MonoBehaviour
{
    // fields
    private int _size;
    private int _count;
    private string _palindrome;
    private string _value;
    private bool _isPalindrome;
    private Stack<char> _invert = new Stack<char>();
    public string _inverted;
    
    // Properties
    public int size(string p)
    {
        int result = p.Length;
        return result;
    }
    
    // Dictionary<char, int > Repeats(string s, Dictionary<char,int> d)
    // {
    //     if (s.Length == 0) return d;
    //     if (d.ContainsKey(s[0]))
    //     {
    //         
    //     }
    //
    // }
    //
    // int CountRepeats(Dictionary<char, int> d, int i = 0)
    // {
    //     
    //     
    // }

    public string palindrome { 
        get { return _palindrome; }
        set {
            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("No se admiten strings vacios");
            }
            _palindrome = value; 
        }        
    }
    
    public string Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public string Show()
    {
        switch (_isPalindrome)
        {
            case true:
                return palindrome;
            case false:
                return Value;
        }
    }

    public bool IsPalindrome(string s)
    {
        Invert(s);
        if (_inverted == s) return true;
        return false;
    }

    private void Invert(string s, int i = 0)
    {
        if (i == s.Length)
        {
            _inverted = SaveInverted(_invert);
            return;
        }
        _invert.Push(s[i]);
        Invert(s,i + 1);
    }

    private string SaveInverted(Stack<char> stack, string s = "")
    {
        if (stack.Count == 0) return s;
        s += _invert.Pop().ToString();
        return SaveInverted(stack, s);
    }

    // public void Remove(int iD)
    // {
    //     
    // }
    //
    // public void Add(int iD)
    // {
    //     
    // }

    public void New(string s)
    {
        switch (s)
        {
            case string p when(string.IsNullOrEmpty(p)):
                Debug.LogError("No se admiten strings vacios");
                break;
            case string p when(IsPalindrome(p)):
                palindrome = s;
                Debug.Log("new word is palindrome");
                break;
            case string p when(!IsPalindrome(p)):
                Value = s;
                Debug.Log("new word is not palindrome");
                break;
        }
    }
}

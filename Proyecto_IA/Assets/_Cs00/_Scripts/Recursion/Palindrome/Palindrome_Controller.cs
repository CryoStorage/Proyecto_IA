using System;
using UnityEngine;

public class Palindrome_Controller : MonoBehaviour
{
    private Palindrome _pal;
    [SerializeField] private string word;

    private void Start()
    {
        Prepare();
    }

    public void ShowWord()
    {
        if (_pal.IsPalindrome(word))
        {
            Debug.Log(_pal.palindrome);
        }        
        
        if (!_pal.IsPalindrome(word))
        {
            Debug.Log(_pal.Value);
        }
    }
    
    public void ShowIsPalindrome()
    {
        switch (_pal.IsPalindrome(word))
        {
            case true:
            Debug.Log(word + " Is a palindrome");
            break;
                case false:
            Debug.Log(word + " Is not a palindrome");
            break;
        }
    }    
    
    public void OverWritePalindrome()
    {
        _pal.New(word);
    }

    void Prepare()
    {
        try
        {
            _pal = GetComponent<Palindrome>();
        }
        catch { Debug.LogWarning("Could not find Palindrome");}
    }
}

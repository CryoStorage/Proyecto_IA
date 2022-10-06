public class Brackets
{
    private string _brackets;
    private int _count;
    private int _type;
    private string _values;

    private bool _open;
    private bool _close;

    public string brackets
    {
        get { return _brackets; }
        set
        {
            _brackets = value;
        }
    }
    public int count
    {
        get { return _count; }
        set
        {
            _count = value;
        }
    }
    public int type
    {
        get { return _type; }
        set
        {
            _type = value;
        }
    }
    public string values
    {
        get { return _values; }
        set
        {
            _values = value;
        }
    }

    public string Show()
    {
        return brackets;
    }
    
    public bool IsComplete(int iD = 0)
    {
        string openBrackets = "({[";
        string closeBrackets = ")}]";
        if (iD == brackets.Length) return false;

        switch (brackets.IndexOf(openBrackets[iD]))
        {
            case 0:
                return true;
                break;
            case 1:
                return true;
                break;
            case 2:
                return true;
                break;
            case 3:
                return true;
                break;
            
                default:
                return false;
        }
        
        switch (brackets.IndexOf(closeBrackets[iD]))
        {
            case 0:
                return true;
                break;
            case 1:
                return true;
                break;
            case 2:
                return true;
                break;
            case 3:
                return true;
                break;
            
                default:
                return false;
        }
        
        return IsComplete(iD + 1);

    }
    
    //
    // public string Indexes()
    // {
    //     
    //     
    // }
    //
    // public void Remove(int iD)
    // {
    //     
    //     
    // }
}

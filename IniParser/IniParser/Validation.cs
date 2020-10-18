using System.Text.RegularExpressions;

class Validation
{
    public Validation()
    {
        
    }

    private string patternSection = @"^\[\w*\]$";
    private string patternParam = @"\w+\s*=\s*[\w./]+";

    public bool IsValidSection(string s)
    {
        Regex rxSection = new Regex(patternSection, RegexOptions.IgnoreCase);
        return rxSection.IsMatch(s);
    }
    public Match PrintSection(string s)
    {
        Regex rxSetion = new Regex(patternSection, RegexOptions.IgnoreCase);
        return rxSetion.Match(s);
    }
    public bool IsValidParam(string s)
    {
        Regex rxParam = new Regex(patternParam, RegexOptions.IgnoreCase);
        return rxParam.IsMatch(s);
    }
    public Match PrintParam(string s)
    {
        Regex rxParam = new Regex(patternParam, RegexOptions.IgnoreCase);
        return rxParam.Match(s);
    }

    public string CommentCleaner(string s)
    {
        if (s.Contains(";"))
        {
            return s.Remove(s.IndexOf(";")).Trim();
        }
        return s;
    }
    
}
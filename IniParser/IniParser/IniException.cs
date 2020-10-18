using System;

class WrongEnteredException : Exception
{
    public string weeMessage(string name)
    {
        return $"Error occurred: wrong entered format or name: {name}. Should be .ini format file";
    }
    public WrongEnteredException() { }
    
}

class IncorrectStringFoundException : Exception
{
    private string line;
    public string isfeMessage()
    {
        return $"Error occurred: found a string that can not be handled:\n{line}";
    }
    public IncorrectStringFoundException(string line)
    {
        this.line = line;
    }
}

class FailToInitializeException : Exception
{
    private string filename;
    public string ftieMessage(string filename)
    {
            return $"Error occurred: failed to open/initialize {filename}";
    }
    public FailToInitializeException(string filename)
    {
        this.filename = filename;
    }
}

class MyCastException : Exception
{
    private string userType;
    private string value;

    public MyCastException(string userType, string value)
    {
        this.userType = userType;
        this.value = value;
    }

    public string mceMessage()
    {
        return $"Error occurred: can't cast {value} to {userType}";
    }

}
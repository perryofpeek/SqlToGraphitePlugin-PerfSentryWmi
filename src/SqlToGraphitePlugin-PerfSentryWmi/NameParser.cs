public class NameParser
{               
    public string Host { get; private set; }
    public string Metric { get; private set; }

    public NameParser(string separator, string name)
    {           
        if (name.Contains(separator))
        {
            var parts = name.Replace(separator, ":").Split(':');
            this.Host = parts[0];
            this.Metric = parts[1];                
        }
        else
        {
            this.Host = string.Empty;
            this.Metric = name;
        }
    }
}
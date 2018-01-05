public class MeniItem
{
    public string Text { get; set; }
    public string Url { get; set; }
    public bool IsActive { get; set; }
    public string ActiveCssClass
    {
        get
        {
            return IsActive ? "active" : ""; // vraća string "active" ako je isActive=True
        }
    }

    public MeniItem(string text, string url, bool isActive = false)
    {
        Text = text;
        Url = url;
        IsActive = isActive;
    }
}
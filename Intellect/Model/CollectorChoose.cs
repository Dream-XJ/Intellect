namespace Intellect.Model;

public class CollectorChoose
{
    public class XxlistItem
{
    /// <summary>
    /// 
    /// </summary>
    public string xx_xh { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string xx_mc { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string xx_nr { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string xx_wj { get; set; }
}

public class XtlistItem
{
    /// <summary>
    /// 
    /// </summary>
    public string xt_xh { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string xt_nr { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string xt_wj { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string xt_value { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string xt_pic { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string answer { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <XxlistItem > xxlist { get; set; }
}

public class Info
{
    /// <summary>
    /// 
    /// </summary>
    public string stid { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string st_sm { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string st_nr { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string audio { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string st_pic { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <XtlistItem > xtlist { get; set; }
}

public class Root
{
    /// <summary>
    /// 
    /// </summary>
    public string structure_type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Info info { get; set; }
}

}
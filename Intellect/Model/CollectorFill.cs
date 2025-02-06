namespace Intellect.Model;

public class CollectorFill
{
    public class StdItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string xth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string th { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ai { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string audio { get; set; }
    }

    public class Info
    {
        /// <summary>
        /// 
        /// </summary>
        public List <StdItem > std { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List <string > @ref { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string analyze { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string topic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string audio { get; set; }
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
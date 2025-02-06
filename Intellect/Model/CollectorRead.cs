namespace Intellect.Model;

public class CollectorRead
{
    public class Info
    {
        /// <summary>
        /// 
        /// </summary>
        public string translate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string video { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ai { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string analyze { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string symbol { get; set; }
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
namespace Intellect.Model;

public class CollectorDialogue
{
    public class StdItem
    {
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
        public string audio { get; set; }
    }

    public class QuestionItem
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
        public string ask { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string answer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string askaudio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string aswaudio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string analyze { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sucai { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string keywords { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string role { get; set; }
    }

    public class Info
    {
        /// <summary>
        /// 
        /// </summary>
        public List <QuestionItem > question { get; set; }
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
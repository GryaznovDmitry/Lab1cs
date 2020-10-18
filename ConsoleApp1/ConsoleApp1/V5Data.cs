using System;
using System.Numerics;

namespace GryaznovLab1
{
    public abstract class V5Data
    {
        public string InfoData { get; set; }
        public DateTime Time { get; set; }
        public V5Data(string id, DateTime t)
        {
            InfoData = id;
            Time = t;
        }
        public abstract Vector2[] NearEqual(float eps);
        public abstract string ToLongString();
        public override string ToString()
        {
            return InfoData + ", " + Time.ToString() + "\n\n";
        }
    }
}

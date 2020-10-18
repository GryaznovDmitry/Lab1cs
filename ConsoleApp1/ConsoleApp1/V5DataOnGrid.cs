using System;
using System.Collections.Generic;
using System.Numerics;

namespace GryaznovLab1
{
    public class V5DataOnGrid : V5Data
    {
        public Grid2D Net { get; set; }
        public Vector2[,] Vec { get; set; }
        public V5DataOnGrid(string id, DateTime t, Grid2D grid) : base(id, t)
        {
            Net = grid;
            Vec = new Vector2[Net.NodeNumX, Net.NodeNumY];
        }
        public void InitRandom(float minValue, float maxValue)
        {
            Random rand = new Random();
            float x, y;
            for (int i = 0; i < Net.NodeNumX; i++)
                for (int j = 0; j < Net.NodeNumY; j++)
                {
                    x = (float)rand.NextDouble();
                    y = (float)rand.NextDouble();
                    x = minValue * x + maxValue * (1 - x);
                    y = minValue * y + maxValue * (1 - y);
                    Vec[i, j] = new Vector2(x, y);
                }
        }
        public static explicit operator V5DataCollection(V5DataOnGrid data)
        {
            V5DataCollection Col = new V5DataCollection(data.InfoData, data.Time);
            Vector2 key, value;
            for (int i = 0; i < data.Net.NodeNumX; i++)
                for (int j = 0; j < data.Net.NodeNumY; j++)
                {
                    key = new Vector2(i, j);
                    value = new Vector2(data.Vec[i, j].X, data.Vec[i, j].Y);
                    Col.Dic.Add(key, value);
                }
            return Col;
        }
        public override Vector2[] NearEqual(float eps)
        {
            List<Vector2> v = new List<Vector2>();
            for (int i = 0; i < Net.NodeNumX; i++)
                for (int j = 0; j < Net.NodeNumY; j++)
                    if (Math.Abs(Vec[i, j].X - Vec[i, j].Y) <= eps)
                        v.Add(Vec[i, j]);
            Vector2[] res = v.ToArray();
            return res;
        }
        public override string ToLongString()
        {

            string str = "V5DataOnGrid\n";
            str += InfoData + " " + Time.ToString() + " " + Net.ToString() + "\n"; 
            for (int i = 0; i < Net.NodeNumX; i++)
                for (int j = 0; j < Net.NodeNumY; j++)
                {
                    str += "[" + i + ", " + j + "] " + "(" + Vec[i, j].X + ", " + Vec[i, j].Y + ")\n";
                }
            str += "\n";
            return str;
        }
        public override string ToString()
        {
            string str = "V5DataOnGrid\n";
            str += InfoData + " " + Time.ToString() + " " + Net.ToString()+ "\n";
            return str;
        }
    }
}

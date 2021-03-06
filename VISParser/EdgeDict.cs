﻿using System.Collections.Generic;

namespace VISParser
{

    public sealed class EdgeDict
    {
        Dictionary<int, Coords> ReverseEdgeDict;
        Dictionary<string, int> EdgeDictionary;
        public EdgeDict()
        {
            this.ReverseEdgeDict = new Dictionary<int, Coords>();
            this.EdgeDictionary = new Dictionary<string, int>();
            int value = 0;
            for (int row = 0; row < VISAPI.PlayerCount; row++)
            {
                for (int col = row + 1; col < VISAPI.PlayerCount; col++)
                {
                    this.ReverseEdgeDict.Add(value, new Coords(row, col));
                    this.EdgeDictionary.Add(new Coords(row, col).ToString(), value);
                    value++;
                }
            }
        }
        public Coords GetReversedEdge(int key)
        { 
            return this.ReverseEdgeDict[key];
        }
        public int GetEdgeKey(string key)
        {
            return this.EdgeDictionary[key];
        }
        public bool ContainsKey(string key)
        {
            return this.EdgeDictionary.ContainsKey(key);
        }
        public bool ContainsKey(int key)
        {
            return this.ReverseEdgeDict.ContainsKey(key);
        }
        public int Count
        {
            get
            {
                return this.EdgeDictionary.Count;
            }
        }
    }
}

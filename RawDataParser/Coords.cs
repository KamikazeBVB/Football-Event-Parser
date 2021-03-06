﻿using System;
using System.Text;

namespace RawDataParser
{
    public class Coords
    {
        //the frequnecy of the edge in some context.
        private double frequency;

        //A number that stores 1/length
        private double strength;

        public int Row { get; set; }
        public int Col { get; set; }
        public double Robustness { get; set; }
        public int StrongestCluster { get; set; }
        public double Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                this.IsStrengthSet = true;
                this.strength = value;
            }
        }


        public double Frequency
        {
            get
            {
                return this.frequency;
            }
            set
            {
                this.IsFrequencySet = true;
                this.frequency = value;
            }
        }
        public int Team
        {
            get { return this.Row % 10; }
        }
        public int Label
        {
            get
            {
                if ((Row % 2 == 0 && Col % 2 == 0)
                || (Row % 2 == 1 && Col % 2 == 1))
                    return 1;
                else
                    return -1;
            }
        }
        public bool IsStrengthSet { private set; get; }
        public bool IsFrequencySet { private set; get; }
        private void init()
        {
            this.IsFrequencySet = false;
            this.Frequency = -1;
            this.IsStrengthSet = false;
            this.strength = -1;
        }
        public Coords(int row, int col)
        {
            init();
            this.Row = row;
            this.Col = col;
        }
        public Coords(string coords)
        {
            init();
            string[] split = coords.Trim().Split(' ');
            if (split.Length != 2)
                throw new Exception("Invalid coordinates string");
            this.Row = int.Parse(split[0]);
            this.Col = int.Parse(split[1]);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.Row + " " + this.Col);
            return sb.ToString();
        }
    }
}

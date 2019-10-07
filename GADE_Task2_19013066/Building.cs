using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GADE_Task2_19013066
{
    public abstract class Building
    {
        public abstract void Save(StreamWriter writer);

        protected bool broken;
        protected int xPosBuild;//
        protected int yPosBild;//
        protected int buildHp = 30;//
        protected int maxBuildHp;//
        protected int buildFaction;
        protected string buildSymbol;

        public abstract bool BuildDeath();
        public abstract override string ToString();

        protected Building(int x, int y, int h, int f, string sy)
        {
            xPosBuild = x;
            yPosBild = y;
            buildHp = h;
            buildFaction = f;
            buildSymbol = sy;
            broken = false;

        }
    }
}

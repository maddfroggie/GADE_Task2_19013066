using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GADE_Task2_19013066
{
    class ResourceBuilding : Building
    {
        string resourceType = "sand";
        int resourcesGenerated;
        int resourcesPerRound = 5;
        int resourcesLeft = 3000;

        public ResourceBuilding(int x, int y, int h, int f, string sy) : base(x, y, h, f, sy)
        {
            
        }

        public int BuildPosX
        {
            get { return base.xPosBuild; }
            set { base.xPosBuild = value; }
        }
        public int BuildPosY
        {
            get { return base.yPosBild; }
            set { base.yPosBild = value; }
        }
        public int Health
        {
            get { return base.buildHp; }
            set { base.buildHp = value; }
        }
        public int MaxHealth
        {
            get { return base.maxBuildHp; }
        }
        public int Faction
        {
            get { return base.buildFaction; }
        }
        public string Symbol
        {
            get { return base.buildSymbol; }
        }

        public override bool BuildDeath()
        {
            return broken;
        }

        public override string ToString()
        {
            string temp = "";
            temp += buildSymbol + "Resource building ";
            temp += "Resource:";
            temp += "{" + buildSymbol + "}";
            temp += "(" + xPosBuild + "," + yPosBild + ")";
            temp += "Heath:" + buildHp + ", ";
            temp += (BuildDeath() ? " DEAD!" : ", ALIVE!");
            return temp;
        }

        public int ResourceGenerator()
        {
            resourcesGenerated += resourcesPerRound;
            resourcesLeft -= resourcesPerRound;
            return (resourcesLeft > 0) ? resourcesPerRound : 0;
             
        }

        public override void Save(StreamWriter writer)
        {
            string temp = "";
            temp += buildSymbol + "Resource building  ";
            temp += "Resource:";
            temp += "{" + Symbol + "}";
            temp += ";" + xPosBuild + ", " + yPosBild + ", ";
            temp += buildHp + ", ";
            temp += buildFaction;
            writer.WriteLine(temp);
        }
    }
}

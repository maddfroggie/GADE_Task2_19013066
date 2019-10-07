using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GADE_Task2_19013066
{
    class FactoryBuilding : Building
    {
        string unitType;
        int productSpeed;
        private int productionSpeed;
     
        public FactoryBuilding(int x, int y, int h, int f, string sy) : base(x, y, h, f, sy)
        {

        }

        public int ProductionSpeed
        {
            get { return productionSpeed; }
            set { productionSpeed = value; }
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

        public Unit SpawnPointUnitThing()
        {
            Random randy = new Random();
            double bubble = randy.NextDouble();
            double trouble = randy.NextDouble();
            int NewX = (bubble < 0.777) ? -1 : 1;
            int NewY = (bubble > 0.28) ? -1 : 1;
            if (trouble < 0.5f)
            {
                return new MeleeUnit(xPosBuild + NewX, xPosBuild + NewY, 10, 5, 2, buildFaction, "♦");
            }
            else
            {
                return new RangedUnit(xPosBuild + NewX, xPosBuild + NewY, 10, 5, 2,3, buildFaction, "♣");
            }
        }
       
        public override bool BuildDeath()
        {
            return broken;
        }

        public override string ToString()
        {
            string temp = "";
            temp += buildSymbol + "Factory ";
            temp += "Resource:";
            temp += "{" + buildSymbol + "}";
            temp += "(" + xPosBuild + "," + yPosBild + ")";
            temp += "Heath:" + buildHp + ", ";
            temp += (BuildDeath() ? " DEAD!" : ", ALIVE!");
            return temp;
        }

        public override void Save(StreamWriter writer)
        {
            string temp = "";
            temp += buildSymbol + "Factory ";
            temp += "Resource:";
            temp += "{" + Symbol + "}";
            temp += ";" + xPosBuild + ", " + yPosBild + ", ";
            temp += buildHp + ", ";
            temp += buildFaction;
            writer.WriteLine(temp);
        }
    }
}

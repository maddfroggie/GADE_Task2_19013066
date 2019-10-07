using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace GADE_Task2_19013066
{
    class Map
    {
        List<Unit> units;
        List<Building> building;
        Random r = new Random();
        int numUnits = 0;
        int numBuilding = 0;
        TextBox txtInfo;

        public List<Unit> Units
        {
            get { return units; }
            set { units = value; }
        }

        public List<Building> Buildings
        {
            get { return building; }
            set { building = value; }
        }

        public Map(int n,int nb, TextBox txt)
        {
            units = new List<Unit>();
            numUnits = n;
            txtInfo = txt;
            building = new List<Building>();
            numBuilding = nb;
        }

        public void Generate()
        {
            for (int i = 0; i < numUnits; i++)
            {
                if (r.Next(0, 2) == 0) //Generate Melee Unit
                {
                    MeleeUnit m = new MeleeUnit(r.Next(0, 20),
                                                r.Next(0, 20),
                                                100,
                                                1,
                                                20,
                                                (i % 2 == 0 ? 1 : 0),
                                                "M");
                    units.Add(m);
                }
                else // Generate Ranged Unit
                {
                    RangedUnit ru = new RangedUnit(r.Next(0, 20),
                                                r.Next(0, 20),
                                                100,
                                                1,
                                                20,
                                                5,
                                                (i % 2 == 0 ? 1 : 0),
                                                "R");
                    units.Add(ru);
                }
            }
            for (int i = 0; i < numBuilding; i++)
            {
                if (r.Next(0, 2) == 0)
                {
                    building.Add(new FactoryBuilding(r.Next(0, 20), r.Next(0, 20), 3, (i % 2 == 0 ? 1 : 0), "F"));
                }
                else
                {
                    building.Add(new ResourceBuilding(r.Next(0, 20), r.Next(0, 20), 3, (i % 2 == 0 ? 1 : 0), "R"));
                }
            }
        }

        public void Display(GroupBox groupBox)
        {
            groupBox.Controls.Clear();
            foreach (Unit u in units)
            {
                Button b = new Button();
                if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(mu.XPos * 20, mu.YPos * 20);
                    b.Text = mu.Symbol;
                    if (mu.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }
                }
                else
                {
                    RangedUnit ru = (RangedUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(ru.XPos * 20, ru.YPos * 20);
                    b.Text = ru.Symbol;
                    if (ru.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }
                }
                b.Click += Unit_Click;
                groupBox.Controls.Add(b);
            }

            foreach (Building b in building)
            {
                Button button = new Button();
                if (b is FactoryBuilding)
                {
                    FactoryBuilding bb = (FactoryBuilding)b;
                    button.Size = new Size(20, 20);
                    button.Location = new Point(bb.BuildPosX * 20, bb.BuildPosY * 20);
                    button.Text = bb.Symbol;
                    if (bb.Faction == 0)
                    {
                        button.ForeColor = Color.Red;
                    }
                    else
                    {
                        button.ForeColor = Color.Green;
                    }
                }
                else
                {
                    ResourceBuilding rb = (ResourceBuilding)b;
                    button.Size = new Size(20, 20);
                    button.Location = new Point(rb.BuildPosX * 20, rb.BuildPosY * 20);
                    button.Text = rb.Symbol;
                    if (rb.Faction == 0)
                    {
                        button.ForeColor = Color.Red;
                    }
                    else
                    {
                        button.ForeColor = Color.Green;
                    }
                }
                button.Click += Unit_Click;
                groupBox.Controls.Add(button);
            }
            foreach (Building b in building)
            {
                Button button = new Button();
                if (b is FactoryBuilding)
                {
                    FactoryBuilding bb = (FactoryBuilding)b;
                    button.Size = new Size(20, 20);
                    button.Location = new Point(bb.BuildPosX * 20, bb.BuildPosY * 20);
                    button.Text = bb.Symbol;
                    if (bb.Faction == 0)
                    {
                        button.ForeColor = Color.Red;
                    }
                    else
                    {
                        button.ForeColor = Color.Green;
                    }
                }
                else
                {
                    ResourceBuilding rb = (ResourceBuilding)b;
                    button.Size = new Size(20, 20);
                    button.Location = new Point(rb.BuildPosX * 20, rb.BuildPosY * 20);
                    button.Text = rb.Symbol;
                    if (rb.Faction == 0)
                    {
                        button.ForeColor = Color.Red;
                    }
                    else
                    {
                        button.ForeColor = Color.Green;
                    }
                }
                button.Click += Unit_Click;
                groupBox.Controls.Add(button);
            }
        }       
 
        public void Unit_Click(object sender, EventArgs e)
        {
            int x, y;
            Button b = (Button)sender;
            x = b.Location.X / 20;
            y = b.Location.Y / 20;
            foreach (Unit u in units)
            {
                if (u is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)u;
                    if (ru.XPos == x && ru.YPos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = ru.ToString();
                    }
                }
                else if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    if (mu.XPos == x && mu.YPos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = mu.ToString();
                    }
                }
            }
            foreach (Building bu in building)
            {
                if (bu is ResourceBuilding)
                {
                    ResourceBuilding ru = (ResourceBuilding)bu;
                    if (ru.BuildPosX == x && ru.BuildPosY == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = ru.ToString();
                    }
                }
                else if (bu is FactoryBuilding)
                {
                    FactoryBuilding mu = (FactoryBuilding)bu;
                    if (mu.BuildPosX == x && mu.BuildPosY == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = mu.ToString();
                    }
                }
            }
        }

        public void ReadFileSave()
        {
            units.Clear();
            building.Clear();
            StreamReader unit = new StreamReader("Save_File_Unit.txt");
            StreamReader Building = new StreamReader("Save_File_Building.txt");
            while (!unit.EndOfStream)
            {
                string line = unit.ReadLine();
                if (line.Contains("{♣}"))
                {
                    string remaining = line.Split(';')[1];
                    string[] arr = remaining.Split(',');
                    int x = int.Parse(arr[0]);
                    int y = int.Parse(arr[1]);
                    int h = int.Parse(arr[2]);
                    int s = int.Parse(arr[3]);
                    int a = int.Parse(arr[4]);
                    int ar = int.Parse(arr[5]);
                    int f = int.Parse(arr[6]);
                    units.Add(new RangedUnit(x, y, h, s, a, ar, f, "♣"));
                }
                else
                {
                    string remaining = line.Split(';')[1];
                    string[] arr = remaining.Split(',');
                    int x = int.Parse(arr[0]);
                    int y = int.Parse(arr[1]);
                    int h = int.Parse(arr[2]);
                    int s = int.Parse(arr[3]);
                    int a = int.Parse(arr[4]);
                    int ar = int.Parse(arr[5]);
                    int f = int.Parse(arr[6]);
                    units.Add(new RangedUnit(x, y, h, s, a, ar, f, "♦"));
                }
            }
            while (!Building.EndOfStream)
            {
                string line = Building.ReadLine();
                if (line.Contains("☺"))
                {
                    string remaining = line.Split(';')[1];
                    string[] arr = remaining.Split(',');
                    int x = int.Parse(arr[0]);
                    int y = int.Parse(arr[1]);
                    int h = int.Parse(arr[2]);
                    int f = int.Parse(arr[3]);
                    building.Add(new FactoryBuilding(x, y, h, f, "☺"));
                }
                else
                {
                    string remaining = line.Split(';')[1];
                    string[] arr = remaining.Split(',');
                    int x = int.Parse(arr[0]);
                    int y = int.Parse(arr[1]);
                    int h = int.Parse(arr[2]);
                    int f = int.Parse(arr[3]);
                    building.Add(new FactoryBuilding(x, y, h, f, "☻"));
                }
            }
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace GADE_Task2_19013066
{
    class GameEngine
    {
        Map map;
        private int round;
        Random r = new Random();
        GroupBox DisplayMap;
        private int Faction0 = 0;
        private int Faction1 = 0;

        public int Round
        {
            get { return round; }
        }

        public GameEngine(int numUnits, int numBuilding, TextBox txtUnitInfo, GroupBox DMap)
        {
            DisplayMap = DMap;
            map = new Map(numUnits, numBuilding, txtUnitInfo);
            map.Generate();
            map.Display(DisplayMap);

            round = 1;
        }

        public void Update()
        {
            for (int i = 0; i < map.Units.Count; i++)
            {
                if (map.Units[i] is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)map.Units[i];
                    if (mu.Health <= mu.MaxHealth * 0.25) // Run
                    {
                        mu.Move(r.Next(0, 4));
                    }
                    else
                    {
                        (Unit closest, int distanceTo) = mu.Closest(map.Units);
                        (Building bclosest, int bdistance) = mu.Closest(map.Buildings);

                        //Range
                        if (distanceTo <= mu.AttackRange)
                        {
                            mu.IsAttacking = true;
                            mu.Combat(closest);
                        }
                        else //Move
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (mu.XPos > closestMu.XPos) //N
                                {
                                    mu.Move(0);
                                }
                                else if (mu.XPos < closestMu.XPos) //S
                                {
                                    mu.Move(2);
                                }
                                else if (mu.YPos > closestMu.YPos) //W
                                {
                                    mu.Move(3);
                                }
                                else if (mu.YPos < closestMu.YPos) //E
                                {
                                    mu.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (mu.XPos > closestRu.XPos) //N
                                {
                                    mu.Move(0);
                                }
                                else if (mu.XPos < closestRu.XPos) //S
                                {
                                    mu.Move(2);
                                }
                                else if (mu.YPos > closestRu.YPos) //W
                                {
                                    mu.Move(3);
                                }
                                else if (mu.YPos < closestRu.YPos) //E
                                {
                                    mu.Move(1);
                                }
                            }
                        }

                    }
                }
                else if (map.Units[i] is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)map.Units[i];

                    (Unit closest, int distanceTo) = ru.Closest(map.Units);


                    // Range
                    if (distanceTo <= ru.AttackRange)
                    {
                        ru.IsAttacking = true;
                        ru.Combat(closest);
                    }
                    else //Move
                    {
                        if (closest is MeleeUnit)
                        {
                            MeleeUnit closestMu = (MeleeUnit)closest;
                            if (ru.XPos > closestMu.XPos) //N
                            {
                                ru.Move(0);
                            }
                            else if (ru.XPos < closestMu.XPos) //S
                            {
                                ru.Move(2);
                            }
                            else if (ru.YPos > closestMu.YPos) //W
                            {
                                ru.Move(3);
                            }
                            else if (ru.YPos < closestMu.YPos) //E
                            {
                                ru.Move(1);
                            }
                        }
                        else if (closest is RangedUnit)
                        {
                            RangedUnit closestRu = (RangedUnit)closest;
                            if (ru.XPos > closestRu.XPos) //N
                            {
                                ru.Move(0);
                            }
                            else if (ru.XPos < closestRu.XPos) //S
                            {
                                ru.Move(2);
                            }
                            else if (ru.YPos > closestRu.YPos) //W
                            {
                                ru.Move(3);
                            }
                            else if (ru.YPos < closestRu.YPos) //E
                            {
                                ru.Move(1);
                            }
                        }
                    }

                }
            }
            for (int i = 0; i < map.Buildings.Count; i++)
            {
                Building build = map.Buildings[i];
                if (build is ResourceBuilding)
                {
                    ResourceBuilding ComandCenter = (ResourceBuilding)build;
                    switch (ComandCenter.Faction)
                    {
                        case 0:
                            {
                                Faction0 += ComandCenter.ResourceGenerator();

                            }
                            break;
                        case 1:
                            {
                                Faction1 += ComandCenter.ResourceGenerator();
                            }
                            break;

                        default:
                            break;
                    }
                }
                else if (build is FactoryBuilding)
                {
                    FactoryBuilding RoboticsBay = (FactoryBuilding)build;
                    int B = RoboticsBay.Faction;
                    switch (B)
                    {
                        case 0:
                            {
                                if (Faction0 >= 5)
                                {
                                    map.Units.Add(RoboticsBay.SpawnPointUnitThing());
                                }
                            }
                            break;
                        case 1:
                            {
                                if (Faction1 >= 5)
                                {
                                    map.Units.Add(RoboticsBay.SpawnPointUnitThing());
                                }
                            }
                            break;
                        default: break;

                    }
                }

              map.Display(DisplayMap);
              round++;              
            }
        }
        public int DistanceTo(Unit a, Unit b)
        {
            int distance = 0;

            if (a is MeleeUnit && b is MeleeUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is RangedUnit && b is MeleeUnit)
            {
                RangedUnit start = (RangedUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is RangedUnit && b is RangedUnit)
            {
                RangedUnit start = (RangedUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is MeleeUnit && b is RangedUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            return distance;
        }

        public void Save()
        {
            StreamWriter Units = new StreamWriter("Save_File_Unit.txt");
            StreamWriter Building = new StreamWriter("Save_File_Building.txt");
            foreach (Unit o in map.Units)
            {
                if (o is RangedUnit)
                {
                    RangedUnit RaU = (RangedUnit)o;
                    if (RaU.IsDead)
                        continue;
                    RaU.Save(Units);
                }
                else
                {
                    MeleeUnit MaU = (MeleeUnit)o;
                    if (MaU.IsDead)
                        continue;
                    MaU.Save(Units);
                }
            }
            foreach (Building b in map.Buildings)
            {
                if (b is FactoryBuilding)
                {
                    FactoryBuilding SpawningPool = (FactoryBuilding)b;
                    if (SpawningPool.BuildDeath())

                        continue;
                    SpawningPool.Save(Building);
                }
                else
                {
                    ResourceBuilding Hatchery = (ResourceBuilding)b;
                    if (Hatchery.BuildDeath())

                        continue;
                    Hatchery.Save(Building);

                }
                Units.Close();
                Building.Close();
            }

            
        }
        public void SaveRead()
            {
                map.ReadFileSave();
            }
    }
}


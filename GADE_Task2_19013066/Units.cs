﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GADE_Task2_19013066
{
    public abstract class Unit
    {
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int maxHealth;
        protected int speed;
        protected int attack;
        protected int attackRange;
        protected int faction;
        protected string symbol;
        protected bool isAttacking;
        protected string UnitName;

        public abstract void Move(int dir);
        public abstract void Combat(Unit attacker);
        public abstract bool InRange(Unit other);

        public abstract (Unit, int) Closest(List<Unit> units);
        public abstract (Building, int) Closest(List<Building> units);

        public abstract void Death();
        public abstract override string ToString();

        public abstract void Save(StreamWriter writer);


    }
}

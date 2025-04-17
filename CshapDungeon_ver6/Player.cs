using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    internal class Player
    {
        public string name;
        public Job job;

        public int level = 1;
        public int exp = 0;
        
        public float curHp;
        public float curAtk;
        public float curDef;
        public float maxHp;
        public float maxAtk;
        public float maxDef;
        public int haveGold = 1000;

        public float MaxHp
        {
            get { return maxHp; }
            set
            {
                maxHp = value;
                curHp += value;
            }
        }

        public float MaxAtk
        {
            get { return maxAtk; }
            set
            {
                maxAtk = value;
                curAtk += value;
            }
        }

        public float MaxDef
        {
            get { return maxDef; }
            set
            {
                maxDef = value;
                curDef += value;
            }
        }

        public Inventory inventory = new Inventory();

        public void DungeonClear()
        {
            exp += 1;
            if (exp == level)
            {
                exp = 0;
                level++;
                maxAtk += 0.5f;
                maxDef += 1.0f;
            }
        }

        public void ReloadStat()
        {
            maxHp = inventory.itemHp;
            maxAtk = inventory.itemAtk;
            maxDef = inventory.itemDef;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"이름 : {name}");
            Console.WriteLine($"직업 : [{job}]");
            Console.WriteLine($"레벨 : {level}");
            Console.WriteLine($"체력 : {curHp} / {maxHp}");
            Console.WriteLine($"공격력 : {curAtk}/ {maxAtk}");
            Console.WriteLine($"방어력 : {curDef} / {maxDef}");
        }

        public void AddStat(StatType statType, int stat)
        {
            switch(statType)
            {
                case StatType.Hp:
                    maxHp = stat;
                    break;
                case StatType.Atk:
                    maxAtk = stat;
                    break;
                case StatType.Def:
                    maxDef = stat;
                    break;
            }
        }

        public Player()
        {
            MaxHp = 10;
            MaxAtk = 10;
            MaxDef = 10;
        }

        public Player(Player player)
        {
            name = player.name;
            job = player.job;

            level = player.level;
            exp = player.exp;

            curHp = player.curHp;
            curAtk = player.curAtk;
            curDef = player.curDef;
            maxHp = player.maxHp;
            maxAtk = player.maxAtk;
            maxDef = player.maxDef;
            haveGold = player.haveGold;
            inventory = player.inventory;
    }

       
    }
}

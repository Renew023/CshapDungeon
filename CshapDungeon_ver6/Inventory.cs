using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    internal class Inventory
    {
        public List<Item> Item = new List<Item>();
        public Item?[] equipItem = new Item[7];
        public int itemAtk = 0;
        public int itemHp = 0;
        public int itemDef = 0;

        public Inventory()
        {
            Item = this.Item;
            equipItem = this.equipItem;
            itemAtk = this.itemAtk;
            itemHp = this.itemHp;
            itemDef = this.itemDef;
        }

        public Inventory(Inventory item)
        {
            for(int i = 0; i<item.Item.Count; i++)
            {
                Item.Add(item.Item[i]);
            }
            for(int i = 0; i<equipItem.Length; i++)
            {
                equipItem[i] = item.equipItem[i];
            }
            itemAtk = item.itemAtk;
            itemHp = item.itemHp;
            itemDef = item.itemDef;

        }

        public void ItemAdd(Item item)
        {
            Item.Add(item);
        }

        public void IsEquip(ItemType itemType) //해당 부위가 장착이 되었는가 코드
        {
            if (equipItem[(int)itemType] != null) //아이템이 해당부위에 착용하고 있다면,
            {
                Equip(equipItem[(int)itemType]); //장비를 해제하고
                equipItem[(int)itemType] = null; //비워라 그 공간을.
            }
        }

        public void OpenItem()
        {
            for(int i = 0; i < Item.Count; i++)
            {
                if (Item[i].isEquip == true) 
                {
                    Console.Write("[E] ");
                }
                Console.Write($"{i + 1}. ");
                Item[i].ItemInfo();
            }
        }

        public void Equip(Item item) //장비 착용
        {
            Console.WriteLine("라인 테스트");
            if (item.isEquip == false) //장비를 착용하지 않았다면, 
            {
                item.isEquip = true; //장비를 착용할 수 있다.
                IsEquip(item.itemType); //해당 부위에 장비를 착용했는지 확인, 만약 착용되어있다면 착용을 해제한다.
                int itemStat = 0 + item.stat;
                switch(item.itemStatType)
                {
                    case StatType.Hp:
                        itemHp += itemStat;
                        break;
                    case StatType.Atk:
                        itemAtk += itemStat;
                        break;
                    case StatType.Def:
                        itemDef += itemStat;
                        break;
                }
                 //해당 능력치를 플레이어에게 부여한다.\

                equipItem[(int)item.itemType] = item;
            }
            else
            {
                int itemStat = 0 - item.stat;

                switch (item.itemStatType)
                {
                    case StatType.Hp:
                        itemHp += itemStat;
                        break;
                    case StatType.Atk:
                        itemAtk += itemStat;
                        break;
                    case StatType.Def:
                        itemDef += itemStat;
                        break;
                }
                item.isEquip = false;
            }
        }
    }
}

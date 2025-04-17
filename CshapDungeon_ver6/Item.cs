namespace CshapDungeon_ver6
{

    internal class Item
    {
        public string itemName { get; private set; }
        public StatType itemStatType { get; private set; }
        public ItemType itemType;
        public int stat { get; private set; }
        public string itemHistory { get; private set; }
        public int price { get; set; }

        public bool isEquip = false;

        //Item의 값을 참조가 아닌 값형으로 저장하기 위해서는
        //new Item으로 재선언할 필요가 있는데 데이터를 쉽게 저장하기 위해 선언 함수를 만들어주었다.
        public Item(Item item)
        {
            itemName = item.itemName;
            itemStatType = item.itemStatType;
            stat = item.stat;
            itemHistory = item.itemHistory;
            price = item.price;
            itemType = item.itemType;
        }

        public Item(string newItemName, ItemType newItemType, StatType newItemStatType, int newStat, string newItemHistory, int newprice)
        {
            itemName = newItemName;
            itemType = newItemType;
            itemStatType = newItemStatType;
            stat = newStat;
            itemHistory = newItemHistory;
            price = newprice;
        }

        public void ItemInfo()
        {
            if (isEquip == true)
            {
                Console.Write("[E] ");
            }
            Console.WriteLine($"{itemName} || {itemType} || {itemStatType}: {stat} || {itemHistory} || {price}G");
        }
    }
}

using System.Diagnostics;

namespace CshapDungeon_ver2
{
    internal class Program
    {
        //구현한 파트는 크게 8개로 나눌 수 있다.
        //Intro(게임시작)
        //NameSelect(이름선택)
        //Village(마을)
        //1. Status(상태창 보기)
        //2. Inventory(인벤토리 보기)
        //3. Shop(상점 보기)
        //2-1. Inventory-Equip (장비 착용)
        //3-1. Shop-ItemBuy (아이템 구매)

        //현재 활성화 되지 않은 파트 
        // 2-1. Equip, 3-1. ItemBuy
        // 사유. 아이템 관리 방법 찾아보려고
        // 도전 기능 가이드 : 배열을 활용한 아이템 관리
        
        //스탯의 종류
        enum StatType
        {
            HP = 1, //체력
            ATK,    //공격력
            DEF,    //방어력
            SPD     //속도
        }

        //아이템 클래스
        public class Item
        {
            public string itemName { get; private set; }
            public int itemStatType { get; private set; }
            public int stat { get; private set; }
            public string itemHistory { get; private set; }

            public bool isEquip = false; 

            //Item의 값을 참조가 아닌 값형으로 저장하기 위해서는
            //new Item으로 재선언할 필요가 있는데 데이터를 쉽게 저장하기 위해 선언 함수를 만들어주었다.
            public Item(Item item)
            {
                itemName = item.itemName;
                itemStatType = item.itemStatType;
                stat = item.stat;
                itemHistory = item.itemHistory;
            }

            public Item(string newItemName, int newItemStatType, int newStat, string newItemHistory)
            {
                itemName = newItemName;
                itemStatType = newItemStatType;
                stat = newStat;
                itemHistory = newItemHistory;
            }
            public void Answer()
            {
                Console.WriteLine($"{itemName}");
            }

        }

        //플레이어 클래스
        public class Player
        {
            public string name { get; set; }
            private int[] stats = new int[4] { 10, 10, 10, 10 }; //HP, ATK, DEF, SPD
            private int[] itemStats = new int[4] { 0, 0, 0, 0 };

            public void Equip(Item item) //장비 착용
            {
                if (item.isEquip = false) //장비를 착용하지 않았다면, 
                {
                    itemStats[item.itemStatType] += item.stat; //해당 능력치를 플레이어에게 부여한다.
                    item.isEquip = true;
                }
                else
                {
                    itemStats[item.itemStatType] -= item.stat;
                    item.isEquip = false;
                }
            }
        }

        // Ver.2 도전 목표
        // 1. 아이템의 정보를 저장할 값(Item) 생성
        // 2. 인벤토리의 아이템 정보를 저장할 배열 생성
        // 3. 상점의 아이템 정보를 저장할 배열 생성
        // [추가 도전 과제]
        // 3-1. 상점에 나오는 아이템을 특정 신호에 랜덤하게 변경.
        // 3-2. 특정 신호는 선택지에 "2. 신호" 로 추가


        static void Main(string[] args)
        {

            Player user = new Player();
            
            //총 아이템의 값은 제작자가 알 수 있음으로, 배열을 활용하여 불필요한 메모리 소모를 줄일 수 있다.
            Item[] allItem = new Item[2];
            allItem[0] = new Item("호랑이의 팬티", (int)StatType.ATK, 8, "호랑이의 털로 만든 팬티로 도깨비가 입고다닌다");
            allItem[1] = new Item("고양이의 수염", (int)StatType.DEF, 10, "고양이가 털갈이할 때 실수로 털을 빼버렸다");

            //반면, 인벤토리의 아이템은 추가될 수도 있고 그 크기가 정해져있지 않기에 List를 활용한다.
            List<Item> inventoryItem = new List<Item>();
            inventoryItem.Add(new Item(allItem[0]));

            //상점의 경우에는 상점의 칸 수가 제한적일 때는, 배열을 사용해도 좋고
            //판매한 것을 다시 구매하는 방식의 가변식을 사용할 경우, List도 좋을 거 같다.
            Item[] shopItem = new Item[10];

            //상점의 경우 매번 같은 것만 팔면 재미가 없기 떄문에, Random함수를 사용한다.
            for(int i = 0; i < shopItem.Length; i++)
            {
                Random rand = new Random();
                int itemIndex = rand.Next(0, allItem.Length);

                shopItem[i] = new Item(allItem[itemIndex]);
                Console.WriteLine($"{i}번째 아이템은 {shopItem[i].itemName}입니다.");
            }
            
            //과연 값이 참조하고 있는가?
            //정답은 new를 쓰면 클래스에서 재할당을 받기에 값형으로 쓰이고
            //new를 활용하지 않으면, 참조의 형태로 주소를 저장받게 된다.
            //이 경우에는 클래스 재할당이 이루어지기에 값이 변하지 않는 경우에는
            //굳이 재할당을 할 필요는 없을 거 같다.
            //결론 : 아이템의 이름이 바뀔 필요가 없는 현 코드에서는 new가 필요가 없다.
            //그러나 참고자료로 냅두고 ver2.Branch 버전에 수정한 자료를 올릴 것이다.

            //shopItem[5].itemName = "바보다"; 
            //프로퍼티 추가한 후에는 itemName의 값 수정이 불가능.

            for (int i = 0; i < shopItem.Length; i++)
            {
                Console.WriteLine($"{i}번째 아이템은 {shopItem[i].itemName}입니다.");
            }

            Console.WriteLine($"과연 참조하는가 아이템 1: {allItem[0].itemName}");
            Console.WriteLine($"과연 참조 당하는가 아이템 2: {allItem[1].itemName}");
        
        }


        //추가적으로 스탯을 구현함에 있어서도 문제가 없을듯하여 
        //바로 작업에 추가했다.
        //이후 Branch에서 수정하겠다.

    }
}

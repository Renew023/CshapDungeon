namespace CshapDungeon
{
    internal class Program
    {
        //스탯 종류
        enum StatType //4주차
        {
            Level,  //레벨
            Name,   //이름
            Job,    //직업
            Atk,    //공격력
            Def,    //방어력
            Hp,     //체력
            Gold    //골드
        }

        //환경 종류
        public enum PlaceType
        {
            Village, //마을 
            Inventory, //인벤토리
            Shop, //상점
            Status //능력치 확인
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

            public void ItemInfo()
            {
                if(isEquip == true)
                {
                    Console.Write("[E] ");
                }
                Console.Write($"{itemName} || {itemStatType}: {stat} || {itemHistory}");
            }
        }

        //플레이어 클래스
        public class Player
        {
            public string name { get; set; } //이름
            public int[] stats  { get; private set; } = new int[4] 
            { 10, 10, 10, 10 }; //HP, ATK, DEF, SPD
            
            private int[] itemStats = new int[4]  //장착 아이템 능력치
            { 0, 0, 0, 0 };

            public List<Item> inventoryItem = new List<Item>(); //인벤토리 아이템 공간 확보

            public void ItemAdd(Item item)
            {
                inventoryItem.Add(item);
            }
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


        
        //static void Equip()
        //{
        //장착 중인 거 표기
        //장착 중인 거면 [E]를 같이 출력, 아니면 [E] 없이 출력
        //아이템 리스트에 없는 것을 선택 시, 잘못된 입력입니다 출력
        //아이템은 중복 장착이 가능하며, 장착한 아이템은 Enum 또는 Struct status에 반영
        //}

        

        static void Main(string[] args)
        {
            Player user = new Player(); //플레이어 정의
            PlaceType place = new PlaceType(); //장소 정의
            place = PlaceType.Village; //시작 위치 : 마을

            Item[] allItem = new Item[2]; //아이템 초기화 및 선언
            allItem[0] = new Item("호랑이의 팬티", (int)StatType.Atk, 8, "호랑이의 털로 만든 팬티로 도깨비가 입고다닌다");
            allItem[1] = new Item("고양이의 수염", (int)StatType.Def, 10, "고양이가 털갈이할 때 실수로 털을 빼버렸다");

            user.ItemAdd(allItem[0]);

            Item[] shopItem = new Item[10]; //상점의 아이템 공간 확보

            //for (int i = 0; i < shopItem.Length; i++)
            //{
            //    Random rand = new Random();
            //    int itemIndex = rand.Next(0, allItem.Length);

            //    shopItem[i] = new Item(allItem[itemIndex]);
            //    Console.WriteLine($"{i}번째 아이템은 {shopItem[i].itemName}입니다.");
            //}

            Intro();

            NameSelect();

            while (true)
            {
                GameManager(place);
            }

            void GameManager(PlaceType place)
            {
                switch(place)
                {
                    case PlaceType.Village:
                        Village();

                        break;

                    case PlaceType.Status:
                        Status();

                        break;
                    case PlaceType.Shop:
                        Shop();

                        break;

                    case PlaceType.Inventory:
                        Inventory();
                        
                        break;
                }
                LineTap(15);
            }

            void LineTap(int line)
            {
                for(int i=0; i<line; i++)
                {
                    Console.Write("\n");
                }
            }

            void Intro() // 이름 선택
            {
                Console.WriteLine("스파르타 던전에 오신 것을 환영합니다.");
                Console.WriteLine("플레이어의 이름을 선택해주십시오.");
                Console.WriteLine("\n");
            }

            void NameSelect()
            {
                while (true)
                {
                    //내용 입력
                    user.name = Console.ReadLine();
                    Console.WriteLine("\n");

                    //내용 확인
                    Console.WriteLine($"플레이어가 입력한 이름은 \"{user.name}\" 입니다.");
                    Console.Write("\n");

                    //선택지
                    Console.WriteLine("1. 저장");
                    Console.WriteLine("2. 취소");
                    Console.Write("\n");

                    Console.WriteLine("원하시는 행동을 입력해주세요.");

                    int check = 0;

                    while (check != 2)
                    {
                        Console.Write(">> ");
                        check = int.Parse(Console.ReadLine());

                        switch (check)
                        {
                            case 1:
                                Console.WriteLine(">> 이름을 선택하셨습니다.");
                                LineTap(15);
                                return;
                                break;
                            case 2:
                                Console.WriteLine(">> 이름을 다시 선택해주세요");
                                Console.WriteLine("\n");
                                break;

                            default:
                                Console.WriteLine(">> 값을 다시 입력해주십시오");
                                continue;
                        }
                    }
                }
            }

            void Inventory()
            {
                //창 설명
                Console.WriteLine("[[인벤토리]]");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.Write("\n");

                //플레이어의 정보 : 장착 아이템
                Console.WriteLine("[장착중인 아이템]");
                for(int i=0; i<user.inventoryItem.Count; i++)
                {
                    if (user.inventoryItem[i].isEquip == true)
                    {
                        user.inventoryItem[i].ItemInfo();
                    }
                }
                LineTap(2);

                //아이템 목록 for, foreach를 통해 아이템 배열이나 리스트 출력.

                //보유 아이템
                Console.WriteLine("[보유 아이템]"); 
                for (int i=0; i<user.inventoryItem.Count; i++)
                {
                    Console.Write($"[{i + 1}] ");
                    user.inventoryItem[i].ItemInfo();
                }
                LineTap(2);

                

                //선택지
                Console.WriteLine("1. [장착하기]");
                Console.WriteLine("0. [나가기]");
                Console.Write("\n");

                //플레이어 입력대기
                Console.WriteLine("원하시는 행동을 선택해주세요.");

                while (true)
                {
                    Console.Write(">> ");
                    int check = int.Parse(Console.ReadLine());

                    switch (check)
                    {
                        case 0:
                            Console.WriteLine(">> [나가기]를 선택하셨습니다.");
                            Console.Write("\n");
                            
                            place = PlaceType.Village;
                            break;

                        case 1:
                            Console.WriteLine(">> [장착하기]를 선택하셨습니다.");
                            Console.Write("\n");
                            //Equip(); 근데 이거는 Item을 리스트에 넣어줘야 되기 때문에 보류;

                            break;

                        default:
                            Console.WriteLine(">> 값을 다시 입력해주십시오");
                            continue;
                    }
                    return;
                }
            }

            void Status()
            {
                //창 설명
                Console.WriteLine("[[상태 보기]]");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.Write("\n");

                //플레이어의 정보(클래스로 바꿀 예정)
                for (int i = 0; i < user.stats.Length; i++)
                {
                    Console.WriteLine($"{Enum.GetName(typeof(StatType), i)} : {user.stats[i]}");
                }
                Console.Write("\n");

                //선택지
                Console.WriteLine("0. 나가기");
                Console.Write("\n");

                //플레이어 입력대기
                Console.WriteLine("원하시는 행동을 선택해주세요.");

                while (true)
                {
                    Console.Write(">> ");
                    int check = int.Parse(Console.ReadLine());

                    switch (check)
                    {
                        case 0:
                            Console.WriteLine(">> 나가기를 선택하셨습니다.");
                            Console.Write("\n");

                            place = PlaceType.Village;
                            break;

                        default:
                            Console.WriteLine(">> 값을 다시 입력해주십시오");
                            Console.Write("\n");
                            continue;
                    }
                    return;
                }
            }

            void Village()
            {
                Console.WriteLine("[[스파르타 마을]]에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할수 있습니다.");
                Console.Write("\n");

                //Enum으로 나중에 변환 가능할 듯. villageList
                Console.WriteLine("1. [상태 보기]");
                Console.WriteLine("2. [인벤토리]");
                Console.WriteLine("3. [상점]");
                Console.Write("\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int check = 0;

                

                while (true)
                {
                    Console.Write(">> ");
                    check = int.Parse(Console.ReadLine());

                    switch (check)
                    {
                        case 1:
                            Console.WriteLine(">> [상태보기]를 선택하셨습니다.");
                            Console.Write("\n");

                            place = PlaceType.Status;
                            return;

                            break;
                        case 2:
                            Console.WriteLine(">> [인벤토리]를 선택하셨습니다.");
                            Console.Write("\n");

                            place = PlaceType.Inventory;
                            return;

                            break;

                        case 3:
                            Console.WriteLine(">> [상점]을 선택하셨습니다.");
                            Console.Write("\n");

                            place = PlaceType.Shop;
                            return;

                            break;

                        default:
                            Console.WriteLine("값을 다시 입력해주십시오");
                            continue;
                    }
                }
            }
            

            void Shop()
            {
                //창 설명
                Console.WriteLine("[[상점]]");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다");
                Console.Write("\n");

                //플레이어의 정보
                Console.WriteLine("보유 금액 : ");
                Console.Write("\n");

                //상점의 정보
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine("아이템");
                Console.Write("\n");

                //선택지
                Console.WriteLine("1. [아이템 구매]");
                Console.WriteLine("0. [나가기]");
                Console.Write("\n");

                //플레이어 입력대기
                Console.WriteLine("원하시는 행동을 선택해주세요.");

                while (true)
                {
                    Console.Write(">> ");
                    int check = int.Parse(Console.ReadLine());

                    switch (check)
                    {
                        case 1:
                            Console.WriteLine("[아이템 구매]를 선택하셨습니다.");
                            Console.Write("\n");
                            //ItemBuy(); 나중에 아이템 리스트 만들고 제작 예정
                            break;
                        case 0:
                            Console.WriteLine("[나가기]를 선택하셨습니다.");
                            Console.Write("\n");

                            place = PlaceType.Village;
                            break;

                        default:
                            Console.WriteLine("값을 다시 입력해주십시오");
                            continue;
                    }
                    return;
                }
            }

            //while(true)
            //{
            //    switch(place)
            //    {
            //        case PlaceType.Village:
            //            Village();

            //            break;

            //        case PlaceType.Status:
            //            user.Status();

            //            break;

            //        case PlaceType.Inventory:
            //            user.Inventory();

            //            break;

            //        case PlaceType.Shop:
            //            Shop();
            //            break;
            //    }

            //}

            //Main의 끝
        }

    //클래스의 끝
    }
}

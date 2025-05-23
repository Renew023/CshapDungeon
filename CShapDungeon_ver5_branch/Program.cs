﻿namespace CShapDungeon_ver5_branch
{
    internal class Program
    {
        public enum PlaceType //VillageSection
        {
            Village, //마을 
            Inventory, //인벤토리
            Shop, //상점
            Status, //능력치 확인
            Dungeon, //던전입장
            Rest //휴식하기
        }

        //장착개선에 쓰일 코드
        public enum ItemType
        {
            Head = 0, //머리
            Body, //몸
            Hand, //손
            Reggings, //바지
            Shoes, //발
            Ring, //반지
            NeckRing //목걸이
        }
        public enum StatType //4주차
        {
            Hp = 0,     //체력
            Atk = 1,    //공격력
            Def = 2,    //방어력
        }

        public enum DungeonStage
        {
            Easy = 1,
            Normal,
            Hard
        }
        public class Item
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

        public class Player
        {
            public string name { get; set; } //이름
            public float[] curStats { get; private set; } = new float[3];
            public float[] stats { get; set; } = new float[3]
            { 10, 10, 10 }; //HP, ATK, DEF
            public Item?[] equipItem = new Item[7];
            private int Level = 1;
            private int Exp = 0;

            public void DungeonClear()
            {
                Exp += 1;
                if (Exp == Level)
                {
                    Exp = 0;
                    Level++;
                    stats[1] += 0.5f;
                    stats[2] += 1.0f;
                }
            }

            public void StatReload(StatType statType, int stat)
            {
                float curStat = stats[(int)statType]; //바꾸기 전 값을 받는다.
                stats[(int)statType] += stat; // 바뀌고 난 후

                float updateStat = stats[(int)statType] - curStat; //바뀌고 난후의 값을 비교한다.
                CurStatReload(statType, updateStat); //업데이트한 값을 curstat에 넣어준다.
            }

            public void CurStatReload(StatType statType, float stat)
            {
                curStats[(int)statType] += stat;
            }


            public int[] itemStats = new int[3]  //장착 아이템 능력치
            { 0, 0, 0 };

            public List<Item> inventoryItem = new List<Item>(); //인벤토리 아이템 공간 확보

            public int haveGold = 1000;

            public void ItemAdd(Item item)
            {
                inventoryItem.Add(item);
            }

            public void IsEquip(ItemType itemType) //해당 부위가 장착이 되었는가 코드
            {
                if (equipItem[(int)itemType] != null) //아이템이 해당부위에 착용하고 있다면,
                {
                    Equip(equipItem[(int)itemType]); //장비를 해제하고
                    equipItem[(int)itemType] = null; //비워라 그 공간을.
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

                    itemStats[(int)item.itemStatType] += itemStat; //해당 능력치를 플레이어에게 부여한다.\
                    StatReload(item.itemStatType, item.stat);

                    equipItem[(int)item.itemType] = item;
                }
                else
                {
                    int itemStat = 0 - item.stat;

                    itemStats[(int)item.itemStatType] += itemStat;
                    StatReload(item.itemStatType, itemStat);
                    item.isEquip = false;
                }
            }
        }

        static void Main(string[] args)
        {
            Player user = new Player(); //플레이어 정의
            PlaceType place = new PlaceType(); //장소 정의
            place = PlaceType.Village; //시작 위치 : 마을

            Item[] allItem = new Item[3]; //아이템 초기화 및 선언
            allItem[0] = new Item("호랑이의 팬티", ItemType.Reggings, StatType.Atk, 8, "호랑이의 털로 만든 팬티로 도깨비가 입고다닌다", 500);
            allItem[1] = new Item("고양이의 수염", ItemType.Head, StatType.Def, 10, "고양이가 털갈이할 때 실수로 털을 빼버렸다", 200);
            allItem[2] = new Item("고양이의 으르렁", ItemType.Head, StatType.Def, 12, "고양이의 으르렁을 따라할 수 있다", 600);
            List<Item> shopItem = new List<Item>();

            for (int i = 0; i < user.stats.Length; i++)
            {
                user.curStats[i] = user.stats[i];
            }

            user.ItemAdd(new Item(allItem[0]));
            user.ItemAdd(new Item(allItem[1]));
            user.ItemAdd(new Item(allItem[2]));

            //실행구문
            ShopReset();

            Intro();
            NameSelect();

            while (true)
            {
                GameManager(place);
            }

            void LineTest()
            {
                Console.WriteLine("콘솔의 호출 횟수를 확인합니다.");
            }//LineTest

            void GameManager(PlaceType place)
            {
                switch (place)
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
                    case PlaceType.Rest:
                        Rest();

                        break;
                    case PlaceType.Dungeon:
                        Dungeon();
                        break;
                }
                LineTap(15);
            } //GameLogic

            void Intro() // 이름 선택
            {
                Console.WriteLine("스파르타 던전에 오신 것을 환영합니다.");
                Console.WriteLine("플레이어의 이름을 선택해주십시오.");
                Console.WriteLine("\n");
            } //Intro

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
            } //NameSelect

            void Village()
            {
                Console.WriteLine("[[스파르타 마을]]에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할수 있습니다.");
                Console.Write("\n");

                //Enum으로 나중에 변환 가능할 듯. villageList
                Console.WriteLine("1. [상태 보기]");
                Console.WriteLine("2. [인벤토리]");
                Console.WriteLine("3. [상점]");
                Console.WriteLine("4. [휴식처]");
                Console.WriteLine("5. [던전 입장]");
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

                        case 2:
                            Console.WriteLine(">> [인벤토리]를 선택하셨습니다.");
                            Console.Write("\n");

                            place = PlaceType.Inventory;
                            return;

                        case 3:
                            Console.WriteLine(">> [상점]을 선택하셨습니다.");
                            Console.Write("\n");

                            place = PlaceType.Shop;
                            return;

                        case 4:
                            Console.WriteLine(">> [휴식처]을 선택하셨습니다.");
                            Console.Write("\n");

                            place = PlaceType.Rest;
                            return;
                        case 5:
                            Console.WriteLine(">> [던전입장]을 선택하셨습니다.");
                            Console.Write("\n");

                            place = PlaceType.Dungeon;
                            return;

                        default:
                            Console.WriteLine("값을 다시 입력해주십시오");
                            continue;
                    }
                }
            } //Village

            void Status()
            {
                //창 설명
                Console.WriteLine("[[상태 보기]]");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.Write("\n");

                //플레이어의 정보(클래스로 바꿀 예정)
                //레벨
                //직업
                //체, 공, 방
                for (int i = 0; i < user.stats.Length; i++)
                {
                    Console.WriteLine($"[{Enum.GetName(typeof(StatType), i)}] : {user.curStats[i]} / {user.stats[i]} (+{user.itemStats[i]})");
                }
                Console.WriteLine($"[현재 골드] {user.haveGold}");
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
            } //Status

            void Inventory()
            {
                //창 설명
                Console.WriteLine("[[인벤토리]]");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.Write("\n");

                //플레이어의 정보 : 장착 아이템
                Console.WriteLine("[장착중인 아이템]");
                for (int i = 0; i < user.inventoryItem.Count; i++)
                {
                    if (user.inventoryItem[i].isEquip == true)
                    {
                        user.inventoryItem[i].ItemInfo();
                    }
                }
                LineTap(2);


                //보유 아이템
                Console.WriteLine("[보유 아이템]");
                for (int i = 0; i < user.inventoryItem.Count; i++)
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
                            return;
                            break;

                        case 1:
                            Console.WriteLine(">> [장착하기]를 선택하셨습니다.");
                            Console.Write("\n");
                            EquipInventory();

                            //Equip(); 근데 이거는 Item을 리스트에 넣어줘야 되기 때문에 보류;

                            break;

                        default:
                            Console.WriteLine(">> 값을 다시 입력해주십시오");
                            continue;
                    }
                    return;
                }
            } //Inventory

            void EquipInventory()
            {
                while (true)
                {
                    Console.WriteLine("[[인벤토리 착용]]");
                    Console.WriteLine("착용할 아이템을 골라주세요");
                    Console.Write("\n");

                    //플레이어의 정보 : 장착 아이템
                    Console.WriteLine("[장착중인 아이템]");
                    for (int i = 0; i < user.inventoryItem.Count; i++)
                    {
                        if (user.inventoryItem[i].isEquip == true)
                        {
                            user.inventoryItem[i].ItemInfo();
                        }
                    }
                    LineTap(2);


                    //보유 아이템
                    Console.WriteLine("[보유 아이템]");
                    for (int i = 0; i < user.inventoryItem.Count; i++)
                    {
                        Console.Write($"[{i + 1}] ");
                        user.inventoryItem[i].ItemInfo();
                    }
                    LineTap(2);



                    //선택지
                    Console.WriteLine("장착할 아이템의 번호를 눌러주세요");
                    Console.WriteLine("0. [나가기]");
                    Console.Write("\n");

                    //플레이어 입력대기
                    Console.WriteLine("원하시는 행동을 선택해주세요.");

                    while (true)
                    {
                        Console.Write(">> ");
                        int check = int.Parse(Console.ReadLine());

                        if (check > 0 && check < 10)
                        {
                            user.Equip(user.inventoryItem[check - 1]);
                            break;
                        }
                        else if (check == 0)
                        {
                            Console.WriteLine(">> [나가기]를 선택하셨습니다.");
                            Console.Write("\n");
                            return;
                        }
                        else
                        {
                            Console.WriteLine(">> 값을 다시 입력해주십시오");
                            continue;
                        }

                    }
                }
            }

            void Rest()
            {
                Console.WriteLine("[[휴식처]]");
                Console.WriteLine("500G를 지불하는 것으로 회복을 할 수 있습니다.");
                Console.Write("\n");
                Console.WriteLine($"[[현재 보유금 : {user.haveGold}G]]");
                Console.Write("\n");

                //선택지
                Console.WriteLine("1. [휴식하기]");
                Console.WriteLine("0. [나가기]");
                Console.Write("\n");

                //플레이어 입력대기
                Console.WriteLine("원하시는 행동을 선택해주세요.");

                // 값이 잘못될 경우 반복
                while (true)
                {
                    Console.Write(">> ");
                    int check = int.Parse(Console.ReadLine());

                    switch (check)
                    {
                        case 1:
                            Console.WriteLine("[휴식하기]를 선택하셨습니다.");
                            Console.Write("\n");
                            if (true)
                            {
                                user.curStats[0] = user.stats[0];
                                user.haveGold -= 500;
                                Console.WriteLine("휴식하여 체력을 회복하셨습니다.");
                                Console.WriteLine($"[남은 돈] {user.haveGold}");
                                Console.Write("\n");

                                Console.WriteLine("추가적인 회복이 필요하십니까?");
                                Console.Write("\n");
                                //선택지
                                Console.WriteLine("1. [휴식하기]");
                                Console.WriteLine("0. [나가기]");
                                Console.Write("\n");

                                //플레이어 입력대기
                                Console.WriteLine("원하시는 행동을 선택해주세요.");
                            }
                            else
                            {
                                Console.WriteLine("소지금이 부족하여 회복에 실패하셨습니다.");
                            }
                            continue;

                            //ItemBuy(); 나중에 아이템 리스트 만들고 제작 예정
                            break;
                        case 0:
                            Console.WriteLine("[나가기]를 선택하셨습니다.");
                            Console.Write("\n");
                            place = PlaceType.Village;
                            return;

                            break;

                        default:
                            Console.WriteLine("값을 다시 입력해주십시오");
                            continue;
                    }
                }
            }

            void ShopReset()
            {
                Random rand = new Random();
                for (int i = 0; i < 9; i++)
                {
                    int randomItem = rand.Next(0, allItem.Length);
                    shopItem.Add(new Item(allItem[randomItem]));
                }
            }

            void Shop()
            {
                //창 설명
                Console.WriteLine("[[상점]]");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다");
                Console.Write("\n");

                //플레이어의 정보
                Console.WriteLine($"보유 금액 : {user.haveGold}G");
                Console.Write("\n");

                //상점의 정보
                Console.WriteLine("[아이템 목록]");
                ShopOpen();
                Console.Write("\n");

                //선택지
                Console.WriteLine("1. [아이템 구매]");
                Console.WriteLine("2. [아이템 판매]");
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
                            ShopBuy();
                            //ItemBuy(); 나중에 아이템 리스트 만들고 제작 예정
                            break;
                        case 2:
                            Console.WriteLine("[아이템 판매]를 선택하셨습니다.");
                            Console.Write("\n");
                            ShopSell();
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

            void ShopOpen()
            {
                for (int i = 0; i < shopItem.Count; i++)
                {
                    Console.Write($"{i + 1}. ");
                    shopItem[i].ItemInfo();
                }
            }

            void ShopBuy()
            {
                while (true)
                {
                    //창 설명
                    Console.WriteLine("[[상점 구매하기]]");
                    Console.WriteLine("상점에서 구매할 아이템을 선택해주세요");
                    Console.Write("\n");

                    //플레이어의 정보
                    Console.WriteLine($"보유 금액 : {user.haveGold}G");
                    Console.Write("\n");

                    //상점의 정보
                    Console.WriteLine("[아이템 목록]");
                    ShopOpen();
                    Console.Write("\n");

                    //선택지
                    Console.WriteLine("구매할 아이템의 번호를 눌러주세요");
                    Console.WriteLine("0. [나가기]");
                    Console.Write("\n");

                    //플레이어 입력대기
                    Console.WriteLine("원하시는 행동을 선택해주세요.");

                    while (true)
                    {
                        Console.Write(">> ");
                        int check = int.Parse(Console.ReadLine());

                        if (check == 0)
                        {
                            Console.WriteLine("[나가기]를 선택하셨습니다.");
                            Console.Write("\n");
                            return;
                        }
                        else if (check > 0 && check < 10)
                        {
                            int indexcheck = check - 1;
                            Console.WriteLine("[아이템 구매]를 선택하셨습니다.");
                            if (user.haveGold >= shopItem[indexcheck].price)
                            {
                                user.inventoryItem.Add(shopItem[indexcheck]);
                                user.haveGold -= shopItem[indexcheck].price;
                                Console.WriteLine($"[{shopItem[indexcheck].itemName}]의 구매가 성공적으로 완료되었습니다.");
                                shopItem.RemoveAt(indexcheck);
                            }
                            else
                            {
                                Console.WriteLine("금액이 부족하여 구매를 실패하셨습니다.");
                            }


                            Console.Write("\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("값을 다시 입력해주십시오");
                            continue;
                        }

                    } // while 끝
                }// while 끝2
            }

            void ShopSell()
            {
                while (true)
                {
                    //창 설명
                    Console.WriteLine("[[아이템 판매]]");
                    Console.WriteLine("아이템을 선택하여 판매하면 정가의 85%를 드립니다.");
                    Console.Write("\n");

                    //보유 금액
                    Console.WriteLine($"보유 금액 : {user.haveGold}G");
                    Console.Write("\n");

                    //보유 아이템
                    Console.WriteLine("[보유 아이템]");
                    for (int i = 0; i < user.inventoryItem.Count; i++)
                    {
                        Console.Write($"[{i + 1}] ");
                        user.inventoryItem[i].ItemInfo();
                    }
                    LineTap(2);

                    //선택지
                    Console.WriteLine("판매할 아이템의 번호를 눌러주세요");
                    Console.WriteLine("0. [나가기]");
                    Console.Write("\n");

                    //플레이어 입력대기
                    Console.WriteLine("원하시는 행동을 선택해주세요.");

                    while (true)
                    {
                        Console.Write(">> ");
                        int check = int.Parse(Console.ReadLine());

                        if (check > 0 && check < 10)
                        {

                            int indexCheck = check - 1;

                            if (user.inventoryItem[indexCheck].isEquip == true)
                            {
                                user.Equip(user.inventoryItem[indexCheck]);
                                Console.WriteLine("장비 착용이 해제되었습니다.");
                            }
                            user.haveGold += (int)(user.inventoryItem[indexCheck].price * 0.85f);

                            Console.WriteLine($"[{user.inventoryItem[indexCheck].itemName}]의 판매가 성공적으로 완료되었습니다.");
                            user.inventoryItem.RemoveAt(indexCheck);

                            break;
                        }
                        else if (check == 0)
                        {
                            Console.WriteLine(">> [나가기]를 선택하셨습니다.");
                            Console.Write("\n");
                            return;
                        }
                        else
                        {
                            Console.WriteLine(">> 값을 다시 입력해주십시오");
                            continue;
                        }
                    }
                }
            }

            void DungeonClear(int dungeon)
            {
                float DungeonValue = 0;
                int clearGold = 0;

                switch (dungeon)
                {
                    case (int)DungeonStage.Easy:
                        DungeonValue = 5;
                        clearGold = 1000;
                        break;
                    case (int)DungeonStage.Normal:
                        DungeonValue = 11;
                        clearGold = 1700;
                        break;

                    case (int)DungeonStage.Hard:
                        DungeonValue = 17;
                        clearGold = 2500;
                        break;
                }

                float def = user.curStats[(int)StatType.Def];
                float atk = user.curStats[(int)StatType.Atk];
                bool isClear = false;
                if (def >= DungeonValue)
                {
                    isClear = true;
                }
                else
                {
                    Random rand = new Random();
                    float fail = rand.Next(0, 100);

                    if (fail < 40)
                    {
                        float damage = 50;
                        user.curStats[(int)StatType.Hp] -= damage;

                        for (int i = 0; i < user.curStats.Length; i++)
                        {
                            Console.Write($"{Enum.GetName(typeof(StatType), i)} : {user.curStats[i]}");
                            if (i == 0) Console.Write($" (-{damage})");
                            Console.Write("\n");

                        }
                        Console.WriteLine("던전 공략에 실패하셨습니다.");
                    }
                    else
                    {
                        isClear = true;
                    }
                }
                if (isClear == true)
                {
                    Console.WriteLine("[던전 클리어]");
                    Random rand = new Random();
                    float damage = rand.Next(20, 35) + 1 - (def - 5);
                    user.curStats[(int)StatType.Hp] -= damage;

                    int percent = rand.Next(10, 20); // 1, 2
                    user.haveGold = clearGold * (int)(atk * percent * 0.1f);

                    Console.WriteLine($"플레이어의 능력치");
                    for (int i = 0; i < user.curStats.Length; i++)
                    {
                        Console.Write($"{Enum.GetName(typeof(StatType), i)} : {user.curStats[i]}");
                        if(i == 0) Console.Write($" (-{damage})");
                        Console.Write("\n");

                    }
                    Console.Write("\n");

                    Console.WriteLine($"보상 : {clearGold}");
                }
                Console.WriteLine("던전을 더 들어가시겠습니까?");
                Console.WriteLine("1. [재입장]");
                Console.WriteLine("0. [나가기]");
                Console.Write("\n");

                //플레이어 입력대기
                while (true)
                {
                    Console.WriteLine("원하시는 행동을 선택해주세요.");

                    int num = int.Parse(Console.ReadLine());

                    switch (num)
                    {
                        case 1:
                            Console.WriteLine("[재입장]을 선택하셨습니다.");
                            return;
                        case 0:
                            Console.WriteLine("[나가기]를 선택하셨습니다.");
                            place = PlaceType.Village;
                            return;
                        default:
                            Console.WriteLine("재선택을 해주십시오.");
                            continue;
                    }
                }
            }

            void Dungeon()
            {
                //창 설명
                Console.WriteLine("[[던전]]");
                Console.WriteLine("들어갈 던전의 난이도를 선택해주세요");
                Console.Write("\n");

                //플레이어의 정보
                Console.WriteLine($"플레이어의 능력치");
                for(int i=0; i<user.curStats.Length; i++)
                {
                    Console.WriteLine($"{Enum.GetName(typeof(StatType), i)} : {user.curStats[i]}");
                }
                Console.Write("\n");

                //상점의 정보
                Console.WriteLine("[던전별 난이도]");
                Console.WriteLine($"쉬운 던전 | 권장 난이도 5");
                Console.WriteLine($"일반 던전 | 권장 난이도 11");
                Console.WriteLine($"어려운 던전 | 권장 난이도 17");
                Console.Write("\n");

                //선택지
                Console.WriteLine("1. [쉬운 던전]");
                Console.WriteLine("2. [일반 던전]");
                Console.WriteLine("3. [어려운 던전]");
                Console.WriteLine("0. [나가기]");
                Console.Write("\n");

                //플레이어 입력대기
                while (true)
                {
                    Console.WriteLine("원하시는 행동을 선택해주세요.");

                    int num = int.Parse(Console.ReadLine());

                    switch ((DungeonStage)num)
                    {
                        case DungeonStage.Easy:
                        case DungeonStage.Normal:
                        case DungeonStage.Hard:
                            DungeonClear(num);
                            return;
                        case 0:
                            Console.WriteLine("[나가기]를 선택하셨습니다.");
                            place = PlaceType.Village;
                            return;
                        default:
                            Console.WriteLine("재선택을 해주십시오.");
                            continue;
                    }
                }
            }

            //작법 도움 주는 코드
            void LineTap(int line)
            {
                for (int i = 0; i < line; i++)
                {
                    Console.Write("\n");
                }
            } // 끝
        }
    }
}

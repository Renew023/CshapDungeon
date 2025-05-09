﻿using System.Security.Cryptography;

namespace CshapDungeon_ver3_branch
{
    internal class Program
    {
        public enum StatType //4주차
        {
            Hp = 0,     //체력
            Atk = 1,    //공격력
            Def = 2,    //방어력

            Level = 0,  //레벨
            Name,   //이름
            Job,  //직업
            Gold    //골드
        }

        public enum PlaceType //VillageSection
        {
            Village, //마을 
            Inventory, //인벤토리
            Shop, //상점
            Status, //능력치 확인
            Dungeon, //던전입장
            Rest //휴식하기
        }

        public class Item
        {
            public string itemName { get; private set; }
            public StatType itemStatType { get; private set; }
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
            }

            public Item(string newItemName, StatType newItemStatType, int newStat, string newItemHistory, int newprice)
            {
                itemName = newItemName;
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
                Console.WriteLine($"{itemName} || {itemStatType}: {stat} || {itemHistory} || {price}G");
            }
        }

        public class Player
        {
            public string name { get; set; } //이름
            public int[] stats { get; private set; } = new int[3]
            { 10, 10, 10 }; //HP, ATK, DEF

            public int[] itemStats = new int[3]  //장착 아이템 능력치
            { 0, 0, 0 };

            public List<Item> inventoryItem = new List<Item>(); //인벤토리 아이템 공간 확보

            public int haveGold = 1000;

            public void ItemAdd(Item item)
            {
                inventoryItem.Add(item);
            }

            public void Equip(Item item) //장비 착용
            {
                if (item.isEquip == false) //장비를 착용하지 않았다면, 
                {
                    itemStats[(int)item.itemStatType] += item.stat; //해당 능력치를 플레이어에게 부여한다.\
                    stats[(int)item.itemStatType] += item.stat;
                    item.isEquip = true;
                }
                else
                {
                    itemStats[(int)item.itemStatType] -= item.stat;
                    stats[(int)item.itemStatType] -= item.stat;
                    item.isEquip = false;
                }
            }
        }
        static void Main(string[] args)
        {
            //변수
            Player user = new Player(); //플레이어 정의
            PlaceType place = new PlaceType(); //장소 정의
            place = PlaceType.Village; //시작 위치 : 마을

            Item[] allItem = new Item[2]; //아이템 초기화 및 선언
            allItem[0] = new Item("호랑이의 팬티", StatType.Atk, 8, "호랑이의 털로 만든 팬티로 도깨비가 입고다닌다", 500);
            allItem[1] = new Item("고양이의 수염", StatType.Def, 10, "고양이가 털갈이할 때 실수로 털을 빼버렸다", 200);
            List<Item> shopItem = new List<Item>();

            //테스트용 아이템 인벤토리 구문
            user.ItemAdd(new Item(allItem[0]));
            ShopReset();

            //실행 구문
            Intro();
            NameSelect();

            //현재 위치
            while (true)
            {
                GameManager(place);
            }

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
                }
                LineTap(15);
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

            void Status()
            {
                //창 설명
                Console.WriteLine("[[상태 보기]]");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.Write("\n");

                //플레이어의 정보(클래스로 바꿀 예정)
                for (int i = 0; i < user.stats.Length; i++)
                {
                    Console.WriteLine($"{Enum.GetName(typeof(StatType), i)} : {user.stats[i]} (+{user.itemStats[i]})");
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
            }

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

            void ShopReset()
            {
                Random rand = new Random();
                for (int i = 0; i < 9; i++)
                {
                    int randomItem = rand.Next(0, allItem.Length);
                    shopItem.Add(new Item(allItem[randomItem]));
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

            void ShopOpen()
            {
                for (int i = 0; i < shopItem.Count; i++)
                {
                    Console.Write($"{i + 1}. ");
                    shopItem[i].ItemInfo();
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

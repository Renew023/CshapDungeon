namespace CshapDungeon_ver6
{

    internal class Program
    {
        // 필요클래스 : 전부
        //1. Console.WriteLine이 활용된 라인들을 가독성을 위해 void 메서드로 데이터를 나누기
        //2. 중복된 내용을 void로 감싸고 필요한 경우 제너릭 또는 오버라이딩을 활용하여 데이터 값의 운용도 높이
        //3. 선택지 구문은 Enum 값을 활용하여 파트 나누기
        //4, 문법 뒤에 \n와 같이 가독성이 높아지는 코드를 넣을 수 있는 함수 만들기
        //5. For문을 메서드를 통해 활용하기
        //6. while문에서 3.에서 만든 Enum값을 활용하여 매칭 시스템 만들고
        //   0은 고정값이니 exit가 가능하도록 만든다.
        //7. 현재 나가기를 할 시에 village의 값을 매번 바꾸는데 그렇지 않고
        //   백업할 PlaceType을 만들어, 나가기를 누를 시 이전에 공간으로 바꿈.
        // 뜯어고칠 순서는 순차적으로 이름은 가독성을 높이기 위해 쓰지 않을 Enum형으로 하나 명시해주고
        // 공통 설명을 void로 진행

        static void Main(string[] args)
        {
            var code = new CodeSystem();
            var gameLogic = new GameLogic();
            var user = new Player();

            var itemManager = new ItemManager();

            user.inventory.ItemAdd(new Item(itemManager.allItem[0]));
            user.inventory.ItemAdd(new Item(itemManager.allItem[1]));
            user.inventory.ItemAdd(new Item(itemManager.allItem[2]));

            PlaceType place = new PlaceType();

            while (true)
            {
                gameLogic.StartGame();
            }

            Intro();
            NameSelect();

            while (true)
            {
                GameManager(place);
            }

            void GameManager(PlaceType place)
            {
                switch (place)
                {
                    case PlaceType.Village:

                        break;

                    case PlaceType.Status:

                        break;
                    case PlaceType.Shop:

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
                code.LineTap(15);
            }

            void Intro() // 이름 선택
            {
                Console.WriteLine("스파르타 던전에 오신 것을 환영합니다.");
                Console.WriteLine("플레이어의 이름을 선택해주십시오.");
                Console.WriteLine("\n");
            }

            void NameSelect()
            {
                void Aim()
                {

                }
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
                                code.LineTap(15);
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
                for (int i = 0; i < user.inventory.Item.Count; i++)
                {
                    if (user.inventory.Item[i].isEquip == true)
                    {
                        user.inventory.Item[i].ItemInfo();
                    }
                }
                code.LineTap(2);


                //보유 아이템
                Console.WriteLine("[보유 아이템]");
                for (int i = 0; i < user.inventory.Item.Count; i++)
                {
                    Console.Write($"[{i + 1}] ");
                    user.inventory.Item[i].ItemInfo();
                }
                code.LineTap(2);



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
                    for (int i = 0; i < user.inventory.Item.Count; i++)
                    {
                        if (user.inventory.Item[i].isEquip == true)
                        {
                            user.inventory.Item[i].ItemInfo();
                        }
                    }
                    code.LineTap(2);


                    //보유 아이템
                    Console.WriteLine("[보유 아이템]");
                    for (int i = 0; i < user.inventory.Item.Count; i++)
                    {
                        Console.Write($"[{i + 1}] ");
                        user.inventory.Item[i].ItemInfo();
                    }
                    code.LineTap(2);



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
                            user.inventory.Equip(user.inventory.Item[check - 1]);
                            user.ReloadStat();
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
                                user.curHp = user.maxHp;
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
                    for (int i = 0; i < user.inventory.Item.Count; i++)
                    {
                        Console.Write($"[{i + 1}] ");
                        user.inventory.Item[i].ItemInfo();
                    }
                    code.LineTap(2);

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

                            if (user.inventory.Item[indexCheck].isEquip == true)
                            {
                                user.inventory.Equip(user.inventory.Item[indexCheck]);
                                Console.WriteLine("장비 착용이 해제되었습니다.");
                            }
                            user.haveGold += (int)(user.inventory.Item[indexCheck].price * 0.85f);

                            Console.WriteLine($"[{user.inventory.Item[indexCheck].itemName}]의 판매가 성공적으로 완료되었습니다.");
                            user.inventory.Item.RemoveAt(indexCheck);

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

                float def = user.curDef;
                float atk = user.curAtk;
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
                        user.curHp -= damage;

                        user.ShowStatus();
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
                    user.curHp -= damage;

                    int percent = rand.Next(10, 20); // 1, 2
                    user.haveGold = clearGold * (int)(atk * percent * 0.1f);

                    Console.WriteLine($"플레이어의 능력치");
                    user.ShowStatus();
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
                user.ShowStatus();
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

            
        }
    }
}

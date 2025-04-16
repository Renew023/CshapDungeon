using static CShapDungeon_ver3.Program;

namespace CShapDungeon_ver3
{
    internal class Program
    {
        //ver 1 과 ver 2에서 구현한 내용
        //Player class
        //변수 : 이름, 능력치, 

        //인벤토리로 변경 가능한 데이터
        //변수 : 장착한 아이템 능력치, 인벤토리 아이템
        //함수 : 아이템 장착, 아이템 추가
        //위 내용을 Inventory 클래스로 선언하여 Delegate를 활용해서 옮겨보자.

        //Item Class
        //변수 : 아이템 이름, 아이템 스텟 종류, 아이템 스텟 증가치, 아이템 설명, 아이템을 장착했는지?
        //함수 : 아이템 값형으로 재생성, 아이템 정의

        //Enum
        //스탯(능력치) 종류 : 레벨, 이름, 직업, 공격력, 방어력, 체력, 골드
        //환경(장소) 종류 : 마을, 인벤토리, 상점, 능력치 확인

        //Main 
        //변수 : 플레이어, 장소, 아이템의 총 종류

        //Main 함수
        //GameManager : place에 따른 불러오는 값 변화
        //LineTap : 줄 내리기 간편 함수

        //Intro() : 시작 설명
        //NameSelect() : 이름 입력값 받기

        //모든 장소는 행동에 따라 return 값으로 place를 받음.
        //Village : 마을과 마을 내에서 가능한 행동 
        //Inventory : 플레이어의 인벤토리창 확인
        //Shop : 상점 내 시스템
        //Status : 플레이어가 능력치창을 볼 수 있음.



        //구현해야하는 필수 기능 : 
        //게임시작 화면 : O
        //상태보기 : O
        //인벤토리 : O
        //장착관리 : X
        //상점 : X
        //아이템 구매 : X

        //구현해야하는 도전 기능 :
        //아이템 정보를 클래스/구조체 활용 : O 
        //아이템 정보 배열로 관리하기 : O
        //아이템 추가 - 나만의 새로운 아이템 : O
        //휴식기능 추가하기 : X
            //500G를 주면 체력을 회복
        //아이템 판매하기 기능 추가 : X
        //장착 개선
            //타입별로 아이템 하나만 착용 가능 : X
            //Player Class에 Bool 추가하면 쉬울듯
        //레벨업 기능 추가 : X
            //던전 클리어 시 레벨업
            //레벨업 시 기본 공격력 0.5, 방어력 1 증가
        //던전입장 기능 추가 : X
            //난이도 추가 : X
            //방어력으로 던전 판별 : X
            //던전 클리어 : X
            //공격력으로 클리어 골드 : X
        //게임 저장하기 기능 : X

        //배운 것 중 주요사용 기능 :
            //1주차 :
                //코드 컨벤션 : O
                //포멧팅 : O
            //2주차 :
                //배열을 이용한 맵 구현 : X
                //컬렉션(배열)의 종류와 구조 : List 활용
                    //HashSet으로 상점 구현해보면 재밌을 듯.
                //오버로딩 : O / Item 정의 할때
            //3주차        
                //생성자 : O / 소멸자 : X
                    //소멸자를 쓸 일이 거의 없다
                    //던전 만들면서 쓸 수도?
                //프로퍼티 : O / 접근 제한 설정을 했다.
                //다형성 : X
                    //가상 메소드, 추상 메소드
                    //virtual, override | abstract
                //제너릭 : X
                    //동일한 조건을 가지는 다른 타입의 변수를 관리하는 거 같은데
                    //player와 item의 조건은 많이 다르다.
                //out, ref : X
                    //void 함수를 쓰기전에는 ref 값을 활용하려 해봤으나,
                    //Enum 값이 제대로 작동하지 않아 그만두었다.
                    //반드시 바뀌어야한다는 점은 좋게 작용할 수도 있지만,
                    //검증 단계라면 모를까 꼭 필요한 코드는 아니라는 느낌.
            //4주차
                //인터페이스 : X
                    //제너릭과 마찬가지로 똑같이 쓸 함수가 없음.
                //Enum : O
                //예외 처리  : X
                    //쓸 예정 : 값을 받을 때, 숫자가 아닐 경우 버그가 나지 않고 다시 입력하도록.
                //값형과 참조형 : new 키워드를 활용하여 해결하는 방법을 써봄
                //박싱/ 언박싱 : X
                    //new 키워드를 쓰지 않았다면 object를 써볼만도 했는데..
                //델리게이트 : X
                    //메서드(함수) 내에 값을 전달하는 매개체
                    //메서드 내에 데이터를 저장하고 필요시 호출하는 방식으로 사용.
                    //선언된 클래스를 활용해야하기에 Main에서만 활용 가능.
                    //Main - void에서 플레이어의 능력치를 기반으로
                    //아이템을 가져온다는 코드를 써볼 수 있을 것으로 보임.
                //Func, Action : X
                    //Main 내에서 선언하여 만들 수 있는 델리게이트로
                    //메서드를 저장한다.
                    //Func는 맨 뒤에 값을 반환하고
                    //Action은 반환 값 없이 활용한다. 
                //람다식, LinQ : X
                    //람다 아직도 모르겠다. 질문 내용 : 1 
                    // LINQ 굳이 안 써도 될거 같다. 
                        //for문과 if문으로 해소 가능하다.
                //Nullable : X
                    //데이터 값이 빈것을 확인할 때 사용하는 구문인데, List를 사용하기 때문에 굳이 없어도 된다.
                //문자열 빌더 : X
                    //콘솔이 더러워지는 것을 방지하기 위해 이번에 사용해볼 예정이다.


            //우선순위 :
                //1.기본 필수과제 
                //구현에 필요한 Player 클래스와 변수는 가져온다. 
                //또한 Player 클래스가 Item 클래스를 활용하고 있기에 가져온다.
                    //장착관리 
                        //inventory에서 1을 선택 시,
                    //상점 
                    //아이템 구매 
                //2.문자열 빌더로 콘솔창 깨끗하게 //로 할려했었으나, 튜터님 강의에서 쓰인 내용으로 수정할 예정
                //3.배열을 활용하여 콘솔창 꾸미기 //이 또한 수정 시에 내용이 많이 바뀔 거 같아 나중으로 미룸.

            //구현 단계 :
                //장착관리 : O
                //상점 : O
                //아이템 구매 : O

        //스탯 종류
        public enum StatType //4주차
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
        public enum PlaceType //VillageSection
        {
            Village, //마을 
            Inventory, //인벤토리
            Shop, //상점
            Status, //능력치 확인
            Dungeon, //던전입장
            Rest //휴식하기
        }


        //public class Shop
        //{            
        //    public Item[] shopItem = new Item[10];

        //    public void ShopReset(Item[] item)
        //    {
        //        Random rand = new Random();
        //        for(int i = 0; i < shopItem.Length; i++)
        //        {
        //            int randomItem = rand.Next(i, item.Length);
        //            shopItem[i] = item[randomItem];
        //        }
        //    }

        //    public void ShopOpen()
        //    {
        //        for (int i = 0; i < shopItem.Length; i++)
        //        {
        //            Console.Write($"{i+1}. ");
        //            shopItem[i].ItemInfo();
        //        }
        //    }

        //}

        public class Item
        {
            public string itemName { get; private set; }
            public int itemStatType { get; private set; }
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

            public Item(string newItemName, int newItemStatType, int newStat, string newItemHistory, int newprice)
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
                Console.WriteLine($"{itemName} || {(Enum)StatType.Atk}: {stat} || {itemHistory} || {price}G");
            }
        }


        public class Player
        {
            public string name { get; set; } //이름
            public int[] stats { get; private set; } = new int[4]
            { 10, 10, 10, 10 }; //HP, ATK, DEF, SPD

            private int[] itemStats = new int[4]  //장착 아이템 능력치
            { 0, 0, 0, 0 };

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



        static void Main(string[] args)
        {
            //변수
            Player user = new Player(); //플레이어 정의

            Item[] allItem = new Item[2]; //아이템 초기화 및 선언
            allItem[0] = new Item("호랑이의 팬티", (int)StatType.Atk, 8, "호랑이의 털로 만든 팬티로 도깨비가 입고다닌다", 500);
            allItem[1] = new Item("고양이의 수염", (int)StatType.Def, 10, "고양이가 털갈이할 때 실수로 털을 빼버렸다", 200);
            List<Item> shopItem = new List<Item>();

            //실행 구문
            user.ItemAdd(allItem[0]);
            ShopReset();

            while (true)
            {
                Shop();
            }
            


            //함수
            //상점 아이템은 상점 클래스를 새로 만들 예정
            void LineTap(int line)
            {
                for (int i = 0; i < line; i++)
                {
                    Console.Write("\n");
                }
            } // 끝

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
            }// 끝 Inventory

            void EquipInventory()
            {
                while(true)
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
                            user.Equip(user.inventoryItem[check-1]);
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

                            break;

                        default:
                            Console.WriteLine("값을 다시 입력해주십시오");
                            continue;
                    }
                    return;
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

                        if(check == 0)
                        {
                            Console.WriteLine("[나가기]를 선택하셨습니다.");
                            Console.Write("\n");
                            return;
                        }
                        else if (check > 0 && check < 10)
                        {
                            int indexcheck = check - 1;
                            Console.WriteLine("[아이템 구매]를 선택하셨습니다.");
                            if(user.haveGold >= shopItem[indexcheck].price)
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
            }//ShopBuy 끝

            void ShopReset()
            {
                Random rand = new Random();
                for (int i = 0; i < 9; i++)
                {
                    int randomItem = rand.Next(0, allItem.Length);
                    shopItem.Add(allItem[randomItem]);
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



    }
}
}

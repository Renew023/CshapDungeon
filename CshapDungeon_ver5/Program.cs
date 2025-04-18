﻿using static System.Net.Mime.MediaTypeNames;

namespace CshapDungeon_ver5
{
    internal class Program
    {
        //구현해야하는 필수 기능 : 
        //게임시작 화면 : O
        //상태보기 : O
        //인벤토리 : O
        //장착관리 : O
        //상점 : O
        //아이템 구매 : O
        //구현해야하는 도전 기능 :
        //아이템 정보를 클래스/구조체 활용 : O 
        //아이템 정보 배열로 관리하기 : O
        //아이템 추가 - 나만의 새로운 아이템 : O
        //휴식기능 추가하기 : O
        //500G를 주면 체력을 회복
        //아이템 판매하기 기능 추가 : O
        //장착 개선 : O
        //타입별로 아이템 하나만 착용 가능 
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
        //컬렉션(배열)의 종류와 구조 : O List 활용
        //HashSet으로 상점 구현해보면 재밌을 듯.
        //오버로딩 : O / Item 정의 할때
        //3주차        
        //생성자 : O / 소멸자 : X
        //소멸자를 쓸 일이 거의 없다
        //던전 만들면 쓸 수도?
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
        //new 키워드를 쓰지 않았다면 object를 써볼만도 했는데.. new 키워드가 훨씬 편리함
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
        //그러나 튜터님이 알려주신 방식으로 정리할 예정이다. Console.Clear();

        //구현 단계
        //
        //1. 레벨업 기능 추가 : O
            //레벨에 대한 정보는 플레이어에게
            //던전 클리어 시 레벨업 : O
            //레벨업 시 기본 공격력 0.5, 방어력 1 증가 : O
        //2. 던전입장 기능 추가 : O PlaceType.Dungeon
            //난이도 추가 : O
            //방어력으로 던전 판별 : O
            //던전 클리어 : O
            //공격력으로 클리어 골드 : O
        //3. 채팅창 클리어 Console.Clear

        //6- 챕터에서 직업 추가
        
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

            Level = 0,  //레벨
            Name,   //이름
            Job,  //직업
            Gold    //골드
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
                if(Exp == Level)
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

        public enum DungeonStage
        {
            Easy = 0,
            Normal,
            Hard
        }
        
        static void Main(string[] args)
        {
            Player user = new Player();
            //2. 던전입장 기능 추가 : O //PlaceType.Dungeon
            //난이도 추가 : X
            //방어력으로 던전 판별 : X
            //던전 클리어 : X
            //공격력으로 클리어 골드 : X
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
                if (def >= 5)
                {
                    isClear = true;
                }
                else
                {
                    Random rand = new Random();
                    float fail = rand.Next(0, 100);
                    if (fail < 40)
                    {
                        user.curStats[(int)StatType.Hp] -= 50;
                    }
                }
                if (isClear == true)
                {
                    Random rand = new Random();
                    float damage = rand.Next(20, 35) + 1 - (def - 5);
                    user.curStats[(int)StatType.Hp] -= damage;

                    int percent = rand.Next(10, 20); // 1, 2
                    user.haveGold = clearGold * (int)(atk * percent * 0.1f);
                }
            }

            void Dungeon()
            {
                int num = int.Parse(Console.ReadLine());
                DungeonClear(num);
            }
        }
    }
}

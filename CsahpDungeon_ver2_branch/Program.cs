namespace CsahpDungeon_ver2_branch
{
    internal class Program
    {
        //가장 먼저, static 함수로 선언된 이들을 class
        static void Intro() // 이름 선택
        {
            Console.WriteLine("스파르타 던전에 오신 것을 환영합니다.");
            Console.WriteLine("플레이어의 이름을 선택해주십시오.");
            Console.WriteLine("\n");
        }

        static int NameSelect()
        {
            //내용 입력
            string Name = Console.ReadLine();
            Console.WriteLine("\n");

            //내용 확인
            Console.WriteLine($"플레이어가 입력한 이름은 \"{Name}\" 입니다.");
            Console.WriteLine("\n");

            //선택지
            Console.WriteLine("1. 저장");
            Console.WriteLine("2. 취소");
            Console.WriteLine("\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            while (true)
            {
                Console.Write(">> ");
                int check = int.Parse(Console.ReadLine());

                switch (check)
                {
                    case 1:
                        Console.WriteLine("이름을 선택하셨습니다.");
                        Console.WriteLine("\n");
                        break;
                    case 2:
                        Console.WriteLine("이름을 다시 선택해주세요");
                        Console.WriteLine("\n");
                        break;

                    default:
                        Console.WriteLine("값을 다시 입력해주십시오");
                        Console.WriteLine("\n");
                        continue;
                }
                return check;
            }
        }

        static void Village() // 겹치는 구문이 있는데 클래스로 상속 받으면 처리하기 편할듯
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할수 있습니다.");
            Console.Write("\n");

            //Enum으로 나중에 변환 가능할 듯. villageList
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.Write("\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            while (true)
            {
                Console.Write(">> ");
                int check = int.Parse(Console.ReadLine());

                switch (check)
                {
                    case 1:
                        Console.WriteLine("1. 상태보기를 선택하셨습니다.");
                        Console.Write("\n");
                        Status();
                        break;
                    case 2:
                        Console.WriteLine("2. 인벤토리를 선택하셨습니다.");
                        Console.Write("\n");
                        Inventory();
                        break;

                    case 3:
                        Console.WriteLine("3. 상점을 선택하셨습니다.");
                        Console.Write("\n");
                        Shop();
                        break;

                    default:
                        Console.WriteLine("값을 다시 입력해주십시오");
                        Console.Write("\n");
                        continue;
                }
                return;
            }
        }

        static void Inventory()
        {
            //창 설명
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.Write("\n");

            //플레이어의 정보
            Console.WriteLine("장착중인 아이템");
            Console.WriteLine("현재 능력치");
            Console.Write("\n");

            //아이템 목록 for, foreach를 통해 아이템 배열이나 리스트 출력.
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("아이템");
            Console.Write("\n");

            //선택지
            Console.WriteLine("1. 장착하기");
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
                        Console.WriteLine("나가기를 선택하셨습니다.");
                        Console.Write("\n");
                        break;

                    case 1:
                        Console.WriteLine("장착하기를 선택하셨습니다.");
                        Console.Write("\n");
                        //Equip(); 근데 이거는 Item을 리스트에 넣어줘야 되기 때문에 보류;
                        break;

                    default:
                        Console.WriteLine("값을 다시 입력해주십시오");
                        Console.Write("\n");
                        continue;
                }
                return;
            }
        }

        //static void Equip()
        //{
        //장착 중인 거 표기
        //장착 중인 거면 [E]를 같이 출력, 아니면 [E] 없이 출력
        //아이템 리스트에 없는 것을 선택 시, 잘못된 입력입니다 출력
        //아이템은 중복 장착이 가능하며, 장착한 아이템은 Enum 또는 Struct status에 반영
        //}

        static void Shop()
        {
            //창 설명
            Console.WriteLine("상점");
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
            Console.WriteLine("1. 아이템 구매");
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
                    case 1:
                        Console.WriteLine("아이템 구매를 선택하셨습니다.");
                        Console.Write("\n");
                        //ItemBuy(); 나중에 아이템 리스트 만들고 제작 예정
                        break;
                    case 0:
                        Console.WriteLine("나가기를 선택하셨습니다.");
                        Console.Write("\n");
                        break;

                    default:
                        Console.WriteLine("값을 다시 입력해주십시오");
                        Console.Write("\n");
                        continue;
                }
                return;
            }
        }

        //static void ItemBuy()
        //{

        //}

        static void Status()
        {
            //창 설명
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.Write("\n");

            //플레이어의 정보(클래스로 바꿀 예정)
            Console.WriteLine("레벨");
            Console.WriteLine("직업");
            Console.WriteLine("공격력");
            Console.WriteLine("방어력");
            Console.WriteLine("체력");
            Console.WriteLine("Gold");
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
                        Console.WriteLine("나가기를 선택하셨습니다.");
                        Console.Write("\n");
                        break;

                    default:
                        Console.WriteLine("값을 다시 입력해주십시오");
                        Console.Write("\n");
                        continue;
                }
                return;
            }
        }

        static void Main(string[] args)
        {
            Intro();
            while (true)
            {
                if (NameSelect() == 1)
                {
                    break;
                }
            }

            Village();


            //Main의 끝
        }
    }
}

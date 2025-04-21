namespace CshapDungeonTutor
{
    internal class Program
    {
        // 화면 만들기 - 메인화면
        // 화면 만들기 - 상태보기
        // 화면 만들기 - 인벤토리
        // 화면 만들기 - 인벤토리 [장착관리]
        // 화면 만들기 - 상점
        // 화면 만들기 - 상점 [구매]

        // 기능1 [All] - 선택한 화면으로 이동하기
        // 기능2 [Stat] - 캐릭터의 정보 표시 (변경되는 정보를 확인)
        // 기능2_1 [Stat] - 장비 반영에 따른 정보 - 공격력/방어력
        // 기능3 [Inventory] - 보유 아이템 표시 (인벤토리)
        // 기능4 [Inventory] - 장비 장착
        // 기능5 [Shop] - 상점 리스트
        // 기능6 [Shop] - 구매 기능

        // 캐릭터 정보
        // 체력 / 이름 / 직업 / 공격력 / 방어력 / 체력 / Gold
        // 추가 공격력 / 추가 방어력

        // 아이템 <- 상점 리스트
        // 이름 / 장비타입 / 장비의벨류 / 설명 / 가격

        // 인벤토리

        static void Main(string[] args)
        {
           

        }
        static void DisplayMainUI()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            Console.Write(">> ");

            int result = CheckInput(1, 3);

            switch (result)
            {
                case 1:
                    DisplayStatUI();
                    break;

                case 2:
                    DisplayInventoryUI();
                    break;

                case 3:
                    DisplayShopUI();
                    break; 
            }
        }

       static  void DisplayStatUI()
        {
            Console.Clear();
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int result = CheckInput(0, 0);

            switch(result)
            {
                case 0:
                    DisplayMainUI();
                        break;
            }
        }

        static void DisplayInventoryUI()
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("1. 장착하기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int result = CheckInput(0, 1);

            switch (result)
            {
                case 0:
                    DisplayMainUI();
                    break;
                case 1:
                    break;
            }

        }

        static void DisplayShopUI()
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록");
            Console.WriteLine("");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int result = CheckInput(0, 1);

            switch (result)
            {
                case 0:
                    DisplayMainUI();
                    break;
                case 1:
                    break;
            }
        }
        static int CheckInput(int min, int max)
        {
            int result;
            while (true)
            {
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out result);
                if (isNumber)
                {
                    if (result >= mins && result <= max)
                        return result;
                }
                Console.WriteLine("잘못된 입력입니다.");
            }

            
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    internal class Village 
    {
        public void Show()
        {
            Console.WriteLine("[[스파르타 마을]]에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할수 있습니다.");
            Console.Write("\n");
        }

        public void Section()
        {
            Console.WriteLine("1. [상태 보기]");
            Console.WriteLine("2. [인벤토리]");
            Console.WriteLine("3. [상점]");
            Console.WriteLine("4. [휴식처]");
            Console.WriteLine("5. [던전 입장]");
            Console.Write("\n");
        }

        public void Select(out PlaceType place)
        {
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
        }
        public Village()
        {

        }
        public void StartVillage(out PlaceType place, ref Player user)
        {
            Show();
            Section();
            Select(out place);
        }
    }
}

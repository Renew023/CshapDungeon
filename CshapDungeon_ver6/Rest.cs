using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    internal class Rest()
    {
        public void StartRest(out PlaceType place, ref Player user)
        {
            Show(ref user);
            Section();
            Select(out place, ref user);
        }

        public void Show(ref Player user)
        {
            Console.WriteLine("[[휴식처]]");
            Console.WriteLine("500G를 지불하는 것으로 회복을 할 수 있습니다.");
            Console.Write("\n");
            Console.WriteLine($"[[현재 보유금 : {user.haveGold}G]]");
            Console.Write("\n");
        }

        public void Section()
        {
            //선택지
            Console.WriteLine("1. [휴식하기]");
            Console.WriteLine("0. [나가기]");
            Console.Write("\n");
        }

        public void Select(out PlaceType place, ref Player user)
        {
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
                        if (user.haveGold > 500)
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
                        }
                        else
                        {
                            Console.WriteLine("소지금이 부족하여 회복에 실패하셨습니다.");
                        }
                        continue;

                        //ItemBuy(); 나중에 아이템 리스트 만들고 제작 예정
                    case 0:
                        Console.WriteLine("[나가기]를 선택하셨습니다.");
                        Console.Write("\n");
                        place = PlaceType.Village;
                        return;

                    default:
                        Console.WriteLine("값을 다시 입력해주십시오");
                        continue;
                }
            }

        //플레이어 입력대기
        
        }
    }
}

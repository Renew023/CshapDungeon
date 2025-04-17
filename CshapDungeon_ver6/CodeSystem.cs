using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    //작법 도움 주는 코드
    
    
    internal class CodeSystem
    {
        public void LineTap(int line)
        {
            for (int i = 0; i < line; i++)
            {
                Console.Write("\n");
            }
        } // 끝
        public void LineTest()
        {
            Console.WriteLine("콘솔의 호출 횟수를 확인합니다.");
        }
    }
}

namespace CshapDungeon_ver6
{
    internal class Program
    {
        //1. Console.WriteLine이 활용된 라인들을 가독성을 위해 void 메서드로 데이터를 나누기
        //2. 중복된 내용을 void로 감싸고 필요한 경우 제너릭 또는 오버라이딩을 활용하여 데이터 값의 운용도 높이
        //3. 선택지 구문은 Enum 값을 활용하여 파트 나누기
        //4, 문법 뒤에 \n와 같이 가독성이 높아지는 코드를 넣을 수 있는 함수 만들기
        //5. For문을 메서드를 통해 활용하기
        //6. while문에서 3.에서 만든 Enum값을 활용하여 매칭 시스템 만들고
        //   0은 고정값이니 exit가 가능하도록 만든다.
        //7. 현재 나가기를 할 시에 village의 값을 매번 바꾸는데 그렇지 않고
        //   백업할 PlaceType을 만들어, 나가기를 누를 시 이전에 공간으로 바꿈.

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

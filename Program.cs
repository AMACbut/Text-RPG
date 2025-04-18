namespace Text_RPG
{
    internal class Program
    {   
        class Character        // 여기에 캐릭터의 정보(속성)와 행동(메서드)를 넣는다, 캐릭터를 만드는 틀 (캐릭터 공장).
        {
            public int Level { get; set; } = 1;     // 레벨을 저장할 수 있고 꺼내서 볼 수 있음 (초기값은 1), 외부에서 값을 넣고(get) / 꺼낼 수(set) 있는 변수.
            public string Name {  get; set; }
            public string Job { get; set; } = "전사";
            public int BaseAttack { get; set; } = 10;
            public int BaseDefense { get; set; } = 5;
            public int HP { get; set; } = 100;
            public int Gold { get; set; } = 800;

            public void PrintStatus()
            {
                Console.Clear();    // 화면 깔끔하게 초기화하고 처음부터 다시.
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");     // \n 는 다음줄을 비워준다.
                Console.WriteLine($"Lv. {Level:D2}");   //:D2 는 숫자를 2자리로 표시해주는 형식 지정자
                Console.WriteLine($"{Name} ( {Job} )"); 
                Console.WriteLine($"공격력 : ");
                Console.WriteLine($"방어력 : ");
                Console.WriteLine($"체 력 : {HP}");
                Console.WriteLine($"Gold : {Gold} G\n");
            }

            public void ShowInventory()
            {

            }

            public void ShowShop()
            {

            }
        }
        static void Main(string[] args)    // C#에서 프로그램이 실행될 때 가장 먼저 호출되는 진입점 메서드입니다.
        {
            PrintGreeting();    // 인사말을 출력하는 메서드를 호출. (화면에 환영 메시지 출력)
            string playerName = GetPlayerName();    // GetPlayerName()에서 이름을 반환받아 playerName 변수에 저장
            Character player = new Character { Name = playerName };     // Character 클래스(캐릭터 설계도)로 player라는 캐릭터 객체를 만들고, 입력한 이름을 넣음

            ShowVillage(player);        // 마을 화면을 보여주는 메서드 호출 (캐릭터 정보를 가지고 다음 화면으로 넘어감)
        }
        static void PrintGreeting()    // 인사말을 출력하는 메서드.
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.\n");    // \n 은 줄을 바꿀 때 사용하는 문자.
        }

        static string GetPlayerName()     // 플레이어 이름을 만드는 메서드.
        {
            string name = "";             // 이름을 저장할 변수. 처음에는 비어있음.
            bool isFirstTry = true;       // 첫 번째 시도인지 확인하는 변수. 처음에는 true.

            while (true)    // 무한 루프. 이름이 올바르게 입력될 때까지 계속 반복.
            {
                int inputLine = Console.CursorTop;      // 현재 커서 위치 저장 (줄 번호)

                // 이름 입력 루프
                do
                {
                    Console.SetCursorPosition(0, inputLine);        // 커서를 입력 라인으로 이동
                    Console.Write(">> " + (isFirstTry ? "이름을 입력해주세요: " : "이름을 다시 설정해주세요: "));   // 첫 시도이면 "이름을 입력해주세요", 아니면 "이름을 다시 설정해주세요" 표시

                    int padLength = Console.WindowWidth - Console.CursorLeft - 1;       // 남은 공간을 계산
                    Console.Write(new string(' ', padLength));                          // 남은 공간을 공백으로 채워서 화면 덮어쓰기
                    Console.SetCursorPosition(Console.CursorLeft - padLength, inputLine);       // 커서 다시 원위치

                    name = Console.ReadLine();      // 사용자로부터 이름 입력받기
                    isFirstTry = false;             // 첫 번째 시도가 끝났다는 걸 알려주는 코드

                } while (string.IsNullOrWhiteSpace(name));          // 이름이 비어 있으면 다시 입력 받음

                // 입력 완료 후 확인 단계
                Console.WriteLine($"\n입력하신 이름은 {name} 입니다.\n>> ");
                Console.WriteLine("1. 저장");
                Console.WriteLine("2. 취소");
                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();          // 사용자가 선택한 행동 입력 받기

                if (input == "1")       // 저장을 선택한 경우
                {
                    return name;        // 이름 저장하고 종료
                }
                else                    // 취소를 선택한 경우
                {
                    isFirstTry = true;  // 다시 입력 받을 준비
                    Console.Clear();    
                    Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                    Console.WriteLine("원하시는 이름을 설정해주세요.\n");
                }
            }
        }

        static void ShowVillage(Character character)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");                // 마을에 도착했을 때 출력되는 메시지
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 게임 종료\n");

            Console.Write("원하시는 행동을 입력해주세요.\n>> ");                        // 사용자에게 선택지를 제공하는 메뉴를 화면에 출력
            string input = Console.ReadLine();

            switch (input)                                                              // 사용자가 입력한 값에 따라 다른 동작을 수행
            {
                case "1":                                                               // 1번을 택했을 때
                    character.PrintStatus();                                           
                    break;
                case "2":                                                               // 2번을 택했을 때
                    character.ShowInventory();
                    break;
                case "3":                                                               // 3번을 택했을 때
                    character.ShowShop();
                    break;
                case "4":                                                               // 4번을 택했을 때 게임 종료
                    Console.WriteLine("\n게임을 종료합니다. 감사합니다!");
                    Environment.Exit(0);                                                // 프로그램 종료
                    break;
                default:                                                                // 사용자가 잘못된 입력을 했을 때 메시지 출력
                    Console.WriteLine("잘못된 입력입니다.\n");
                    break;
            }
        }
    }
}

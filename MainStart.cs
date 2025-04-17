using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class MainStart
    {
        public void PlayGame()
        {
            bool playing = true; // playing의 값이 true 일때

            PlayerInfo playerInfo = new PlayerInfo();
            Store store = new Store();
            Inventory inventory = new Inventory();

            while (playing) // playing이 true인동안 게임은 꺼지지않는다.
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다..");
                Console.WriteLine("1. 상태보기 \n2. 인벤토리\n3. 상점\n4. 게임종료");
                Console.WriteLine();
                Console.Write("원하시는 행동을 입력해주세요: ");
                string mode = Console.ReadLine();

                switch (mode)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("상태보기 선택하셨습니다.");
                        playerInfo.Info();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("인벤토리를 선택하셨습니다.");
                        inventory.MainInventory();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("상점를 선택하셨습니다.");
                        store.MainStore();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("게임을 종료합니다.");
                        playing = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
    }
}
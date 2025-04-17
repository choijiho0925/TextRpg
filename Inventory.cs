using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Inventory
    {
        public void MainInventory()
        {
            Console.WriteLine();
            Console.WriteLine("인벤토리 \n보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            Console.WriteLine("1.장착 관리 \n0.나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요. :");
            string input = Console.ReadLine();
            if (input == "0")
            {
                Console.Clear();
                return;  //0을 입력했을때 메인화면으로 돌아가는 걸 연결해야함   
            }
            else if (input == "1")
            {
                Console.Clear();
                Console.WriteLine("Gold가 부족합니다.");
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("올바른 값을 입력해주세요.");
                MainInventory();  // 0을 제외한 다른 버튼을 눌렀을때 다시 누르세요라고 안내하며 다시 키 입력
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Inventory
    {
        List<Item> items;
        public Inventory()
        {
            items = GameManager.Instance.Items;
        }

        public void MainInventory()
        {
            Console.WriteLine();
            Console.WriteLine("인벤토리 \n보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("$\"{item.Name} | {Item.StringOption(item.Type)}+{item.OptionValue} | {item.Description}"); //아이템 목록을 출력해야함
            Console.WriteLine();
            Console.WriteLine("1.장착 관리 \n0.나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요. :");
            string input = Console.ReadLine();
            if (input == "0")
            {
                Console.Clear();
                return;  //0을 입력했을때 메인화면으로 돌아가는 걸 연결해야함   
            }
            else if (input == "1")
            {

            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}

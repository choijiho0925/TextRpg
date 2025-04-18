using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Inventory
    {
        List<Item> Items;

        public Inventory()
        {
            Items = GameManager.Instance.Items;
        }

        public void MainInventory()
        {
            Console.WriteLine();
            Console.WriteLine("인벤토리 \n보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            foreach (Item item in Items)
                if (item.isBuy == true)
                {
                    Console.WriteLine($"-{(item.isEquipped ? "[E]" : "")}{item.Name} | {Item.StringOption(item.Type)}+{item.OptionValue} | {item.Description}");
                }
                else
                {

                }
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
                Console.Clear();
                InventoryManagement();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.");
                MainInventory();
            }
        }
        public void InventoryManagement()
        {
            Console.WriteLine();
            Console.WriteLine("인벤토리 - 장착 관리\r\n보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            foreach (Item item in Items)
                if (item.isBuy == true)
                {
                    Console.WriteLine($"-{item.Id} | {(item.isEquipped ? "[E]" : "")}{item.Name} | {Item.StringOption(item.Type)}+{item.OptionValue} | {item.Description}");
                }
                else
                {

                }
            Console.WriteLine();
            Console.WriteLine("0.나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요. :");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                Console.Clear();
                MainInventory();
            }
            else if (input >= 1 && input <= 6)
            {
                if (Items[input - 1].isBuy == true && Items[input - 1].isEquipped == false)
                {
                    Console.Clear();
                    Items[input - 1].isEquipped = true;
                    if (Items[input - 1].Type == OptionType.Defense)
                    {
                        GameManager.Instance.PlayerInfo.defensepower += Items[input - 1].OptionValue;
                    }
                    else
                    {
                        GameManager.Instance.PlayerInfo.attackpower += Items[input - 1].OptionValue;
                    }
                    InventoryManagement();
                }
                else if (Items[input - 1].isBuy == true && Items[input - 1].isEquipped == true)
                {
                    Console.Clear();
                    Items[input - 1].isEquipped = false;
                    if (Items[input - 1].Type == OptionType.Defense)
                    {
                        GameManager.Instance.PlayerInfo.defensepower -= Items[input - 1].OptionValue;
                    }
                    else
                    {
                        GameManager.Instance.PlayerInfo.attackpower -= Items[input - 1].OptionValue;
                    }
                    InventoryManagement();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.");
                InventoryManagement();
            }
        }
    }
}

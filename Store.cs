using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Store
    {
        public static List<Item> Items = new List<Item>()
        {
            new Item(1, "수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", OptionType.Defense, 1000, 5, false),
            new Item(2, "무쇠갑옷" , "무쇠로 만들어져 튼튼한 갑옷입니다.",OptionType.Defense, 2000, 9, false),
            new Item(3, "스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", OptionType.Defense, 3500, 15, false),
            new Item(4, "낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", OptionType.Attack, 600, 2, false),
            new Item(5, "청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", OptionType.Attack, 1500, 5, false),
            new Item(6, "스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", OptionType.Attack, 2500, 7, false)
        };

        public void MainStore()
        {
            Console.WriteLine();
            Console.WriteLine("상점\r\n필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{GameManager.Instance.PlayerInfo.gold}G"); // 플레이어 인포의 골드와 연결해야함
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            foreach (Item item in Items)
            {
                Console.WriteLine($"{item.Name} | {Item.StringOption(item.Type)}+{item.OptionValue} | {item.Description} | {(item.isBuy ? "구매완료" : $"{item.Gold}G")}");
            }
            Console.WriteLine("1. 아이템 구매\n0. 나가기");
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
                BuyItem();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("올바른 값을 입력해주세요.");
                MainStore();  // 0을 제외한 다른 버튼을 눌렀을때 다시 누르세요라고 안내하며 다시 키 입력
            }
        }

        public void BuyItem()
        {
            Console.WriteLine();
            Console.WriteLine("상점\r\n필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유골드]");
            Console.WriteLine($"{GameManager.Instance.PlayerInfo.gold}G"); // 플레이어 인포의 골드와 연결해야함
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            foreach (Item item in Items)
            {
                Console.WriteLine($"- {item.Id} | {item.Name} | {Item.StringOption(item.Type)}+{item.OptionValue} | {item.Description} | {item.Gold}G");
            }
            Console.WriteLine("\n0.나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요 :");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                Console.Clear();
                MainStore();
            }
            else if (input >= 1 && input <= 6)
            {
                if (GameManager.Instance.PlayerInfo.gold >= Items[input - 1].Gold)
                {
                    Console.Clear();
                    GameManager.Instance.PlayerInfo.gold -= Items[input - 1].Gold;
                    Items[input - 1].isBuy = true;
                    Console.WriteLine("구매를 완료했습니다.");
                    MainStore();
                }
                else if (GameManager.Instance.PlayerInfo.gold <= Items[input - 1].Gold)
                {
                    Console.Clear();
                    Console.WriteLine("Gold가 부족합니다.");
                    MainStore();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.");
                BuyItem();
            }
        }
    }
}
//[아이템 목록]
//- 수련자 갑옷 | 방어력 + 5 | 수련에 도움을 주는 갑옷입니다.             |  1000 G
//- 무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.           |  2000 G
//- 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  3500 G
//- 낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.            |  600 G
//- 청동 도끼     | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다.        |  1500 G
//- 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |  2500 G

﻿using System.ComponentModel.Design;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.Arm;
using static TextRPG.Program;

namespace TextRPG
{
    internal class Program
    {
        public class GameManager
        {
            private static GameManager instance;

            public static GameManager Instance
            {
                get
                {
                    if (instance == null)
                        instance = new GameManager();
                    return instance;
                }
            }
            private GameManager()
            {
                PlayerInfo = new PlayerInfo();
                Items = new List<Item>()
                {
                    new Item(1, "수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", OptionType.Defense, 1000, 5, false, false),
                    new Item(2, "무쇠갑옷" , "무쇠로 만들어져 튼튼한 갑옷입니다.",OptionType.Defense, 2000, 9, false, false),
                    new Item(3, "스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", OptionType.Defense, 3500, 15, false, false),
                    new Item(4, "낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", OptionType.Attack, 600, 2, false, false),
                    new Item(5, "청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", OptionType.Attack, 1500, 5, false, false),
                    new Item(6, "스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", OptionType.Attack, 2500, 7, false, false)
                };
            }
            public PlayerInfo PlayerInfo;

            public List<Item> Items;

        }

        public class PlayerInfo
        {
            public string job { get; set; } = "( 전사 )";

            public int level { get; set; } = 01;
            public int attackpower { get; set; } = 10;
            public int defensepower { get; set; } = 5;
            public int healthpower { get; set; } = 100;
            public int gold { get; set; } = 10000;

            public void Info()
            {
                Console.WriteLine();
                Console.Write("Level." + level.ToString("D2") + "\nChad" + job + "\n공격력 :" + GameManager.Instance.PlayerInfo.attackpower + $"(+{GameManager.Instance.PlayerInfo.attackpower -= attackpower})" + "\n방어력 :"
                + GameManager.Instance.PlayerInfo.defensepower + $"(+{GameManager.Instance.PlayerInfo.defensepower -= defensepower})" + "\n체 력 :" + healthpower + "\nGold :" + GameManager.Instance.PlayerInfo.gold + "G\n\n 0. 나가기 :");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.Clear();
                    return;  //0을 입력했을때 메인화면으로 돌아가는 걸 연결해야함                
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("올바른 값을 입력해주세요.");
                    Info();  // 0을 제외한 다른 버튼을 눌렀을때 다시 누르세요라고 안내하며 다시 키 입력
                }
            }
        }

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

        public class Item
        {
            public int Id;
            public string Name { get; set; }
            public string Description { get; set; }
            public OptionType Type { get; set; }
            public int Gold { get; set; }
            public int OptionValue { get; set; }

            public bool isBuy;
            public bool isEquipped;

            public Item(int id, string name, string description, OptionType type, int gold, int optionValue, bool isBuyItem, bool isEquippedItem)
            {
                Id = id;
                Name = name;
                Description = description;
                Type = type;
                Gold = gold;
                OptionValue = optionValue;
                isBuy = isBuyItem;
                isEquipped = isEquippedItem;
            }

            public static string StringOption(OptionType type)
            {
                if (type == OptionType.Attack)
                {
                    return "공격력";
                }
                else if (type == OptionType.Defense)
                {
                    return "방어력";
                }
                else
                {
                    return "";
                }
            }
        }

        public enum OptionType
        {
            Defense, Attack
        }

        class Store
        {
            List<Item> Items;

            public Store()
            {
                Items = GameManager.Instance.Items;
            }

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
                    Console.WriteLine($"- {item.Id} | {item.Name} | {Item.StringOption(item.Type)}+{item.OptionValue} | {item.Description} | {(item.isBuy ? "구매완료" : $"{item.Gold}G")}");
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
                    if (Items[input - 1].isBuy == true)
                    {
                        Console.Clear();
                        Console.WriteLine("이미 구매한 아이템입니다.");
                        BuyItem();
                    }
                    else if (GameManager.Instance.PlayerInfo.gold >= Items[input - 1].Gold)
                    {
                        Console.Clear();
                        GameManager.Instance.PlayerInfo.gold -= Items[input - 1].Gold;
                        Items[input - 1].isBuy = true;
                        Console.WriteLine("구매를 완료했습니다.");
                        BuyItem();
                    }
                    else if (GameManager.Instance.PlayerInfo.gold <= Items[input - 1].Gold)
                    {
                        Console.Clear();
                        Console.WriteLine("Gold가 부족합니다.");
                        BuyItem();
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
                    if (item.isBuy == true )
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
    
    static void Main(string[] args)
        {
            MainStart mainStart = new MainStart();
            mainStart.PlayGame();
        }
    }
}

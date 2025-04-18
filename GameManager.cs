using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
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
}

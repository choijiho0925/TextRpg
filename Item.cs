using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
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
}
//[아이템 목록]
//- 수련자 갑옷 | 방어력 + 5 | 수련에 도움을 주는 갑옷입니다.             |  1000 G
//- 무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.           |  구매완료
//- 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  3500 G
//- 낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.            |  600 G
//- 청동 도끼     | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다.        |  1500 G
//- 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |  구매완료


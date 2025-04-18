using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
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
            Console.Write("Level." + level.ToString("D2") + "\nChad" + job + "\n공격력 :" + GameManager.Instance.PlayerInfo.attackpower + "\n방어력 :"
            + GameManager.Instance.PlayerInfo.defensepower + "\n체 력 :" + healthpower + "\nGold :" + GameManager.Instance.PlayerInfo.gold + "G\n\n 0. 나가기 :");
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
}

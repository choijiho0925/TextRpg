﻿using System;
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
        }
        public PlayerInfo PlayerInfo;
    }
}

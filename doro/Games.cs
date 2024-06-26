﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doro
{
    public static class Games
    {
        public readonly static GameDefinition Dorfromantik = GameDefinitions.Doro.GetGame();

        public readonly static GameDefinition Duel = GameDefinitions.Duel.GetGame();

        public static List<GameDefinition> GetAllGames() => [ Dorfromantik, Duel ];
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace doro
{
    using CategoryScore = Dictionary<string, int>;
    using PackScore = Dictionary<string, Dictionary<string, int>>;
    using GameScore = Dictionary<string, Dictionary<string, Dictionary<string, int>>>;

    public class ScoreSheet(string playerName)
    {
        public string Player { get; set; } = playerName;

        public GameScore Score { get; set; } = [];

        public int this[string packId, string categoryId, string goalId]
        {
            get { return GetScore(packId, categoryId, goalId); }
            set { SetScore(packId, categoryId, goalId, value); }
        }

        public int GetScore(string packId, string categoryId, string goalId)
        {
            if (Score.ContainsKey(packId) && Score[packId].ContainsKey(categoryId) && Score[packId][categoryId].ContainsKey(goalId))
            {
                return Score[packId][categoryId][goalId];
            }
            return 0;
        }

        public void SetScore(string packId, string categoryId, string goalId, int value)
        {
            if (!Score.ContainsKey(packId))
            {
                Score[packId] = [];
            }
            if (!Score[packId].ContainsKey(categoryId))
            {
                Score[packId][categoryId] = [];
            }
            Score[packId][categoryId][goalId] = value;
        }

        public int GetCategoryScore(GameConfiguration game, string categoryId)
        {
            
            int score = 0;
            foreach (var pack in Score)
            {
                if (pack.Value.ContainsKey(categoryId))
                {
                    score += pack.Value[categoryId].Values.Sum();
                }
            }
            return score;
        }
    }
}

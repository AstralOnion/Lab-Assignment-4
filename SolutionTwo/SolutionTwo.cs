using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SolutionTwo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Party myParty = new Party();
        myParty.PrintCharacterInfo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public class Character
    {
        public string characterName;
        public string characterClass;
        public int level;
        public int constitutionScore;
        public string charRace;
        public int hitPoints;
        public bool rolledCheck;
        public bool toughCheck;
        private int dieNum;
        private int rolledHitPoints;
        private int levelOne;
        private int dieAvg;
        public int featBonus;

        Dictionary<string, int> classDice = new Dictionary<string, int>()
        {
            ["Artificer"] = 8,
            ["Barbarian"] = 12,
            ["Bard"] = 8,
            ["Cleric"] = 8,
            ["Druid"] = 8,
            ["Fighter"] = 10,
            ["Monk"] = 8,
            ["Paladin"] = 10,
            ["Ranger"] = 10,
            ["Rogue"] = 8,
            ["Sorcerer"] = 6,
            ["Warlock"] = 8,
            ["Wizard"] = 6
        };

        Dictionary<int, int> conModifier = new Dictionary<int, int>()
        {
            [1] = -5,
            [2] = -4,
            [3] = -4,
            [4] = -3,
            [5] = -3,
            [6] = -2,
            [7] = -2,
            [8] = -1,
            [9] = -1,
            [10] = 0,
            [11] = 0,
            [12] = 1,
            [13] = 1,
            [14] = 2,
            [15] = 2,
            [16] = 3,
            [17] = 3,
            [18] = 4,
            [19] = 4,
            [20] = 5,
            [21] = 5,
            [22] = 6,
            [23] = 6,
            [24] = 7,
            [25] = 7,
            [26] = 8,
            [27] = 8,
            [28] = 9,
            [29] = 9,
            [30] = 10
        };

        Dictionary<int, int> averages = new Dictionary<int, int>()
        {
            [6] = 4,
            [8] = 5,
            [10] = 6,
            [12] = 7,
        };
        public Character(string name, string charClass, int lvl, int con, string race, bool rolled, int hp, int Bonus)
        {
            characterName = name;
            characterClass = charClass;
            level = lvl;
            constitutionScore = con;
            charRace = race;
            hitPoints = hp;
            rolledCheck = rolled;
            featBonus = Bonus;
            //bonus is to stand in for Tough/Stout as well as race bonuses
            if (level == 1)
            {
                hitPoints = classDice[characterClass] + conModifier[constitutionScore] + featBonus;
                Debug.Log("My character's hitpoints are " + hitPoints);

            }
            else if (level >= 2)
                levelOne = classDice[characterClass] + conModifier[constitutionScore] + featBonus;

            CalculateHP();
        }
        public void CalculateHP()
        {
            dieNum = classDice[characterClass];
            if (rolledCheck == false)
            {
                dieAvg = averages[dieNum];
                hitPoints = levelOne + dieAvg * (level - 1) + conModifier[constitutionScore] * (level - 1);
            }
            else if (rolledCheck == true)
            {
                for (int i = 0; i < level - 1; i++)
                {
                    int rolledHP = UnityEngine.Random.Range(1, dieNum + 1);
                    Debug.Log("Rolled a " + rolledHP);
                    rolledHitPoints = rolledHitPoints + rolledHP;
                    hitPoints = levelOne + rolledHitPoints + conModifier[constitutionScore] * (level - 1);
                }
            }
        }
    }
    public class Party
    {
        Character Dennis = new Character("Dennis", "Druid", 3, 20, "Elf", true, 0, 0);
        Character Bingo = new Character("Bingo Johnathan Faarquaad the Third", "Fighter", 5, 16, "Human", false, 0, 2);
        public void PrintCharacterInfo()
        {
            Debug.LogFormat("My character's name is {0}, they are a level {1} {2} {3} with a constitution score of {4}, and has an hp value of {5}", Dennis.characterName, Dennis.level, Dennis.charRace, Dennis.characterClass, Dennis.constitutionScore, Dennis.hitPoints);
            Debug.LogFormat("My character's name is {0}, they are a level {1} {2} {3} with a constitution score of {4}, and has an hp value of {5}", Bingo.characterName, Bingo.level, Bingo.charRace, Bingo.characterClass, Bingo.constitutionScore, Bingo.hitPoints);
        }


        
    }
}

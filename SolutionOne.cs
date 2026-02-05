using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    public string characterName;
    public string characterClass;
    public int level;
    public int constitutionScore;
    public string charRace;
    public bool toughCheck;
    public bool stoutCheck;
    public bool rolledCheck;

    private string toughText;
    private string stoutText;
    private string calculateText;
    private int hitPoints;

    // Start is called before the first frame update
    void Start()
    {
        if (rolledCheck == false)
        {
            calculateText = "averaged";
        }
        else if (rolledCheck == true)
        {
            calculateText = "rolled";
        }

        if (toughCheck == false)
        {
            toughText = "does not have the Tough feat";
        }
        else if (toughCheck == true)
        {
            toughText = "and has the Tough feat";
        }
        if (stoutCheck == false)
        {
            stoutText = "and does not have the Stout feat.";
        }
        else if (stoutCheck == true)
        {
            stoutText = "and has the Stout feat.";
        }
        Debug.Log("My character " + characterName + " is a level " + level + " " + characterClass + " with a CON score of " + constitutionScore + " and is of the " + charRace + " race, " + toughText + " " + stoutText + " I want my HP " + calculateText + ".");
        Debug.Log("Calculating Hit Points...");
    }

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

    // Update is called once per frame
    void Update()
    {
        
    }
}

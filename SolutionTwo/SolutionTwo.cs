using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionTwo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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

        public Character()
        {
            characterName = "Not assigned";
            characterClass = "Fighter";
            level = 1;
            constitutionScore = 14;
            charRace = "Dwarf";
            Debug.Log("Introducing " + characterName + ", a level " + level + " " + charRace + " " + characterClass + " with a CON score of " + constitutionScore);
        }
    }
    public class Party
    {
        Character Dennis = new Character();
        Debug.Log(Dennis.characterName + " exists!");
    }
}

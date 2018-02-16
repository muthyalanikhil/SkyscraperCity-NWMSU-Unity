using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkyscraperMaker : MonoBehaviour
{
    public string skyscraperHeights;
    public GameObject ground;
    public string skyscraperLocations;
    // Use this for initialization
    void Start()
    {
        generateSkyscrapers();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void generateSkyscrapers()
    {
        char[] letters = skyscraperHeights.ToCharArray();
        string[] locations = skyscraperLocations.Split(',');
        GameObject[] diceArray = new GameObject[6];
        for (int i = 0; i < 6; i++)
        {
            diceArray[i] = (GameObject)Resources.Load("dieRed" + (i + 1));
        }
        for (int i = 0; i < letters.Length; i++)
        {
            var count = 0;
            for (int j = 0; j < TextToNumber(letters[i].ToString().ToUpper()); j++)
            {
                int location = 0;
                if (locations.Length >= letters.Length && Int32.TryParse(locations[i], out location))
                {
                    var groundTagObject = GameObject.FindWithTag("Ground");
                    var initialPosition = (groundTagObject.GetComponent<BoxCollider2D>().offset.y + groundTagObject.GetComponent<BoxCollider2D>().size.y);
                    Instantiate(diceArray[count], new Vector3(location, initialPosition + j , 0.0f), Quaternion.identity);
                    count++;
                    if (count == 6)
                    {
                        count = 0;
                    }
                }
            }
        }
    }

    int TextToNumber(string text)
    {
        return text
            .Select(c => c - 'A' + 1)
            .Aggregate((sum, next) => sum * 26 + next);
    }
}

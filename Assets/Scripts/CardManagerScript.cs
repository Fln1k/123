using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Card
{
    public string Name;
    public Sprite Logo;
    public int Attack;
    public int Defense;

    public Card(string name,string logoPath,int attack,int defense)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Defense = defense;
    }
}

public static class CardManager
{
    public static List<Card> AllCards = new List<Card>();
}

public class CardManagerScript : MonoBehaviour
{
    public void Awake()
    {
        CardManager.AllCards.Add(new Card("Guard", "Images/Guard", 1, 2));
        CardManager.AllCards.Add(new Card("Bat", "Images/Bat", 2, 1));
        CardManager.AllCards.Add(new Card("Werewolf", "Images/Werewolf", 2, 2));
        CardManager.AllCards.Add(new Card("Archer", "Images/Archer", 2, 2));
        CardManager.AllCards.Add(new Card("Dragon", "Images/GoldDragon", 8, 8));
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class sys : MonoBehaviour
{
    public string[] cards = {"1o" ,"2o" ,"3o" ,"4o" ,"5o" ,"6o" ,"7o" ,"8o" ,"9o" ,"10o" 
                            ,"1c" ,"2c" ,"3c" ,"4c" ,"5c" ,"6c" ,"7c" ,"8c" ,"9c" ,"10c" 
                            ,"1e" ,"2e" ,"3e" ,"4e" ,"5e" ,"6e" ,"7e" ,"8e" ,"9e" ,"10e" 
                            ,"1b" ,"2b" ,"3b" ,"4b" ,"5b" ,"6b" ,"7b" ,"8b" ,"9b" ,"10b"};

    public List<string> shuffled;
    [SerializeField] deckAnim deckAnim;
    public class player
    {
        public bool isHere;
        public int score;
        public string[] cards = new string[3];
    }

    public player player1 = new player(), CPU = new player();
    
    void Start(){
        StartCoroutine(Shuffle());
    }
    void Update()
    {
        
    }

    IEnumerator Shuffle()
    {
        // shuffle the cards and store them in "cards_shuffled"
        List<string> cards_list = cards.ToList();
        for(int t = 0; t < cards.Length; t++)
        {
            int rand = Random.Range(0,cards_list.Count());
            shuffled.Add(cards_list[rand]);
            cards_list.Remove(cards_list[rand]);
            yield return null;
        }
        
        
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
       // yield return new WaitUntil(() => player1.isHere && player2.isHere);

        int cardRef = 0;
        while(cardRef < 3)
        {
            player1.cards[cardRef] = shuffled[0];
            shuffled.RemoveAt(0);
            CPU.cards[cardRef] = shuffled[0];
            shuffled.RemoveAt(0);
            cardRef++;
            yield return null;
        }
        StartCoroutine(deckAnim.animPlayers());
    }



//Code du bot 
//tous est en commentaire psk je suis pas sur de savoir si sa marche
//mon pc et unity ne s'entendent pluis vraiment 


/*
    // liste des cartes
    public List<string> tableCards = new List<string>();

    public IEnumerator EnemyTurn()
    {
        Debug.Log("Le bot réfléchit...");
        yield return new WaitForSeconds(1.5f); // Pause de 1.5s pour faire za3ma naturel

        int cardToPlayIndex = -1;
        bool matchFound = false;

        for (int i = 0; i < player2.cards.Length; i++)
        {
            string botCard = player2.cards[i];

            if (botCard != "ff" && !string.IsNullOrEmpty(botCard))
            {
                string botCardValue = ExtractValue(botCard); // On récup le chiffre

                for (int j = 0; j < tableCards.Count; j++)
                {
                    string tableCardValue = ExtractValue(tableCards[j]);

                    if (botCardValue == tableCardValue)
                    {
                        cardToPlayIndex = i;
                        matchFound = true;
                        Debug.Log("Le bot capture : " + tableCards[j] + " avec son " + botCard);
                        
                        tableCards.RemoveAt(j);
                        break; //son tours stop
                    }
                }
            }
            if (matchFound) break;
        }

        //si il a pas de jeu, il joue la première carte qu'il a
        if (!matchFound)
        {
            for (int i = 0; i < player2.cards.Length; i++)
            {
                string botCard = player2.cards[i];
                if (botCard != "ff" && !string.IsNullOrEmpty(botCard))
                {
                    cardToPlayIndex = i;
                    Debug.Log("Le bot pose une carte sur la table : " + botCard);
                    
                    tableCards.Add(botCard);
                    break;
                }
            }
        }

        //il jour 
        if (cardToPlayIndex != -1)
        {
            player2.cards[cardToPlayIndex] = "ff"; 

            player2Hand.text = "";
            for (int k = 0; k < player2.cards.Length; k++)
            {
                if (player2.cards[k] != "ff")
                {
                    player2Hand.text += player2.cards[k] + " ";
                }
            }
            
            card_display.text = "Table : ";
            for(int t = 0; t < tableCards.Count; t++)
            {
                card_display.text += tableCards[t] + " ";
            }
        }

        Debug.Log("Tour du bot terminé.");
    }

    public string ExtractValue(string card)
    {
        if (card == "ff" || string.IsNullOrEmpty(card)) return "";
        return card.Substring(0, card.Length - 1);
    }

    */
}

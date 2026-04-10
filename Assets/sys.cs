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
    [SerializeField] TextMeshProUGUI card_display, player1Hand, player2Hand;

    public class player
    {
        public bool isHere;
        public int score;
        public string[] cards = new string[3];
    }

    player player1 = new player(), player2 = new player();
    
    void Start(){
        StartCoroutine(fillAndShuffle());
    }
    void Update()
    {
        
    }

    IEnumerator fillAndShuffle()
    {
        for(int k = 0; k < cards.Length; k++)
        {
            card_display.text += cards[k] + ", ";
        }
        // shuffle the cards and store them in "cards_shuffled"
        List<string> cards_list = cards.ToList();
        for(int t = 0; t < cards.Length; t++)
        {
            int rand = Random.Range(0,cards_list.Count());
            shuffled.Add(cards_list[rand]);
            cards_list.Remove(cards_list[rand]);
        }
        yield return null;
        
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
       // yield return new WaitUntil(() => player1.isHere && player2.isHere);

        int cardRef = 0;
        while(cardRef < 3)
        {
            player1.cards[cardRef] = shuffled[0];
            player1Hand.text += player1.cards[cardRef] + " ";
            shuffled.RemoveAt(0);
            yield return new WaitForSeconds(0.5f);
            player2.cards[cardRef] = shuffled[0];
            player2Hand.text += player2.cards[cardRef] + " ";
            shuffled.RemoveAt(0);
            yield return new WaitForSeconds(1f);
            cardRef++;
            
        }
        for(int k = 0; k < shuffled.Count(); k++)
        {
            card_display.text += shuffled[k] + ", ";
        }
        
        yield return null;
    }
}

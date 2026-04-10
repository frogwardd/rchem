using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class sys : MonoBehaviour
{
    public string[] cards,cards_shuffled = new string[40];

    char[] signs = {'o','c','e','b'};

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
        // fill the cards appropriately
        int indicator = 0;
        for(int i = 0; i<4;i++){
            for(int j=1;j<11;j++){
                cards[indicator] += j.ToString() + signs[i];
                indicator++;
                yield return null;
            }
            yield return null;
        }
        
        // shuffle the cards and store them in "cards_shuffled"
        List<string> cards_list = cards.ToList();
        for(int t = 0; t < cards.Length; t++)
        {
            int rand = Random.Range(0,cards_list.Count());
            cards_shuffled[t] = cards_list[rand];
            cards_list.Remove(cards_list[rand]);
        }

        
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
       // yield return new WaitUntil(() => player1.isHere && player2.isHere);

        int i, cardRef = 0;
        for (i = 0; i < 5;i += 2)
        {
            player1.cards[cardRef] = cards_shuffled[i];
            cards_shuffled[i] = "ff";
            player1Hand.text += player1.cards[cardRef] + " ";
            yield return new WaitForSeconds(0.5f);
            player2.cards[cardRef] = cards_shuffled[i+1];
            cards_shuffled[i+1] = "ff";
            player2Hand.text += player2.cards[cardRef] + " ";
            yield return new WaitForSeconds(1f);
            cardRef++;
        }
        for(int k = 0; k < cards_shuffled.Length; k++)
        {
            card_display.text += cards_shuffled[k] + ", ";
        }
        
        yield return null;
    }
}

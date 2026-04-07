using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class sys : MonoBehaviour
{
    public string[] cards,cards_shuffled = new string[40];
    char[] signs = {'d','a','s','h'};
    void Start(){
        StartCoroutine(fillAndShuffle());
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
    }
}

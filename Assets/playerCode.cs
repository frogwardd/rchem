using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class playerCode : MonoBehaviour
{
    [SerializeField] sys system;
    [SerializeField] SpriteRenderer[] card;
    [SerializeField] Sprite[] deck;

    bool faceDown = false;
    float rotY;
    void Start()
    {
        deck = Resources.LoadAll<Sprite>("deck");
    }
    void Update()
    {
        
        
    }

    public IEnumerator cardArt()
    {
        rotY = 180;
        faceDown = true;
        StartCoroutine(rotate());
        yield return new WaitUntil(() => rotY <= 90);
        for (int i = 0; i < 3; i++)
        {
            int cardIntInArray = 0;
            Debug.Log(cardIntInArray);
            switch (system.player1.cards[i][1])
            {
                case 'o':
                    cardIntInArray += 0;
                    break;
                case 'c':
                    cardIntInArray += 10;
                    break;
                case 'e':
                    cardIntInArray += 20;
                    break;
                case 'b':
                    cardIntInArray += 30;
                    break;
            }
            if(system.player1.cards[i].Length == 3)
            {
                cardIntInArray += 9;
            }
            else
            {
                cardIntInArray += Convert.ToInt32(system.player1.cards[i][0]) - 1 - 48;
            }
            

            card[i].sprite = deck[cardIntInArray];
            
        }
        yield return null;
        
        
    }

    IEnumerator rotate()
    {
        while (transform.rotation.y >= 0)
        {
            rotY = math.max(rotY - 180 * Time.deltaTime, 0);
            card[0].transform.rotation = Quaternion.Euler(0, rotY, 0);
            card[1].transform.rotation = Quaternion.Euler(0, rotY, 0);
            card[2].transform.rotation = Quaternion.Euler(0, rotY, 0);
            yield return null;
        }
        
    }

}

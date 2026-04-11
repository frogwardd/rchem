using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class deckAnim : MonoBehaviour
{
    [SerializeField] playerCode player;
    [SerializeField] CPU cpu;
    [SerializeField] GameObject cardTemplate;
    void Start()
    {
        StartCoroutine(animPlayers());
    }
    IEnumerator animPlayers()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject card = Instantiate(cardTemplate, transform.parent);
            Vector3 dir = (player.card[i].transform.position - card.transform.position).normalized;
            while(card.transform.position.x <= player.card[i].transform.position.x)
            {
                card.transform.Translate(dir * 50 * Time.deltaTime);
                yield return null;
            }
            player.card[i].enabled = true;
            card.transform.position = transform.position;

            yield return new WaitForSeconds(0.5f);
            dir = (cpu.card[i].transform.position - card.transform.position).normalized;
            while(card.transform.position.x <= cpu.card[i].transform.position.x)
            {
                card.transform.Translate(dir * 50 * Time.deltaTime);
                yield return null;
            }
            cpu.card[i].enabled = true;
            card.transform.position = transform.position;
            yield return new WaitForSeconds(0.5f);
        }
        
        
    }
}

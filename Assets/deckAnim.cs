using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class deckAnim : MonoBehaviour
{
    [SerializeField] playerCode player;
    [SerializeField] CPU cpu;
    [SerializeField] GameObject cardTemplate;
    void Start()
    {

    }
    public IEnumerator animPlayers()
    {
        GameObject card = Instantiate(cardTemplate, transform.parent);
        Vector3 dir;
        for (int i = 0; i < 3; i++)
        {
            
            dir = (player.card[i].transform.position - card.transform.position).normalized;
            while(card.transform.position.x != player.card[i].transform.position.x)
            {
                Vector2 move = new Vector2(math.min(card.transform.position.x + dir.x * 50 * Time.deltaTime,player.card[i].transform.position.x),math.max(card.transform.position.y + dir.y * 50 * Time.deltaTime,player.card[i].transform.position.y));
                card.transform.position = move;
                yield return null;
            }
            card.transform.position = transform.position;
            player.card[i].enabled = true;
            

            yield return new WaitForSeconds(0.5f);
            dir = (cpu.card[i].transform.position - card.transform.position).normalized;
            
            while(card.transform.position.x != cpu.card[i].transform.position.x)
            {
                Vector2 move = new Vector2(math.min(card.transform.position.x + dir.x * 50 * Time.deltaTime,cpu.card[i].transform.position.x),math.min(card.transform.position.y + dir.y * 50 * Time.deltaTime,cpu.card[i].transform.position.y));
                card.transform.position = move;
                yield return null;
            }
            card.transform.position = transform.position;
            cpu.card[i].enabled = true;
            
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(player.cardArt());
    }
}

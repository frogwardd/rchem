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
        
        Vector3 dir;
        for (int i = 0; i < 3; i++)
        {
            player.card[i] = Instantiate(cardTemplate, transform.parent).GetComponent<SpriteRenderer>();
            dir = (player.cardTransform[i].position - player.card[i].transform.position).normalized;
            while(player.card[i].transform.position.x != player.cardTransform[i].position.x)
            {
                Vector2 move = new Vector2(math.min(player.card[i].transform.position.x + dir.x * 50 * Time.deltaTime,player.cardTransform[i].position.x),math.max(player.card[i].transform.position.y + dir.y * 50 * Time.deltaTime,player.cardTransform[i].position.y));
                player.card[i].transform.position = move;
                yield return null;
            }
            
            
            yield return new WaitForSeconds(0.5f);
            cpu.card[i] = Instantiate(cardTemplate, transform.parent).GetComponent<SpriteRenderer>();
            dir = (cpu.cardTransform[i].transform.position - cpu.card[i].transform.position).normalized;
            
            while(cpu.card[i].transform.position.x != cpu.cardTransform[i].position.x)
            {
                Vector2 move = new Vector2(math.min(cpu.card[i].transform.position.x + dir.x * 50 * Time.deltaTime,cpu.cardTransform[i].position.x),math.min(cpu.card[i].transform.position.y + dir.y * 50 * Time.deltaTime,cpu.cardTransform[i].position.y));
                cpu.card[i].transform.position = move;
                yield return null;
            }
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(player.cardArt());
    }
}

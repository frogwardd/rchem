using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string PlayGame = "Main";

    public void PlayButton()
    {
        SceneManager.LoadScene(PlayGame);
    }
}

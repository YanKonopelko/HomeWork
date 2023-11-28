using UnityEngine;
using UnityEngine.UI;
namespace CircleHit
{
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject pauseScreen;

    private void Start()
    {
        Instance = this;
    }
    public void UpdateScoreText(int currentScore, bool isBest){
        scoreText.text = currentScore.ToString();
        if(isBest)
        {
            scoreText.text = "New Score:\n" + currentScore.ToString();
        }
    }

    public void Pause(bool isPaused)
    {
        pauseScreen.SetActive(isPaused);
    }
}
}
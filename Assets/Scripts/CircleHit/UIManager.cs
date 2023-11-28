using UnityEngine;
using UnityEngine.UI;
namespace CircleHit
{
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text newScoreText;
    private void Start()
    {
        Instance = this;
    }
    public UpdateScoreText(int curentScore, int BestScore){
        if(BestScore == curentScore){
            newScoreText.text = BestScore.ToString()
        }
        scoreText.text = curentScore;
    }
}
}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShapeShiftScene : MonoBehaviour
{
    public static ShapeShiftScene Instance;

    private int _scorePoints = 0;
    private int _bestScorePoints = 0;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Time.timeScale = 1;
        _bestScorePoints = PlayerPrefs.HasKey(PlayerPrefs.GetString("LastGame") + "BestScore")?PlayerPrefs.GetInt(PlayerPrefs.GetString("LastGame") + "BestScore"):0;
    }

    public void Lose()
    {
        ScenesManager.instance.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void AddScore(int Score){
        _scorePoints += Score;
        UIManager.Instance.UpdateScoreText(_scorePoints,false);
        if(_scorePoints > _bestScorePoints){
            _bestScorePoints = _scorePoints;
            UIManager.Instance.UpdateScoreText(_scorePoints,true);

            PlayerPrefs.SetInt(PlayerPrefs.GetString("LastGame") + "BestScore",_bestScorePoints);
            PlayerPrefs.SetInt("IsNewRecord",1);

        }
    }
    public void Pause()
    {
        isPaused = !isPaused;
        UIManager.Instance.Pause(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void ToMenu()
    {
        ScenesManager.instance.LoadScene("MainMenu");
    }
}

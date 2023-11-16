using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShapeShiftScene : MonoBehaviour
{
    public static ShapeShiftScene Instance;

    private int _scorePoints = 0;
    private int _bestScorePoints = 0;

    [SerializeField] private Text scorePointsText;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (PlayerPrefs.HasKey("ShapeShiftBestScore"))
            _bestScorePoints = PlayerPrefs.GetInt("ShapeShiftBestScore");
        scorePointsText.text = "" + _scorePoints;
    }

    public void Lose()
    {
        TryToSetScore();
        ScenesManager.instance.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddPoint()
    {
        _scorePoints += 1;
        scorePointsText.text = "" + _scorePoints;
        if (_bestScorePoints < _scorePoints)
        {
            _bestScorePoints = _scorePoints;
        }
    }

    private void TryToSetScore()
    {
        if (_scorePoints > PlayerPrefs.GetInt("ShapeShiftBestScore"))
            PlayerPrefs.SetInt("ShapeShiftBestScore", _scorePoints);
    }

}

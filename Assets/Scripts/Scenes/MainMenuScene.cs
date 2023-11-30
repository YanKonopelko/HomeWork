using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScene : MonoBehaviour
{
    [SerializeField] private string SettingsSceneName;
    [SerializeField] private string[] gameSceneNames;
    [SerializeField] private GameObject CongratulationsScreen;
    [SerializeField] private Text congratulationsText;

    private string lastGame = "";
    private void Start()
    {
        // PlayerPrefs.DeleteAll();
        MusicManager.instance.Swap(MusicManager.MusicType.MainMenuMusic,3);
        if (PlayerPrefs.GetInt("IsNewRecord") > 0)
        {
            congratulationsText.text = "Cool, you have a new record in " + PlayerPrefs.GetString("LastGame") + " game"+"\n\n" +
                                       " "+PlayerPrefs.GetInt(PlayerPrefs.GetString("LastGame") + "BestScore");
            CongratulationsScreen.SetActive(true);
            SoundManager.instance.PlaySound(SoundManager.SoundType.WinSound);
        }

    }

    public void StartGame(int SceneNum)
    {
        ScenesManager.instance.LoadScene(gameSceneNames[SceneNum]);
        PlayerPrefs.SetString("LastGame",gameSceneNames[SceneNum]);
        MusicManager.instance.Swap(MusicManager.MusicType.InGameMusic,3);
    }
    public void ToSettings()
    {
        ScenesManager.instance.LoadScene(SettingsSceneName);
    }

    public void CloseCongratulationsScreen()
    {
        CongratulationsScreen.SetActive(false);
        PlayerPrefs.SetInt("IsNewRecord", 0);
    }
}

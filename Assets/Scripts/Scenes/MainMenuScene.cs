using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    [SerializeField] private string SettingsSceneName;
    [SerializeField] private string[] gameSceneNames;
    private void Start()
    {
        //MusicManager.instance.Swap(MusicManager.MusicType.MainMenuMusic,3);
    }

    public void StartGame(int SceneNum)
    {
        ScenesManager.instance.LoadScene(gameSceneNames[SceneNum]);
        //MusicManager.instance.Swap(MusicManager.MusicType.InGameMusic,3);
    }
    public void ToSettings()
    {
        ScenesManager.instance.LoadScene(SettingsSceneName);
    }
}

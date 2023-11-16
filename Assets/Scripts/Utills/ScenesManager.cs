using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public static ScenesManager instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    async public void LoadScene(string SceneName)
    {
        var loadSceneAsync = SceneManager.LoadSceneAsync(SceneName);
        while (loadSceneAsync.progress < 0.9)
        {
            await Task.Delay(1);
        }
    }


    async public void LoadSceneWithLoadScreen(string SceneName)
    {
        var loadSceneAsync = SceneManager.LoadSceneAsync(SceneName);
        loadSceneAsync.allowSceneActivation = false;
        while (loadSceneAsync.progress < 0.9)
        {
            await Task.Delay(1);
        }
        loadSceneAsync.allowSceneActivation = true;
    }
}

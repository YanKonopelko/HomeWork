using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    
    public AudioClip[] Clips;
    [SerializeField] private AudioSource[] Sources ;

    public float volume { get; private set; }

    private MusicType curMusic;
    public enum MusicType
    {
        MainMenuMusic,
        InGameMusic,
        NULL
    }
    void Awake()
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

        volume = PlayerPrefs.HasKey("MUSIC_VOLUME") ? PlayerPrefs.GetFloat("MUSIC_VOLUME") : 0.5f;

        Init();

    }
    
    
    private void Init()
    {
        Sources = new AudioSource[Clips.Length];
        curMusic = MusicType.NULL;
        for (int i = 0; i < Clips.Length; i++)
        {
            Sources[i] = gameObject.AddComponent<AudioSource>();
            Sources[i].volume = volume;
            Sources[i].clip = Clips[i];
            Sources[i].loop = true;
            Sources[i].playOnAwake = false;
        }
        
    }

    public void ChangeVolume(float _volume)
    {
        volume = _volume;
        foreach (var a in Sources)
        {
            a.volume = volume;
        }
        PlayerPrefs.SetFloat("MUSIC_VOLUME",volume);
        PlayerPrefs.Save();
    }

    async public void Swap(MusicType type, float time)
    {
        if(type == curMusic) return;
        Sources[(int)type].Play();

        if (instance.curMusic != MusicType.NULL)
        {
            float curTime = 0;
            while (curTime < time)
            {
                Sources[(int)instance.curMusic].volume = Mathf.Lerp(volume, 0, curTime / time);
                Sources[(int)type].volume = Mathf.Lerp(0, volume, curTime / time);
                curTime += Time.fixedUnscaledDeltaTime;
                await Task.Delay(1);
            }
            Sources[(int)instance.curMusic].Stop();
        }
        instance.curMusic = type;
    }
    
}

using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    public AudioClip[] Clips;
    [SerializeField] private AudioSource[] Sources ;

    public float volume { get; private set; }

    public enum SoundType
    {
        ButtonSound
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
        
        DontDestroyOnLoad(transform.parent);

        volume = PlayerPrefs.HasKey("VFX_VOLUME") ? PlayerPrefs.GetFloat("VFX_VOLUME") : 0.5f;

        Init();

    }

    public void PlayAtPoint(SoundType type,Vector3 position)
    {
        AudioSource.PlayClipAtPoint(instance.Clips[(int)SoundType.ButtonSound],position);
    }

    public void PlaySound(SoundType type)
    {
        Sources[(int) type].Play();
    }
    private void Init()
    {
        Sources = new AudioSource[Clips.Length];

        for (int i = 0; i < Clips.Length; i++)
        {
            Sources[i] = gameObject.AddComponent<AudioSource>();
            Sources[i].volume = volume;
            Sources[i].clip = Clips[i];
        }
        
    }

    public void ChangeVolume(float _volume)
    {
        volume = _volume;
        foreach (var a in Sources)
        {
            a.volume = volume;
        }
        PlayerPrefs.SetFloat("VFX_VOLUME",volume);
        PlayerPrefs.Save();
    }
}

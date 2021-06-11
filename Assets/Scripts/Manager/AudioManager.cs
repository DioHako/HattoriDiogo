using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance = null;
    public static AudioManager Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    [SerializeField] List<AudioClip> _clip;
    [SerializeField] AudioMixerGroup _audioMixerMaster;
    [SerializeField] AudioMixerGroup _audioMixerBG;
    [SerializeField] AudioMixerGroup _audioMixerAudioFX;

    [HideInInspector]
    public List<AudioSource> _source;

    private void Awake()
    {
        if ( Instance )
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        foreach ( AudioClip s in _clip )
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = s;
            source.outputAudioMixerGroup = _audioMixerBG;
            _source.Add(source);
        }
        Play(0);
    }

    public void Play(int clip)
    {
        _source[clip].Play();
    }

    public void StopMusic()
    {
        foreach ( var s in _source )
        {
            s.Stop();
        }
    }
}

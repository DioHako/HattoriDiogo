using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Button _returnButton;
    [SerializeField] Toggle _muteToggle;

    [Header("Master Volume")]
    [SerializeField] Slider _masterVolumeSlider;
    [SerializeField] AudioMixerGroup _masterAudioMixer;
    private string _masterVolume = "MasterVolume";

    [Header("Music Volume")]
    [SerializeField] Slider _musicVolumeSlider;
    [SerializeField] AudioMixerGroup _musicAudioMixer;
    private string _musicVolume = "BGVolume";

    [Header("SFX Volume")]
    [SerializeField] Slider _sfxVolumeSlider;
    [SerializeField] AudioMixerGroup _sfxAudioMixer;
    [SerializeField] AudioClip _SFXTest;
    private string _sfxVolume = "AudioFXVolume";

    private AudioSource _audiosource;
    private bool _disableMuteToggle;

    private void Awake()
    {
        _audiosource = GetComponent<AudioSource>();

        _masterVolumeSlider.onValueChanged.AddListener(HandleMasterVolume);
        _musicVolumeSlider.onValueChanged.AddListener(HandleMusicVolume);
        _sfxVolumeSlider.onValueChanged.AddListener(HandleSFXVolume);

        _muteToggle.onValueChanged.AddListener(HandleMuteToggle);
    }

    private void HandleMuteToggle(bool enableSound)
    {
        if ( _disableMuteToggle )
            return;

        if ( enableSound )
            _masterVolumeSlider.value = _masterVolumeSlider.maxValue - 20;
        else
            _masterVolumeSlider.value = _masterVolumeSlider.minValue;
    }

    private void HandleMasterVolume(float value)
    {
        _masterAudioMixer.audioMixer.SetFloat(_masterVolume, value);
        _disableMuteToggle = true;
        _muteToggle.isOn = _masterVolumeSlider.value > _masterVolumeSlider.minValue;
        _disableMuteToggle = false;
    }

    private void HandleMusicVolume(float value)
    {
        _musicAudioMixer.audioMixer.SetFloat(_musicVolume, value);
    }

    private void HandleSFXVolume(float value)
    {
        _sfxAudioMixer.audioMixer.SetFloat(_sfxVolume, value);
        _audiosource.PlayOneShot(_SFXTest);
    }

    void Start()
    {
        if ( _returnButton )
        {
            _returnButton.onClick.AddListener(() => OnReturnPressed());
        }
        
    }

    private void OnReturnPressed()
    {
        MenuManager.Instance.OpenMenu(0);
    }
}


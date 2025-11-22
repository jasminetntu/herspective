using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume(float level)
    {
        // math function properly translates how sound works (not linear -> logarithmic)
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20f);
    }

    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20f);
    }

    public void SetBgMusicVolume(float level)
    {
        audioMixer.SetFloat("bgMusicVolume", Mathf.Log10(level) * 20f);
    }
}

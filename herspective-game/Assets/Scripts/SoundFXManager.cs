using UnityEngine;

public class SoundFxManager : MonoBehaviour
{
    public static SoundFxManager instance;
    [SerializeField] private AudioSource soundFXObject;

    public void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip[] audioClips, Transform spawnTransform, float volume)
    {
        // get random index for audio clip
        int randIndex = Random.Range(0, audioClips.Length);

        // spawn game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        // assign audio clip & volume
        audioSource.clip = audioClips[randIndex];
        audioSource.volume = volume;

        // play sound
        audioSource.Play();

        // get length of audio clip & destroy when done
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}

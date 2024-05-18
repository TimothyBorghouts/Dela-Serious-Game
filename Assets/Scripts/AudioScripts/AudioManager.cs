using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public Sound[] sounds;

    public AudioMixerGroup MusicMixerGroup;
    public AudioMixerGroup SFXMixerGroup;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void PlaySound(string name)
    {
        Sound sound = FindSound(name);

        if (!sound.source.isPlaying)
        {
            sound.source.outputAudioMixerGroup = SFXMixerGroup;
            sound.source.Play();
        }
    }

    public void PlayMusic(string name)
    {
        Sound sound = FindSound(name);
        Debug.Log(sound);
        if (!sound.source.isPlaying)
        {
            sound.source.outputAudioMixerGroup = MusicMixerGroup;
            sound.source.Play();
            Debug.Log(sound.volume);
        }
    }

    public void StopAudio(string name)
    {
        Sound sound = FindSound(name);
            
        if (sound.source.isPlaying)
        {
            sound.source.Stop();
        }
    }

    public Sound FindSound(string name)
    {
        Sound sound = System.Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound with name " + name + " not found!");
            return null;
        }
        return sound;
    }
}

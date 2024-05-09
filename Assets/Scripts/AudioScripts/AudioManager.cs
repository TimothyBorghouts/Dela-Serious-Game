using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using static Unity.VisualScripting.Member;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;
    public AudioMixerGroup MusicMixerGroup;
    public AudioMixerGroup SFXMixerGroup;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        PlayMusic("Background Music");
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

        if (!sound.source.isPlaying)
        {
            sound.source.outputAudioMixerGroup = MusicMixerGroup;
            sound.source.Play();
        }
    }

    public void StopAudio(string name)
    {
        Sound sound = FindSound(name);

        sound.source.Stop();
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

using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

    [Range(0f, 3f)]
    public float volume;
    [Range(0f, 3f)]
    public float pitch;
    public bool loop;
}

using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    public List<AudioClip> clips;
    [Range(0, 1)]
    public float volume = 1f;
    [Range(0, 0.2f)]
    public float volumeVariation = 0.05f;
    [Range(0, 2f)]
    public float pitch = 1f;
    [Range(0, 0.2f)]
    public float pitchVariation = 0.05f;

    public void PlaySfx(AudioSource source, bool waitToFinish = true)
    {
        if (!source.isPlaying || !waitToFinish)
        {
            source.clip = GetRandomClip();
            source.volume = this.volume + Random.Range(-volumeVariation, volumeVariation);
            source.pitch = this.pitch + Random.Range(-pitchVariation, pitchVariation);
            source.Play();
        }
    }

    private AudioClip GetRandomClip()
    {
        if (this.clips.Count > 0)
            return this.clips[Random.Range(0, this.clips.Count - 1)];
        else
            return null;
    }
}

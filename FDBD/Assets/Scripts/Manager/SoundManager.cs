using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sound Management")]
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioClip[] bgmClips;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioClip[] sfxClips;

    private Dictionary<string, AudioClip> bgms;
    private Dictionary<string, AudioClip> sfxs;

    void Awake()
    {
        bgms = new Dictionary<string, AudioClip>();
        sfxs = new Dictionary<string, AudioClip>();
    }
    void Start()
    {
        for (int i = 0; i < bgmClips.Length; i++)
        {
            bgms.Add(bgmClips[i].name, bgmClips[i]);
        }

        for (int i = 0; i < sfxClips.Length; i++)
        {
            sfxs.Add(sfxClips[i].name, sfxClips[i]);
        }
    }

    public void PlayBGM(string name)
    {
        bgm.clip = bgms[name];
        bgm.Play();
    }
    public void StopBGM()
    {
        bgm.Stop();
    }
    public void StopSFX()
    {
        sfx.Stop();
    }
    public void PlaySFX(string name)
    {
        sfx.clip = sfxs[name];
        sfx.PlayOneShot(sfx.clip);
    }

    public void SetVolume(float vol)
    {
        bgm.volume = vol;
        sfx.volume = vol;
    }
    public float GetSFXSoundLength(string name)
    {
        return sfxs[name].length;
    }
}

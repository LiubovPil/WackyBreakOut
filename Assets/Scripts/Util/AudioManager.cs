using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class AudioManager
{
    private static bool _initialized = false;
    private static AudioSource _audioSource;
    private static Dictionary<AudioClipName, AudioClip> _audioClips = new Dictionary<AudioClipName, AudioClip>(); 
    public static bool Initialized
    {
        get { return _initialized; }
    }
    public static void Initialize(AudioSource source)
    {
        _initialized = true;
        _audioSource = source;
        _audioClips.Add(AudioClipName.BallLost, Resources.Load<AudioClip>("BallLost"));
        _audioClips.Add(AudioClipName.BallSpawn, Resources.Load<AudioClip>("BallSpawn"));
        _audioClips.Add(AudioClipName.GameLost, Resources.Load<AudioClip>("GameLost"));
        _audioClips.Add(AudioClipName.MenuButtonClick, Resources.Load<AudioClip>("MenuButtonClick"));
    }
    public static void Playing(AudioClipName name)
    {
        _audioSource.PlayOneShot(_audioClips[name]);
    }
}

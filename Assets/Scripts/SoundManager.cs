using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum AudioClips
    {
        Death,
        Flip,
        Jump,
        Music
    }
    [SerializeField] private List<AudioClip> _clips = new List<AudioClip>();
    public Dictionary<AudioClips, AudioClip> AudioDictionary = new Dictionary<AudioClips, AudioClip>();
    private void Awake()
    {
        foreach (AudioClips clipType in System.Enum.GetValues(typeof(AudioClips)))
        {
            int index = (int)clipType;

            if (index < _clips.Count && _clips[index] != null)
                AudioDictionary.Add(clipType, _clips[index]);
            else
                Debug.LogError($"Missing AudioClip for {clipType} at index {index}");
        }
    }
}

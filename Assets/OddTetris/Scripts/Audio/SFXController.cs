using System;
using System.Collections.Generic;
using UnityEngine;

namespace OddTetris.Audio
{
    public enum AudioIdentifier
    {
        Movement,
        Grounded,
        Killed,
        Clicked
    }

    [System.Serializable]
    public struct AudioItem
    {
        public AudioIdentifier AudioIdentifier;
        public AudioClip Clip;
    }
    
    public class SFXController : SingletonMonoBehavior<SFXController>
    {
        [SerializeField] private AudioSource m_BGM;
        [SerializeField] private AudioSource m_Sfx;

        [Space] [SerializeField] private List<AudioItem> m_AudioItems = new List<AudioItem>();
        private Dictionary<AudioIdentifier, AudioClip> m_AudioLibrary = new Dictionary<AudioIdentifier, AudioClip>();

        private void Start()
        {
            foreach (AudioItem audioItem in m_AudioItems)
            {
                m_AudioLibrary.Add(audioItem.AudioIdentifier, audioItem.Clip);
            }
        }

        public void PlaySfx(AudioIdentifier audioIdentifier)
        {
            if (m_AudioLibrary.TryGetValue(audioIdentifier, out AudioClip clip))
            {
                m_Sfx.PlayOneShot(clip);
            }
            else
            {
                Debug.LogError($"Audio {audioIdentifier} not found");
            }
        }
    }   
}

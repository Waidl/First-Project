using System;
using UnityEngine;

namespace AudioManager
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }
        
        public Sound[] sounds;
        
        public void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            
            Initialize();
        }

        private void Start()
        {
            //AudioManager.AudioManager.Instance.Play(GameConfig.MenuSound);
        }

        private void Initialize()
        {
            foreach (var s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
            }
        }

        public void Play(string clipName)
        {
            Sound s = Array.Find(sounds, sound => sound.name == clipName);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + clipName + " not found!");
                return;
            }
            s.source.Play();

        }
    }
}
    
        

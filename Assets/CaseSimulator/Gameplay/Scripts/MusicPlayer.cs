using CaseSimulator.Gameplay.CaseSystem;
using Plugins.Audio.Core;
using UnityEngine;

namespace CaseSimulator.Gameplay
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private string _musicName;
        private SourceAudio _sourceAudio;

        private void OnEnable()
        {
            Adv.OnAdShowed += StopMusic;
            Adv.OnAdFinished += ResumeMusic;
            Case.OnAdOpened += StopMusic;
            Case.OnAdClosed += ResumeMusic;
        }

        private void OnDisable()
        {
            Adv.OnAdShowed -= StopMusic;
            Adv.OnAdFinished -= ResumeMusic;
            Case.OnAdOpened -= StopMusic;
            Case.OnAdClosed -= ResumeMusic;
        }

        private void Awake()
        {
            _sourceAudio = GetComponent<SourceAudio>();
            if (Application.isEditor)
            {
                print("Music Started");
                _sourceAudio.Play(_musicName);
            }
        }

        private void StopMusic()
        {
            print("Music Stopped");
            _sourceAudio.Stop();
        }

        private void ResumeMusic()
        {
            print("Music Resumed");
            _sourceAudio.Play(_musicName);
        }
    }
}
using Plugins.Audio.Core;
using UnityEngine;

namespace CaseSimulator.Gameplay
{
    [RequireComponent(typeof(SourceAudio))]
    public class SoundPlayer : MonoBehaviour
    {
        private static SourceAudio _sourceAudio;

        private void Awake()
        {
            _sourceAudio = GetComponent<SourceAudio>();
        }

        public static void PlayAudio(string soundTag)
        {
            _sourceAudio.Play(soundTag);
        }
    }
}
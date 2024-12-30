using Plugins.Audio.Core;
using UnityEngine;

[RequireComponent(typeof(SourceAudio))]
public class BackgroundMusicPlayer : MonoBehaviour
{
    [SerializeField] private string _musicName;
    private SourceAudio _sourceAudio;

    private void Awake()
    {
        _sourceAudio = GetComponent<SourceAudio>();
        _sourceAudio.Play(_musicName);
    }
}

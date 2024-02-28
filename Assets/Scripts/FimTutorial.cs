using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Adiciona um listener para o evento de loop do vídeo
        videoPlayer.loopPointReached += OnLoopReached;
    }

    void OnLoopReached(VideoPlayer vp)
    {
        // Para a reprodução do vídeo quando o loop for alcançado
        videoPlayer.Stop();
    }
}

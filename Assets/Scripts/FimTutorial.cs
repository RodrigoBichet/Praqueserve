using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button buttonStart;
    public Button buttonBack;
    public GameObject title;
    public GameObject whiteSquare;

    private bool isPlaying;

    void Start()
    {
        videoPlayer.loopPointReached += OnLoopReached;
        whiteSquare.SetActive(false);
        // Garante que os elementos estejam ativados no início
        buttonStart.gameObject.SetActive(true);
        buttonBack.gameObject.SetActive(true);
        title.SetActive(true);
        whiteSquare.SetActive(true);
    }

    void Update()
    {
        // Verifica se o vídeo está tocando
        isPlaying = videoPlayer.isPlaying;

        // Desativa os botões, o título e o White Square se o vídeo estiver tocando
        buttonStart.gameObject.SetActive(!isPlaying);
        buttonBack.gameObject.SetActive(!isPlaying);
        title.SetActive(!isPlaying);
        whiteSquare.SetActive(!isPlaying);
    }

    void OnLoopReached(VideoPlayer vp)
    {
        // Para a reprodução do vídeo quando o loop for alcançado
        videoPlayer.Stop();

        // Ativa os elementos quando o vídeo terminar
        buttonStart.gameObject.SetActive(true);
        buttonBack.gameObject.SetActive(true);
        title.SetActive(true);
        whiteSquare.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ButtonTutorial : MonoBehaviour
{
    public Button botao;
    public VideoPlayer videoPlayer;
    public GameObject screenObject;
    public GameObject whiteSquareVideo;
    public GameObject blackSquareVideo;
    public GameObject buttonBackVideo;


    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.gameObject.SetActive(false);
        screenObject.SetActive(false);
        whiteSquareVideo.gameObject.SetActive(false);
        blackSquareVideo.gameObject.SetActive(false);
        buttonBackVideo.gameObject.SetActive(false);

        botao.onClick.AddListener(AtivarVideoPlayer);
    }

    void AtivarVideoPlayer()
    {
        videoPlayer.gameObject.SetActive(true);
        screenObject.SetActive(true);
        whiteSquareVideo.SetActive(true);
        blackSquareVideo.SetActive(true);
        buttonBackVideo.SetActive(true);

        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Desativa os elementos quando o vídeo termina
        videoPlayer.gameObject.SetActive(false);
        screenObject.SetActive(false);
        whiteSquareVideo.SetActive(false);
        blackSquareVideo.SetActive(false);
        buttonBackVideo.SetActive(false);

    }
}

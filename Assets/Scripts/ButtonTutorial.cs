using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ButtonTutorial : MonoBehaviour
{
    public Button botao;
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Desativa o VideoPlayer no início
        videoPlayer.enabled = false;

        // Adiciona um listener para o botão
        botao.onClick.AddListener(AtivarVideoPlayer);
    }

    void AtivarVideoPlayer()
    {
        // Ativa o VideoPlayer quando o botão é clicado
        videoPlayer.enabled = true;

        // Reproduz o vídeo
        videoPlayer.Play();
    }
}
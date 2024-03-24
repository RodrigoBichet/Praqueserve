// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;

// public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
// {
//     private RectTransform rt;
//     private CanvasGroup grupo;
//     private Vector2 posicaooriginal;
//     private bool estaArrastando = false; // Variável para controlar se um item está sendo arrastado
//     private static bool outroItemArrastando = false; // Variável estática para verificar se outro item está sendo arrastado

//     //!variável estática de controle de drag com sucesso
//     public static bool coloucerto;
//     public Sprite[] imagens; // Se for usar um array
//     public Image imageComponent; // Referência ao componente Image no Inspector
//     private AudioSource sound;

//     [SerializeField] private Canvas canvas; //parecido com 'set'

//     private void Awake()
//     {
//         //!usar o objeto para mover pela tela
//         rt = GetComponent<RectTransform>();
//         grupo = GetComponent<CanvasGroup>();
//         //!posicao original do objeto
//         posicaooriginal = rt.anchoredPosition;
//         coloucerto = false;
//         sound = GetComponent<AudioSource>();
//     }

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         if (!estaArrastando && !outroItemArrastando && !coloucerto) // Verifica se nenhum item está sendo arrastado e nenhum item foi acertado
//         {
//             estaArrastando = true;
//             outroItemArrastando = true;
//             //!transparencia
//             grupo.alpha = 0.5f;
//             //!habilitar a colisão
//             grupo.blocksRaycasts = false;
//             sound.Play();
//         }
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         //!arrastando o obj
//         // Verificar se está arrastando antes de atualizar a posição
//         if (estaArrastando)
//         {
//             rt.anchoredPosition += eventData.delta / canvas.scaleFactor;
//             Debug.Log("Dragou");
//         }
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         estaArrastando = false; // Indica que o arrasto do item terminou
//         outroItemArrastando = false; // Indica que nenhum item está sendo arrastado
//         //!acaba de arrastar
//         //!transparencia
//         grupo.alpha = 1f;
//         //!desabilitar a colisão
//         grupo.blocksRaycasts = true;
//         if (coloucerto == false)
//         {
//             rt.anchoredPosition = posicaooriginal;
//         }
//         else
//         {
//             //Debug.Log("Else Coloucerto DICRIA: " + coloucerto);
//         }
//         //coloucerto = false;
//         //Debug.Log("Coloucerto DICRIA: " + coloucerto);
//     }

//     public void OnPointerDown(PointerEventData eventData)
//     {
//         //!primeiro somente click
//         //Debug.Log("Pointer");
//     }
// }

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rt;
    private CanvasGroup grupo;
    private Vector2 posicaooriginal;
    private bool estaArrastando = false; // Variável para controlar se um item está sendo arrastado
    private static bool outroItemArrastando = false; // Variável estática para verificar se outro item está sendo arrastado

    //!variável estática de controle de drag com sucesso
    public static bool coloucerto;
    public Sprite[] imagens; // Se for usar um array
    public Image imageComponent; // Referência ao componente Image no Inspector
    private AudioSource sound;
    private string nomeItem; // Variável para armazenar o nome do item arrastado

    [SerializeField] private Canvas canvas; //parecido com 'set'

    // Adicionando referência ao componente de texto para exibir legendas
    public TMP_Text legendaText; // Alteração aqui para usar TextMeshPro
    public string[] listaLegendas; // Lista de legendas correspondentes aos itens arrastáveis

    private void Awake()
    {
        //!usar o objeto para mover pela tela
        rt = GetComponent<RectTransform>();
        grupo = GetComponent<CanvasGroup>();
        //!posicao original do objeto
        posicaooriginal = rt.anchoredPosition;
        coloucerto = false;
        sound = GetComponent<AudioSource>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!estaArrastando && !outroItemArrastando && !coloucerto)
        {
            // Captura o nome do item ao iniciar o arraste
            nomeItem = this.gameObject.name;

            estaArrastando = true;
            outroItemArrastando = true;
            grupo.alpha = 0.5f;
            grupo.blocksRaycasts = false;
            sound.Play();

            // Atualiza a legenda ao iniciar o arraste, passando o nome do item
            AtualizarLegenda(nomeItem);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //!arrastando o obj
        // Verificar se está arrastando antes de atualizar a posição
        if (estaArrastando)
        {
            rt.anchoredPosition += eventData.delta / canvas.scaleFactor;
            Debug.Log("Dragou");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        estaArrastando = false; // Indica que o arrasto do item terminou
        outroItemArrastando = false; // Indica que nenhum item está sendo arrastado
        //!acaba de arrastar
        //!transparencia
        grupo.alpha = 1f;
        //!desabilitar a colisão
        grupo.blocksRaycasts = true;
        if (coloucerto == false)
        {
            rt.anchoredPosition = posicaooriginal;

            // Atualiza a legenda ao cancelar o arraste
            AtualizarLegenda(nomeItem);
        }
        else
        {
            // Atualiza a legenda ao arrastar com sucesso
            AtualizarLegenda(nomeItem);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //!primeiro somente click
        //Debug.Log("Pointer");
    }

    private void AtualizarLegenda(string nomeItem)
    {
        // Verifica se o nome do item está na lista de imagens e atualiza a legenda
        int index = System.Array.IndexOf(imagens, imageComponent.sprite);
        if (index != -1 && index < listaLegendas.Length)
        {
            legendaText.text = listaLegendas[index];
        }
        else
        {
            Debug.LogError("Legenda não encontrada para o item: " + nomeItem);
        }
    }
}




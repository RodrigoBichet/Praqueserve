using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    [SerializeField] private Canvas canvas; //parecido com 'set'

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
        if (!estaArrastando && !outroItemArrastando && !coloucerto) // Verifica se nenhum item está sendo arrastado e nenhum item foi acertado
        {
            estaArrastando = true;
            outroItemArrastando = true;
            //!transparencia
            grupo.alpha = 0.5f;
            //!habilitar a colisão
            grupo.blocksRaycasts = false;
            sound.Play();
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
        }
        else
        {
            //Debug.Log("Else Coloucerto DICRIA: " + coloucerto);
        }
        //coloucerto = false;
        //Debug.Log("Coloucerto DICRIA: " + coloucerto);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //!primeiro somente click
        //Debug.Log("Pointer");
    }
}

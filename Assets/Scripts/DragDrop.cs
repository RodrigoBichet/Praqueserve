using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rt;

    private CanvasGroup grupo;

    private Vector2 posicaooriginal;

    //!variável estática de controle de drag com sucesso
    public static bool coloucerto;

    private void Awake()
    {
        //!usar o objeto para mover pela tela
        rt = GetComponent<RectTransform>();

        grupo = GetComponent<CanvasGroup>();

        //!posicao original do objeto
        posicaooriginal = rt.anchoredPosition;

        coloucerto = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();

        //começa o arrasto
        //Debug.Log("Begin Drag");

        //!transparencia
        grupo.alpha = 0.5f;

        //!habilitar a colisão
        grupo.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();

        //!arrastando o obj
        //Debug.Log("On Drag");

        //!seta a posicao do obj para a posicao do mouse
        rt.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();

        //!acaba de arrastar
        //Debug.Log("End Drag");

        //!transparencia
        grupo.alpha = 1f;

        //!desabilitar a colisão
        grupo.blocksRaycasts = true;

        if (coloucerto == false)
        {
            rt.anchoredPosition = posicaooriginal;
        }
        //coloucerto = false;
        Debug.Log("Coloucerto DICRIA: " + coloucerto);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();

        //!primeiro somente click
        //Debug.Log("Pointer");

    }


}

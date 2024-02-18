using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuClassHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject ClassDescriptionBox;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ClassDescriptionBox.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ClassDescriptionBox.SetActive(false);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCustomisationMenu : MonoBehaviour
{
    [SerializeField] List<SuperTuple<HAIR, Sprite>> hairSprite;
    [SerializeField] List<SuperTuple<HEAD, Sprite>> headSprite;
    [SerializeField] List<SuperTuple<FACE, Sprite>> faceSprite;
    [SerializeField] List<SuperTuple<MOUTH, Sprite>> mouthSprite;

    [SerializeField] Image hairImage, headImage, faceImage, mouthImage;
    [SerializeField] TextMeshProUGUI hairTitle, headTitle, faceTitle, mouthTitle;
    public static CharacterCustomisationMenu instance;
    private void Start()
    {
        instance = this;
        UpdateScreen();
    }
    public enum HAIR {
        SPIKY,
        STYLED,
        SLICK

    }

    public enum HEAD { 
        LARGE,
        MEDIUM,
        SMALL
    }
    public enum FACE
    {
        LARGE,
        MEDIUM,
        SMALL
    }
    public enum MOUTH
    {
        LARGE,
        MEDIUM,
        SMALL
    }
    public static HAIR SelectedHair;
    public static HEAD SelectedHead;
    public static FACE SelectedFace;
    public static MOUTH SelectedMouth;

    public void NextHair()
    {
        SelectedHair = (HAIR)(((int)SelectedHair + 1) % Enum.GetValues(typeof(HAIR)).Length);
        UpdateScreen();
    }

    public void PreviousHair()
    {
        int totalHairOptions = Enum.GetValues(typeof(HAIR)).Length;
        SelectedHair = (HAIR)(((int)SelectedHair - 1 + totalHairOptions) % totalHairOptions);
        UpdateScreen();
    }
    public void NextHead()
    {
        SelectedHead = (HEAD)(((int)SelectedHead + 1) % Enum.GetValues(typeof(HEAD)).Length);
        UpdateScreen();
    }

    public void PreviousHead()
    {
        int totalHeadOptions = Enum.GetValues(typeof(HEAD)).Length;
        SelectedHead = (HEAD)(((int)SelectedHead - 1 + totalHeadOptions) % totalHeadOptions);
        UpdateScreen();
    }
    public void NextFace()
    {
        SelectedFace = (FACE)(((int)SelectedFace + 1) % Enum.GetValues(typeof(FACE)).Length);
        UpdateScreen();
    }

    public void PreviousFace()
    {
        int totalFaceOptions = Enum.GetValues(typeof(FACE)).Length;
        SelectedFace = (FACE)(((int)SelectedFace - 1 + totalFaceOptions) % totalFaceOptions);
        UpdateScreen();
    }

    public void NextMouth()
    {
        SelectedMouth = (MOUTH)(((int)SelectedMouth + 1) % Enum.GetValues(typeof(MOUTH)).Length);
        UpdateScreen();
    }

    public void PreviousMouth()
    {
        int totalMouthOptions = Enum.GetValues(typeof(MOUTH)).Length;
        SelectedMouth = (MOUTH)(((int)SelectedMouth - 1 + totalMouthOptions) % totalMouthOptions);
        UpdateScreen();
    }
    public void UpdateScreen()
    {
        foreach(var sprite in hairSprite)
            if(sprite.Item1 == SelectedHair)
            {
                hairImage.sprite = sprite.Item2;
                hairTitle.text = sprite.Item1.ToString();
                break;
            }
        foreach (var sprite in headSprite)
            if (sprite.Item1 == SelectedHead)
            {
                headImage.sprite = sprite.Item2;
                headTitle.text = sprite.Item1.ToString();
                break;
            }
        foreach (var sprite in faceSprite)
            if (sprite.Item1 == SelectedFace)
            {
                faceImage.sprite = sprite.Item2;
                faceTitle.text = sprite.Item1.ToString();
                break;
            }
        foreach (var sprite in mouthSprite)
            if (sprite.Item1 == SelectedMouth)
            {
                mouthImage.sprite = sprite.Item2;
                mouthTitle.text = sprite.Item1.ToString();
                break;
            }
    }

}
[Serializable]
public class SuperTuple<T1, T2>
{
    [SerializeField]
    private T1 item1;
 
    [SerializeField]
    private T2 item2;
 
    public T1 Item1 => item1;
    public T2 Item2 => item2;
 
    public SuperTuple(T1 item1, T2 item2)
    {
        this.item1 = item1;
        this.item2 = item2;
    }
 
}
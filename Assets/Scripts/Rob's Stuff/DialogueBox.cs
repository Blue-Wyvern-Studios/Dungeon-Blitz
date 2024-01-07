using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    public string[] _dialogueLines;
    private int _lineIndex;

    private TMP_Text _text;
    private CanvasGroup _group;

    public GameObject dialogueButton;

    public CursorManager accessToCursorManager;
    private Texture2D defaultCursorTexture;
    private Vector2 _cursorHotSpot;

    void Start()
    {
        defaultCursorTexture = accessToCursorManager.cursorDefaultTexture;

        _text = GetComponent<TMP_Text>();
        _group = GetComponent<CanvasGroup>();
        _group.alpha = 0;

        StartCoroutine(Type());
    }

    void Update()
    {
        //when all the text is in the box re-enable the dialogue button
        if (_text.text == _dialogueLines[_lineIndex])
        {
            dialogueButton.SetActive(true);
        }
    }

    public IEnumerator Type()
    {
        //add letters to dialogue
        foreach (char letter in _dialogueLines[_lineIndex].ToCharArray())
        {
            _text.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void NextDialogueLine()
    {
        //disable dialogue button after pressing it so it doesn't get fucked up
        dialogueButton.SetActive(false);

        //going to next dialogue line if there are dialogue lines left
        if (_lineIndex < _dialogueLines.Length - 1)
        {
            _lineIndex++;
            _text.text = "";
            _group.alpha = 1;
            StartCoroutine(Type());
        }
        //if there are no more dialogue lines make it invisible and disable the dialugue button
        else
        {
            _text.text = "";
            _group.alpha = 0;
            
            //changing cursor texture
            _cursorHotSpot = new Vector2(defaultCursorTexture.width / 2, defaultCursorTexture.height / 2);
            Cursor.SetCursor(defaultCursorTexture, _cursorHotSpot, CursorMode.Auto);
            accessToCursorManager.cursorIsDialogueTextured = false;

            dialogueButton.SetActive(false);
        }
    }
}

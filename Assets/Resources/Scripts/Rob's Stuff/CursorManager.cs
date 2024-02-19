using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    [SerializeField] public Texture2D cursorDefaultTexture;
    [SerializeField] public Texture2D cursorOnDialogueTexture;
    public bool cursorIsDialogueTextured = false;
    [SerializeField] public Texture2D cursorMeleeTexture;
    public bool cursorIsMeleeTextured = false;
  public bool cursordoor = false;
  public bool dialogbool = false;
    private Vector2 cursorHotSpot;

    public GameObject player;
    public Vector3 playerPosition;

    public Vector3 screenPosition;
    public Vector3 worldPosition;

    void Start()
    {
        //finding player

        player = GameObject.FindGameObjectWithTag("Player");

        cursorHotSpot = new Vector2(cursorDefaultTexture.width / 2, cursorDefaultTexture.height / 2);
        Cursor.SetCursor(cursorDefaultTexture, cursorHotSpot, CursorMode.Auto);
    }

  void Update()
  {
    //keeping the same z position
    screenPosition = Input.mousePosition;
    screenPosition.z = Camera.main.nearClipPlane + 1;

    worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

    playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

    //setting melee cursor
    if (cursordoor)
    {
      Texture2D doortexture = Resources.Load<Texture2D>("UI/Cursors/doorcursor");
      Cursor.SetCursor(doortexture, cursorHotSpot, CursorMode.Auto);
      cursorHotSpot = new Vector2(doortexture.width / 2, doortexture.height / 2);
    }
    else if (dialogbool)
    {
      Texture2D doortexture = Resources.Load<Texture2D>("UI/Cursors/Dialogue");
      Cursor.SetCursor(doortexture, cursorHotSpot, CursorMode.Auto);
      cursorHotSpot = new Vector2(doortexture.width / 2, doortexture.height / 2);
    }
    else
    {
      if (Vector3.Distance(worldPosition, playerPosition) < 2 && !cursorIsDialogueTextured)
      {
        cursorIsMeleeTextured = true;
        Cursor.SetCursor(cursorMeleeTexture, cursorHotSpot, CursorMode.Auto);
        cursorHotSpot = new Vector2(cursorMeleeTexture.width / 2, cursorMeleeTexture.height / 2);
      }
      //setting ranged cursor
      else if (Vector3.Distance(worldPosition, playerPosition) > 2 && !cursorIsDialogueTextured)
      {
        cursorIsMeleeTextured = false;
        cursorHotSpot = new Vector2(cursorDefaultTexture.width / 2, cursorDefaultTexture.height / 2);
        Cursor.SetCursor(cursorDefaultTexture, cursorHotSpot, CursorMode.Auto);
      }
    }
  }

    public void OnDialogueZoneEnter()
    {
        //activating dialogue cursor 
        cursorIsDialogueTextured = true;
        cursorHotSpot = new Vector2(cursorOnDialogueTexture.width / 2, cursorOnDialogueTexture.height / 2);
        Cursor.SetCursor(cursorOnDialogueTexture, cursorHotSpot, CursorMode.Auto);
    }

    public void OnDialogueZoneExit()
    {
        //deactivating dialogue cursor
        cursorIsDialogueTextured = false;
        cursorHotSpot = new Vector2(cursorDefaultTexture.width / 2, cursorDefaultTexture.height / 2);
        Cursor.SetCursor(cursorDefaultTexture, cursorHotSpot, CursorMode.Auto);
    }
}

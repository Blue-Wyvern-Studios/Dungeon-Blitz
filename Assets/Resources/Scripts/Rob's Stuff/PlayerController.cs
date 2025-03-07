using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 6f;
    private float jumpingPower = 12f;

    private bool isJumping;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public PlayerOneWayPlatform playerOneWayPlatform;

    public Animator anim;

    private SpriteRenderer playerSprite;

    [SerializeField] private Inventory_UI uiInventory;

    private InventoryScript inventory;

  private void Start()
  {
    inventory = new InventoryScript();
    uiInventory.SetInventory(inventory);

    anim = GetComponent<Animator>();
    playerSprite = GetComponent<SpriteRenderer>();
    // Just testing the item spawning
    ItemWorld.SpawnItemWorld(new Vector3(-209, -96), new InventoryItem { itemType = InventoryItem.ItemType.Skull, amount = 1 });
    ItemWorld.SpawnItemWorld(new Vector3(-210, -92), new InventoryItem { itemType = InventoryItem.ItemType.Bone, amount = 1 });
    ItemWorld.SpawnItemWorld(new Vector3(-211, -100), new InventoryItem { itemType = InventoryItem.ItemType.Undead_Wisp, amount = 1 });
  }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            //Touching item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    private void Update()
    {
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        //jump buffer
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        //coyote timer
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }

        //jump
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
    }

    private void FixedUpdate()
    {
        //translating the input
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        //for animations
        if (rb.velocity.x >= 1)
        {
            anim.SetBool("isRunningLeft", false);
            anim.SetBool("isRunningRight", true);
        }
        else if (rb.velocity.x <= -1)
        {
            anim.SetBool("isRunningRight", false);
            anim.SetBool("isRunningLeft", true);
        }
        else
        {
            anim.SetBool("isRunningLeft", false);
            anim.SetBool("isRunningRight", false);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
  private void OnCollisionEnter2D(Collision2D collision)
  {
    
  }
}
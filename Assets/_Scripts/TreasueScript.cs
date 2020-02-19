using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasueScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    public float force = 80.0f;

    [SerializeField] private Sprite newSprite;

    [SerializeField] private bool treasureIsOpen = false;

    [SerializeField] private GameObject star;

    private Rigidbody2D _starBody2D;

    // Start is called before the first frame update
    void Start()
    {
        _starBody2D = star.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (treasureIsOpen)
        {
            Instantiate(star, gameObject.transform.position, Quaternion.identity);
            _starBody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            sprite.sprite = newSprite;
            treasureIsOpen = true;
        }
    }
}

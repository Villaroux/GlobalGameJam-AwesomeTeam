using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSystem : MonoBehaviour
{

    //public Transform placeFrom; //Where we hit the TP/Stairs/Holes
    public Transform placeTo; //Where we go to

    private BoxCollider2D coll; //Collider of TP/Stairs/Hole

    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Here!");

        HyperTag tag = collision.gameObject.GetComponent<HyperTag>();

        if (tag == null) return;

        if(tag.GetTag() == HyperTag.Tag.Player)
        {
            MoveTo move = collision.gameObject.GetComponent<MoveTo>();
            move.TPTo(placeTo);
        }
    }
}

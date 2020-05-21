using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBattle : MonoBehaviour
{
    public GameObject battle;
    public Camera mainCamera;

    public BattleSystemFossil battleSystemFossil;

    public Animator anim;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WorldEnemy"))
        {
            StartCoroutine(BattleSetup());

            Destroy(collision.gameObject); //Destroys the world enemy
        }


    }

    public IEnumerator BattleSetup()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        anim.enabled = true;// Fades the battle in

        anim.SetBool("FadeOut", true);

        yield return new WaitForSeconds(1f);

        battle.SetActive(true); //Enables the battle game object

        mainCamera.orthographicSize = 6f; //Sets camera size to 6 for a zoomed in battle

        battleSystemFossil.BattleStart(); //Runs the startup for the battle

        gameObject.GetComponent<SpriteRenderer>().enabled = false; // sets world player sprite renderer to inactive

        yield return new WaitForSeconds(1f);

        anim.SetBool("FadeOut", false);

        anim.enabled = false;// turns the anim off

    }

}

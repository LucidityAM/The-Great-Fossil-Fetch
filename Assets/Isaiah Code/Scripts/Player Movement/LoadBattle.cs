using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBattle : MonoBehaviour
{
    public GameObject battle;
    public Camera mainCamera;

    public BattleSystemFossil battleSystemFossil;

    public Animator anim;
    public GameObject sceneTransition;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WorldEnemy") || collision.gameObject.CompareTag("Boss1") || collision.gameObject.CompareTag("Boss2") || collision.gameObject.CompareTag("Boss3"))
        {
            StartCoroutine(BattleSetup());

            Destroy(collision.gameObject); //Destroys the world enemy
        }


    }

    public IEnumerator BattleSetup()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        anim.enabled = true;// Fades the battle in
        sceneTransition.SetActive(true);

        anim.SetBool("FadeOut", true);

        yield return new WaitForSeconds(1f);

        battle.SetActive(true); //Enables the battle game object

        mainCamera.orthographicSize = 6f; //Sets camera size to 6 for a zoomed in battle

        battleSystemFossil.BattleStart(); //Runs the startup for the battle

        gameObject.GetComponent<SpriteRenderer>().enabled = false; // sets world player sprite renderer to inactive

        yield return new WaitForSeconds(1f);

        anim.SetBool("FadeOut", false);

        anim.enabled = false;// turns the anim off
        sceneTransition.SetActive(false);

    }

    public IEnumerator EndBattleTransition()
    {
        anim.enabled = true;
        sceneTransition.SetActive(true);

        anim.SetBool("FadeOut", true);

        yield return new WaitForSeconds(2f);

        anim.SetBool("FadeOut", false);

        anim.enabled = false;
        sceneTransition.SetActive(false);
    }


}

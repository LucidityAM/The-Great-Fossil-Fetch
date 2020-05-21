using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource overWorld;
    public AudioSource normalBattle;
    public AudioSource bossBattle;
    // Start is called before the first frame update
    void Start()
    {
        //reseting all bools
        MusicManager.overWorldMusic = false;
        MusicManager.normalBattleMusic = false;
        MusicManager.bossBattleMusic = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks what bool is true, and plays audio accordingly
        if (MusicManager.normalBattleMusic == true)
        {
            overWorld.time = 0f;
            bossBattle.time = 0f;
            normalBattle.UnPause();
            overWorld.Pause();
            bossBattle.Pause();

        } else if (MusicManager.bossBattleMusic == true)
        {
            normalBattle.time = 0f;
            overWorld.time = 0f;
            bossBattle.UnPause();
            overWorld.Pause();
            normalBattle.Pause();
        }
        else
        {
            normalBattle.time = 0f;
            bossBattle.time = 0f;
            overWorld.UnPause();
            normalBattle.Pause();
            bossBattle.Pause();
        }
    }
}

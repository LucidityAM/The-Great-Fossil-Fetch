using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyToBeAttacked : MonoBehaviour
{
    public BattleSystemFossil battleSystemFossil;

    // Start is called before the first frame update
    void Start()
    {
        battleSystemFossil = GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystemFossil>();

        Button btn = this.GetComponent<Button>();

        btn.onClick.AddListener(delegate { battleSystemFossil.EnemySelect(this.gameObject); });

    }// Grabs the BattleSystem script and assigns it to the empty variable battleSystemFossil
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;

    public float roatationMultipler = 15;

    public GameObject shake;

    public void Update()
    {
        if(EnemyHolder.shakeEnemy == true)
        {
            float xAmount = Random.Range(-0.1f, 0.1f) * shakePower;
            float yAmount = Random.Range(-0.1f, 0.1f) * shakePower;

            shake.transform.position += new Vector3(xAmount, yAmount, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * roatationMultipler * Time.deltaTime);
        }
        

    }


}
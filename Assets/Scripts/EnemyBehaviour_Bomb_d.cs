using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour_Bomb_d : MonoBehaviour
{
    public GameObject player;
    public GameObject bomb;
    public GameObject boomEffect;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BoomEffect", 2f);
        Invoke("Boom", 2.5f);
    }

    public void BoomEffect()
    {
        bomb.SetActive(false);
        boomEffect.SetActive(true);
        Debug.Log("Boom!");
        if (Vector3.Distance(transform.position, player.transform.position) < 2f)
        {
            Debug.Log("PlayerHit!");
        }
    }

    public void Boom()
    {
        Destroy(gameObject);
    }
}

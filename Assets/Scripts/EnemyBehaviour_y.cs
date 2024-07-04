using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour_y : MonoBehaviour
{

    public GameObject player;
    public GameObject bomb_d;

    private float time_to_throw = -1f;

    // Start is called before the first frame update
    void Start()
    {
        time_to_throw = Random.Range(2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        time_to_throw -= Time.deltaTime;
        if (time_to_throw < 0)
        {
            ThrowBomb();
            time_to_throw = Random.Range(4f, 10f);
        }
    }

    private void ThrowBomb()
    {
        int coeff = player.transform.position.x > transform.position.x ? 1 : -1;
        GameObject new_bomb = Instantiate(bomb_d, position: transform.position + new Vector3(coeff * 0.5f, 0f, 0f), rotation: Quaternion.identity, parent: transform);
        new_bomb.SetActive(true);
        new_bomb.GetComponent<Rigidbody2D>().velocity = new Vector2(coeff * 4f, 4f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            player.Hp += 10;
            if(player.Hp >player.MaxHp)
            {
                player.Hp = player.MaxHp;
            }
            Destroy(gameObject);
        }
    }
}

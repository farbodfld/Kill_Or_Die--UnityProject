using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]

public class SpeedBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().moveSpeed += amount;
        target.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.1f,1f),Random.Range(0.1f,1f),Random.Range(0.1f,1f));
    }
}

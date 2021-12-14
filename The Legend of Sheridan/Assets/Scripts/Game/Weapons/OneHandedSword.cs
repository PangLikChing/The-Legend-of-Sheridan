using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHandedSword : MonoBehaviour
{
    void setIsAttackingToFalse()
    {
        transform.parent.GetComponent<Attack>().isAttacking = false;
    }

    void setIsAttackingToTrue()
    {
        transform.parent.GetComponent<Attack>().isAttacking = true;
    }
}

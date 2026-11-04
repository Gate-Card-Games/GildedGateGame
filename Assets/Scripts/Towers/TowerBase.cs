using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    int attack;

    int attackSpeed;

    int range;

    private void setAttack(int newAttack)
    {
        attack = newAttack;
    }

    private void setAttackSpeed(int newAttackSpeed)
    {
        int attackSpeed = newAttackSpeed;
    }

    private void setRange(int newRange)
    {
        range = newRange;
    }

    public abstract void Attack();
}

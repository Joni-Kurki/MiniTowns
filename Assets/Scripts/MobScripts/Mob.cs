using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob{

    const int MAX_HP = 10;

    public int _hp { get; set; }
    public int _damage { get; set; }
    public float _range { get; set; }

    public Mob(int hp, int damage, float range) {
        _hp = hp;
        _damage = damage;
        _range = range;
    }
    public int GetMaxHP() {
        return MAX_HP;
    }
}

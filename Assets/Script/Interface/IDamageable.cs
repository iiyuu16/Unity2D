using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IDamageable
{

    public int Health { get; set; }
    public bool Targetable { set; get; }
    public void OnHit(int damage);

    public void OnObjectDestroyed();
}

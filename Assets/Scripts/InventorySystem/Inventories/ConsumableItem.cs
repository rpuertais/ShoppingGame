using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConsumableItem : ItemData
{
    public abstract void Use(IConsume consumer);
}

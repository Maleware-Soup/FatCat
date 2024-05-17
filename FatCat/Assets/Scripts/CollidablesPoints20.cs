using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidablesPoints20 : Colidables
{
    protected override void OnTouch(Hud h)
    {
        Destroy(this.gameObject);
        h.scoreAddon += 20;
        h.PointAddOn();
    }
}

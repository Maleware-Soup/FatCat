using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidablesPoints20 : Colidables
{
    protected override void OnTouch(Hud h)
    {
        h.scoreAddon += 20;
        h.PointAddOn();
        Destroy(this.gameObject);
    }
}

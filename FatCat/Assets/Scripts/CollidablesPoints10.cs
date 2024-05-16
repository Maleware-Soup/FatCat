using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidablesPoints10 : Colidables
{
    protected override void OnTouch(Hud h)
    {
        h.scoreAddon += 15;
        h.PointAddOn();
        Destroy(this.gameObject);
    }
}

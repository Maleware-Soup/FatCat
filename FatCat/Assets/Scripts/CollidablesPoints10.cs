using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidablesPoints10 : Colidables
{
    protected override void OnTouch(Hud h)
    {
        h.scoreAddon += 10;
        h.PointAddOn();
        Destroy(this.gameObject);
    }
}

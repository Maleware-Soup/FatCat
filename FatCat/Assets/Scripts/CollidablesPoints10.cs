using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidablesPoints10 : Colidables
{
    protected override void OnTouch(Hud h)
    {
        Destroy(this.gameObject);
        h.scoreAddon += 10;
        h.PointAddOn();
    }
}

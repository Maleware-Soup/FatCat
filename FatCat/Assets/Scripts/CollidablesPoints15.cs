using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidablesPoints15 : Colidables
{
    protected override void OnTouch(Hud h)
    {
        Destroy(this.gameObject);
        h.scoreAddon += 15;
        h.PointAddOn();
    }
}

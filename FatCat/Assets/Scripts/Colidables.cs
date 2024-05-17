using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colidables : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Hud hud;
        hud = Object.FindAnyObjectByType<Hud>();
        OnTouch(hud);
    }

    protected virtual void OnTouch(Hud h)
    {
        Destroy(this.gameObject);
        h.PointAddOn();
    }

}

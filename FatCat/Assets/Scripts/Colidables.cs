using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colidables : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Hud hud;
        hud = collider.gameObject.GetComponent<Hud>();


    }

    protected virtual void OnTouch(Hud h)
    {
        h.PointAddOn();

        Destroy(this.gameObject);
    }

}

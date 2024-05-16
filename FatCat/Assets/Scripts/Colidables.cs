using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
        h.PointAddOn();

        Destroy(this.gameObject);
    }

}

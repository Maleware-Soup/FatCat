using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGOffset : MonoBehaviour
{
    public Material myMaterial;

    public float offsetX;
    public float offsetY;

    public Vector2 newOffset;

    [Range(-3f,3f)]
    public float speed = 1f;
    
    void Start()
    {
        
    }


    void Update()
    {
        newOffset.x += speed * Time.deltaTime;

        if (newOffset.x >1f)
        {
            newOffset.x -= 1f;
        }
        if (newOffset.x < -1f)
        {
            newOffset.x += 1f;
        }
        myMaterial.mainTextureOffset = newOffset;
    }
}

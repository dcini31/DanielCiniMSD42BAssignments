using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{

    [SerializeField] float bgScrollSpeed = 0.02f;

    Material myMaterial;

    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;

        offSet = new Vector2(0f, bgScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //moves texture of material by offset each frame
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}

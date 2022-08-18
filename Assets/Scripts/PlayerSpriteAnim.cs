using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteAnim : MonoBehaviour
{
    [SerializeField] private Texture2D[] frames;
    [SerializeField] private  float fps = 10.0f;

    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer> ().material;
        // Texture2D[] frames = { (Texture2D) Resources.Load("Assets/Materials/Player01.PNG"), (Texture2D) Resources.Load("Assets/Materials/Player02.PNG") };
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * fps);
        index = index % 2;
        // index = index % frames.Length;
        mat.mainTexture = this.frames[index]; // usar en planeObjects
        //GetComponent<RawImage> ().texture = frames [index];
    }
}

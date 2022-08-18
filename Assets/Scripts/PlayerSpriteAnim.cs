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
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * fps);
        index = index % frames.Length;
        mat.mainTexture = frames[index]; // usar en planeObjects
    }
}

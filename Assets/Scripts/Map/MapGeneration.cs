using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{

    [SerializeField]
    private bool isRandom = false;

    [SerializeField]
    private int Size = 100;
    private int xOrigin = 0;
    private int yOrigin = 0;

    [SerializeField]
    private float Scale = 1f;

    private Texture2D NoiseTexture;
    private Color[] StorePixels;
    private SpriteRenderer Render;

    void Start() {

        if(!isRandom) return;

        xOrigin = Random.Range(-10000,10000);
        yOrigin = Random.Range(-10000,10000);

        Render = GetComponent<SpriteRenderer>();

        NoiseTexture = new Texture2D(Size,Size);
        StorePixels = new Color[Size * Size];
        Render.material.mainTexture = NoiseTexture;

        CalculateNoise();
    
    }

    public void CalculateNoise() {

        float y = 0f;

        while (y < NoiseTexture.height) {
            
            float x = 0f;

            while (x < NoiseTexture.width) {

                float xCoordinate = xOrigin + x / NoiseTexture.width * Scale;
                float yCoordinate = yOrigin + y / NoiseTexture.height * Scale;

                float Sample = Mathf.PerlinNoise(xCoordinate,yCoordinate);
                StorePixels[(int)y * NoiseTexture.width + (int)x] = new Color(Sample,Sample,Sample);
                x++;

            }

            y++;

        }

        NoiseTexture.SetPixels(StorePixels);
        NoiseTexture.Apply();
        Render.sprite = Sprite.Create(NoiseTexture, new Rect(0,0,Size,Size), new Vector2(0.5f,0.5f));

    }
    
}

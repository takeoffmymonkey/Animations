using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Еще один очень полезный метод анимации – это рельефная анима-
ция (UV, или mapping animation ), пример ее показан на следующем
скриншоте. Он заключается в программном изменении координат
вершин меша с течением времени с заставлением их скользить по
текстуре на поверхности объекта. Этот метод не изменяет пикселей
текстуры, а изменяет их расположение на поверхности. С помощью
рельефной анимации могут быть созданы такие эффекты, как, напри-
мер, течение воды, поток лавы, движение облаков, туннельные эф-
фекты и многое другое
 */

[RequireComponent(typeof(MeshRenderer))] //Requires Renderer Filter Component
public class MatScroller : MonoBehaviour
{
    //Public variables
    public float HorizSpeed = 1.0f;//Reference to Horizontal Scroll Speed
    public float VertSpeed = 1.0f;//Reference to Vertical Scroll Speed
    //Reference to Min and Max Horiz and Vertical UVs to scroll between
    public float HorizUVMin = 1.0f;
    public float HorizUVMax = 2.0f;
    public float VertUVMin = 1.0f;
    public float VertUVMax = 2.0f;
    
    //Private variables
    private MeshRenderer MeshR = null; //Reference to Mesh Renderer Component
    
    void Awake()
    {
        MeshR = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        //Scrolls texture between min and max
        Vector2 Offset = new Vector2(
            (MeshR.material.mainTextureOffset.x > HorizUVMax) ? 
            HorizUVMin : MeshR.material.mainTextureOffset.x + Time.deltaTime * HorizSpeed,
        (MeshR.material.mainTextureOffset.y > VertUVMax) ? 
        VertUVMin : MeshR.material.mainTextureOffset.y + Time.deltaTime * VertSpeed);
        
        //Update UV coordinates
        MeshR.material.mainTextureOffset = Offset;
    }
}
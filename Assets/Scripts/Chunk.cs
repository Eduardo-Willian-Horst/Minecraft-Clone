using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Mesh mesh;
    [SerializeField] private MeshCollider chunkCollum;
    private List<Vector3> vertices = new List<Vector3>();
    private List<int> triangles = new List<int>();
    [SerializeField] private int contFaces;

    //Texturas

    public List<Vector2> UVText = new List<Vector2>();
    private float textLargura = 0.33f;
    private int faceContagem;
    private Vector2 topGrass = new Vector2(1, 1);
    private Vector2 northGrass = new Vector2(0, 0);
    private Vector2 southGrass = new Vector2(0, 0);
    private Vector2 westGrass = new Vector2(0, 0);
    private Vector2 eastGrass = new Vector2(0, 0);
    private Vector2 bottomGrass = new Vector2(1, 0);

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        TopConstructor(0, 0, 0);
        BottomConstructor(0, 0, 0);
        NorthConstructor(0, 0, 0);
        SouthConstructor(0, 0, 0);
        EastConstructor(0, 0, 0);
        WestConstructor(0, 0, 0);
        MeshUpdate();
    }

    void AjustTextures(Vector2 info){
        Vector2 posTexture;
        posTexture = info;

        UVText.Add(new Vector2(textLargura * posTexture.x + textLargura, textLargura * posTexture.y));
        UVText.Add(new Vector2(textLargura * posTexture.x + textLargura, textLargura * posTexture.y + textLargura));
        UVText.Add(new Vector2(textLargura * posTexture.x, textLargura * posTexture.y + textLargura));
        UVText.Add(new Vector2(textLargura * posTexture.x, textLargura * posTexture.y));
    }

    void TopConstructor(int x, int y, int z)
    {
        vertices.Add(new Vector3(x, y, z + 1));
        vertices.Add(new Vector3(x + 1, y, z + 1));
        vertices.Add(new Vector3(x + 1, y, z));
        vertices.Add(new Vector3(x, y, z));
        AjustTextures(topGrass);
        CalculateTriangles();
    }

    void BottomConstructor(int x, int y, int z)
    {
        vertices.Add(new Vector3(x, y - 1, z + 1));
        vertices.Add(new Vector3(x, y - 1, z));
        vertices.Add(new Vector3(x + 1, y - 1, z));
        vertices.Add(new Vector3(x + 1, y - 1, z + 1));
        AjustTextures(bottomGrass);
        CalculateTriangles();
    }

    void NorthConstructor(int x, int y, int z)
    {
        vertices.Add(new Vector3(x + 1, y - 1, z + 1));
        vertices.Add(new Vector3(x + 1, y, z + 1));
        vertices.Add(new Vector3(x, y, z + 1));
        vertices.Add(new Vector3(x, y - 1, z + 1));
        AjustTextures(northGrass);
        CalculateTriangles();
    }

    void WestConstructor(int x, int y, int z)
    {
        vertices.Add(new Vector3(x + 1, y, z));
        vertices.Add(new Vector3(x + 1, y, z + 1));
        vertices.Add(new Vector3(x + 1, y - 1, z + 1));
        vertices.Add(new Vector3(x + 1, y - 1, z));
        AjustTextures(westGrass);
        CalculateTriangles();
    }

    void SouthConstructor(int x, int y, int z)
    {
        
        
        
        vertices.Add(new Vector3(x, y - 1, z));
        vertices.Add(new Vector3(x, y, z));
        vertices.Add(new Vector3(x + 1, y, z));
        vertices.Add(new Vector3(x + 1, y - 1, z));
        //997011116
        
        AjustTextures(southGrass);


        CalculateTriangles();
    }

    void EastConstructor(int x, int y, int z)
    {
        vertices.Add(new Vector3(x, y - 1, z + 1));
        vertices.Add(new Vector3(x, y, z + 1));
        vertices.Add(new Vector3(x, y, z));
        vertices.Add(new Vector3(x, y - 1, z));
        AjustTextures(eastGrass);
        CalculateTriangles();
    }

    private void CalculateTriangles()
    {
        triangles.Add(contFaces * 4);
        triangles.Add(contFaces * 4 + 1);
        triangles.Add(contFaces * 4 + 2);
        triangles.Add(contFaces * 4 + 0);
        triangles.Add(contFaces * 4 + 2);
        triangles.Add(contFaces * 4 + 3);

        contFaces++;
    }



    void MeshUpdate()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = UVText.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();


        vertices.Clear();
        triangles.Clear();
        UVText.Clear();
        contFaces = 0;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handmade : MonoBehaviour
{
    private GameObject go = null;
    private MeshFilter mf = null;
    private MeshRenderer mr = null;
    private void Start()
    {
        go = new GameObject("Character");
        //go.name = "Character";
        mf = go.AddComponent<MeshFilter>();
        mf.mesh = BuildMesh();

        mr = go.AddComponent<MeshRenderer>();
        //mr.materials[0] = CreateMaterial();
        //mr.materials[0].name = "HandmadeMaterial";
        mr.materials = new Material[]
        {
            CreateMaterial()
        };

        go.AddComponent<Jump>();
    }
    private void Update()
    {
        // 에디터모드에서만 나온다.
        Debug.DrawLine(transform.position, transform.position + mf.mesh.normals[0], Color.red);
    }
    private Mesh BuildMesh()
    {
        Mesh mesh = new Mesh();
        mesh.name = "HandmadeMesh";

        //0 -- 1
        //|      |
        //2 -- 3
        // # CW(Clock Wise) : 삼각형을 시계방향으로 만듦
        // # CCW(Counter Clock Wise) : 반시계 방향

        // # vertex - buffer
        Vector3[] vertices =
        {
            new Vector3(-0.5f, 1f, 0f),
            new Vector3(.5f, 1f, 0f),
            new Vector3(-0.5f, 0f,0f),
            new Vector3(0.5f, 0f, 0f)
        };
        // mesh에 vertex buffer 데이터 넣어 줌
        // mesh.vertices 변수 타입은 Vector3
        // # mesh.vertices : assigns a new vertex positions array
        mesh.vertices = vertices;

        // # index - buffer
        int[] indices =
        //{
        //    0, 1, 2,
        //    1, 2, 3
        //}; // CW + CCW -> 삼각형 앞뒤
        {
            0, 1, 2,
            2,1, 3
        }; //  CW 두개 -> 사각형
        // # mesh.triangles : an array ( int[] )containing all triangles in the Mesh
        mesh.triangles = indices;

        // # backface culling : 은면 제거
        // 은면 제거는 관찰자(카메라)가 볼 수 없는 면을 그리지 않는 것.
        // 은면이란 다각형의 면이 관찰자를 향하지 않는 면.
        // normal vector랑 조명이랑 내적해서 90도 이상 나오면 backface 판정 -> 조명 x (밝기 대상 x)
        // 원래 조명안받으면 시커매야하는데 diffuse외 다른 광때문에 희미하게 빛 띄게 되는 듯
        /*
         조명 계산 공식
        # Diffuse - 환경광....조명에서 반사되어서 보여지는 물체의 빛 - normal vect 내적
        # speccular  - 집중광.....
        # Ambient - 주변광. 빛 산란 후 

        # PBR physically based renderer
         ㄴ# Rtx raytracing - 그래픽카드 기술인데 빛 광선 다 추적해서 채도 결정

         */

        // # Winding Order (와인딩 순서)
        // 다각형의 정점들을 나열하는 순서
        // CW, CCW
        // vertex 순서에 따라 외적 결과 벡터 방향이 다르다. 그 성질을 이용해서 앞뒤판정

        // 모든 삼각형에 대한 normal vector 구할때 index ++3하면서 반복문 돌리면 됨
        Vector3 vecA = vertices[indices[0]] - vertices[indices[2]];
        Vector3 vecB = vertices[indices[1]] - vertices[indices[2]];
        Vector3 vecN = Vector3.Cross(vecA, vecB); //  vecA 와 vecB 외적해서 나온 법선 벡터
        vecN.Normalize(); // 법선벡터 단위벡터로 만들기

        // 정점마다 법선백터가 들어가기 때문에 4개가 된다.
        Vector3[] normals =
        {
            vecN, vecN, vecN, vecN
        };
        mesh.normals = normals;

        Vector2[] uvs =
        {
            new Vector2 (0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(0f, 0f),
            new Vector2(1f, 0f)
        };
        // # mesh.uv
        // the texure coordinates (UVs) in the first channel
        mesh.uv = uvs;
        return mesh;
    }

    private Material CreateMaterial()
    {
        // shader는 재질계산 공식
        Material mat = new Material(Shader.Find("Standard"));
        //mat.name = "HandmadeMaterial";

        Texture2D tex = Resources.Load<Texture2D>("Textures\\FemaleKnight");
        mat.mainTexture = tex;
        return mat;
    }
} // end of class

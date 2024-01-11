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
        // �����͸�忡���� ���´�.
        Debug.DrawLine(transform.position, transform.position + mf.mesh.normals[0], Color.red);
    }
    private Mesh BuildMesh()
    {
        Mesh mesh = new Mesh();
        mesh.name = "HandmadeMesh";

        //0 -- 1
        //|      |
        //2 -- 3
        // # CW(Clock Wise) : �ﰢ���� �ð�������� ����
        // # CCW(Counter Clock Wise) : �ݽð� ����

        // # vertex - buffer
        Vector3[] vertices =
        {
            new Vector3(-0.5f, 1f, 0f),
            new Vector3(.5f, 1f, 0f),
            new Vector3(-0.5f, 0f,0f),
            new Vector3(0.5f, 0f, 0f)
        };
        // mesh�� vertex buffer ������ �־� ��
        // mesh.vertices ���� Ÿ���� Vector3
        // # mesh.vertices : assigns a new vertex positions array
        mesh.vertices = vertices;

        // # index - buffer
        int[] indices =
        //{
        //    0, 1, 2,
        //    1, 2, 3
        //}; // CW + CCW -> �ﰢ�� �յ�
        {
            0, 1, 2,
            2,1, 3
        }; //  CW �ΰ� -> �簢��
        // # mesh.triangles : an array ( int[] )containing all triangles in the Mesh
        mesh.triangles = indices;

        // # backface culling : ���� ����
        // ���� ���Ŵ� ������(ī�޶�)�� �� �� ���� ���� �׸��� �ʴ� ��.
        // �����̶� �ٰ����� ���� �����ڸ� ������ �ʴ� ��.
        // normal vector�� �����̶� �����ؼ� 90�� �̻� ������ backface ���� -> ���� x (��� ��� x)
        // ���� ����ȹ����� ��Ŀ�ž��ϴµ� diffuse�� �ٸ� �������� ����ϰ� �� ��� �Ǵ� ��
        /*
         ���� ��� ����
        # Diffuse - ȯ�汤....������ �ݻ�Ǿ �������� ��ü�� �� - normal vect ����
        # speccular  - ���߱�.....
        # Ambient - �ֺ���. �� ��� �� 

        # PBR physically based renderer
         ��# Rtx raytracing - �׷���ī�� ����ε� �� ���� �� �����ؼ� ä�� ����

         */

        // # Winding Order (���ε� ����)
        // �ٰ����� �������� �����ϴ� ����
        // CW, CCW
        // vertex ������ ���� ���� ��� ���� ������ �ٸ���. �� ������ �̿��ؼ� �յ�����

        // ��� �ﰢ���� ���� normal vector ���Ҷ� index ++3�ϸ鼭 �ݺ��� ������ ��
        Vector3 vecA = vertices[indices[0]] - vertices[indices[2]];
        Vector3 vecB = vertices[indices[1]] - vertices[indices[2]];
        Vector3 vecN = Vector3.Cross(vecA, vecB); //  vecA �� vecB �����ؼ� ���� ���� ����
        vecN.Normalize(); // �������� �������ͷ� �����

        // �������� �������Ͱ� ���� ������ 4���� �ȴ�.
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
        // shader�� ������� ����
        Material mat = new Material(Shader.Find("Standard"));
        //mat.name = "HandmadeMaterial";

        Texture2D tex = Resources.Load<Texture2D>("Textures\\FemaleKnight");
        mat.mainTexture = tex;
        return mat;
    }
} // end of class

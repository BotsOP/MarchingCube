// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class ProceduralMesh : MonoBehaviour
// {
//     public Vector3 GridSize = new Vector3(10, 5, 10);
//     public float zoom = 1f;
//     public float noiseLimit = 0.5f;
//     public Material material;
//     private Mesh mesh;
//
//     private void Start()
//     {
//         MakeGrid();
//         //Noise2d();
//         Noise3D();
//         March();
//     }
//
//     private void MakeGrid()
//     {
//         MarchingCube.grd = new GridPoint[(int)GridSize.x, (int)GridSize.y, (int)GridSize.z];
//             
//         for (int z = 0; z < GridSize.z; z++)
//         {
//             for (int y = 0; y < GridSize.y; y++)
//             {
//                 for (int x = 0; x < GridSize.x; x++)
//                 {
//                     MarchingCube.grd[x, y, z] = new GridPoint
//                     {
//                         Position = new Vector3(x, y, z),
//                         On = false
//                     };
//                 }
//             }
//         }
//     }
//     private void Noise2d()
//     {
//         for (int z = 0; z < GridSize.z; z++)
//         {
//             for (int x = 0; x < GridSize.x; x++)
//             {
//                 float nx = (x / GridSize.x) * zoom;
//                 float nz = (z / GridSize.z) * zoom;
//                 float height = Mathf.PerlinNoise(nx, nz) * GridSize.y;
//
//                 for (int y = 0; y < GridSize.y; y++)
//                 {
//                     MarchingCube.grd[x, y, z].On = y < height;
//                 }
//             }
//         }
//     }
//     private void Noise3D()
//     {
//         for (int z = 0; z < GridSize.z; z++)
//         {
//             for (int y = 0; y < GridSize.y; y++)
//             {
//                 for (int x = 0; x < GridSize.x; x++)
//                 {
//                     float nx = (x / GridSize.x) * zoom;
//                     float ny = (y / GridSize.y) * zoom;
//                     float nz = (z / GridSize.z) * zoom;
//                     float noise = MarchingCube.PerlinNoise3D(nx, ny, nz);
//
//                     MarchingCube.grd[x, y, z].On = (noise > noiseLimit);
//                 }
//             }
//         }
//     }
//     private void March()
//     {
//         GameObject go = this.gameObject;
//         mesh = MarchingCube.GetMesh(ref go, ref material);
//         MarchingCube.Clear();
//         MarchingCube.MarchCubes();
//         
//         MarchingCube.SetMesh(ref mesh);
//     }
// }

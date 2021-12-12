using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : Planet
{   
    ShapeGenerator shapeGenerator = new ShapeGenerator();
    ColourGenerator colourGenerator = new ColourGenerator();
    MeshFilter[] moonMeshFilters;
    TerrainFace[] terrainFaces;

     public void GenerateMoon()
    {
        GenerateMesh();
        GenerateColours();
    }

    void GenerateMesh() 
    {
        for(int i = 0; i < 6; i++)
        {
            if(moonMeshFilters[i].gameObject.activeSelf)
            {
                terrainFaces[i].ConstructMesh();
            }
        }
        colourGenerator.UpdateElevation(shapeGenerator.elevationMinMax);
    }
    void GenerateColours()
    {
        colourGenerator.UpdateColours();
        for(int i = 0; i < 6; i++)
        {
            if(moonMeshFilters[i].gameObject.activeSelf)
            {
                terrainFaces[i].UpdateUVs(colourGenerator);
            }
        }
    }

}

using UnityEngine;
using System.Collections;
using System.Xml;

public class OZMLSave : MonoBehaviour 
{
	public string LevelName = "dori0";
	public Material[] SceneMaterials;
	
	void Start() 
	{
		XmlWriter writer = XmlWriter.Create( LevelName + ".xml" );
		writer.WriteStartDocument();
		writer.WriteStartElement("ozml");
		
		// Scene
		writer.WriteStartElement("scene");
		
		string background = GetComponentInChildren<Camera>().backgroundColor.ToString();
		background = background.Substring( 5, background.Length - 13 );
		writer.WriteAttributeString( "background", background );
		
		string fog = RenderSettings.fogColor.ToString();
		fog = fog.Substring( 5, fog.Length - 6 );
		writer.WriteAttributeString( "fog", fog );
			
		writer.WriteEndElement();
		writer.Flush();
		// Materials
		writer.WriteStartElement("materials");
		
		foreach( Material mat in SceneMaterials )
		{
			writer.WriteRaw( "." + mat.name + "{texture:http://dev.xxiivv.com/ozml/img/" + mat.name + ".jpg;}");
		}
		
		writer.WriteEndElement();
		writer.Flush();
		
		// Geometry
		writer.WriteStartElement("geometry");
		
		GameObject[] cubes = GameObject.FindGameObjectsWithTag( "Cube" );
		for( int i = 0; i < cubes.Length; i++ )
	    {
			GameObject cube = cubes[i];
			
			writer.WriteStartElement( "cube" );
	
			writer.WriteAttributeString( "name", cube.name + ":" + i );
			
			string matString = cube.renderer.material.name;
			writer.WriteAttributeString( "material", matString.Substring( 0, matString.Length - 11 ) );
			
			string posString = cube.transform.position.ToString();
			writer.WriteAttributeString( "position", posString.Substring( 1, posString.Length - 2 ) );
	
			writer.WriteEndElement();
			
			writer.Flush();
	    }
		
		writer.WriteEndElement();
		
		writer.WriteEndElement();
		writer.WriteEndDocument();
		
		writer.Flush();
	}
}

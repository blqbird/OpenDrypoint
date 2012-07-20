using UnityEngine;
using System.Collections;
using System.Xml;

public class OZMLSave : MonoBehaviour 
{
	public string LevelName = "dori0";
	
	void Start() 
	{
		XmlWriter writer = XmlWriter.Create( LevelName + ".xml" );
		writer.WriteStartDocument();
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
		writer.WriteEndDocument();
		
		writer.Flush();
	}
}

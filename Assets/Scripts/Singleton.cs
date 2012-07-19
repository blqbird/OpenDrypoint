using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour
{
     public static Singleton singleton;

     //Set this to the correct level in the inspector
     public int currentLevel = 0;

     void Start()
     {
          if (Singleton.singleton == null)
          {
               Singleton.singleton = this;
               DontDestroyOnLoad(gameObject);
          }
          else if (Singleton.singleton.currentLevel != Application.loadedLevel)
          {
               Destroy(Singleton.singleton.gameObject);
               Singleton.singleton = this;
               DontDestroyOnLoad(gameObject);
          }
          else if (Singleton.singleton != this)
          {
               Destroy(gameObject);
          }
     }
}
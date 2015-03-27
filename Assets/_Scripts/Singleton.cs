using UnityEngine;
using System.Collections;

/// <summary>
/// Gosh I'll figure out this later
/// 
/// but it's supposed to be for any static classes that i want to have singletons
/// </summary>

public abstract class Singleton<T> where T : new() { 

	private static T _instance; 

	private Singleton() { } 

	public static T Instance { 
		get { 
			if (Equals(_instance, default(T))) {
				_instance = new T(); 
			} 
			return _instance; 
		} 
	} 
}

using UnityEngine;
using System.Collections;

/// <summary>
/// Game manager keeps track of higher level states
/// 
/// also responsible for instantiating various higher level managers
/// 
/// 
/// and perhaps some very high level parameters
/// </summary>
/// 
/// 
public class GameManager : MonoBehaviour {


	public static int GameCols = 10;
	public static int GameRows = 4;

	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	private GridManager gridScript;                       //Store a reference to our BoardManager which will set up the level.
	private FightManager fightScript;

	private int level = 3;                                  //Current level number, expressed in game as "Day 1".

	[SerializeField] 
	private GameState _gameState = GameState.paused;
	private GameState _prevState = GameState.paused;
	
	public GameState gameState {
		get { return _gameState;}
		set {
			_prevState = _gameState;
			_gameState = value;
			LeaveState(_prevState);
			EnterState(_gameState);
		}
	}

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
		
		//Get a component reference to the attached BoardManager script
		gridScript = GetComponent<GridManager>();
		fightScript = GetComponent<FightManager>();

		InitGame();
	}
	
	//Initializes the game for each level.
	void InitGame()
	{
		//Call the SetupScene function of the BoardManager script, pass it current level number.
//		gridScript.InitGrid(level);
		fightScript.Init();
	}
	
	//Update is called every frame.
	void Update()
	{
		
	}


	void EnterState(GameState state){
		Debugger.Log ("GameState", "Entering state: " + state.ToString());
	}

	void LeaveState(GameState state){
		Debugger.Log ("GameState", "Leaving state: " + state.ToString());
	}


	
}

/// <summary>
/// Game state enumeration!
/// </summary>
public enum GameState{ paused, playing, loading}

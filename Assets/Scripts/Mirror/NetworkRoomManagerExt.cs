using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Mirror.Examples.NetworkRoom
{
    [AddComponentMenu("")]
    public class NetworkRoomManagerExt : NetworkRoomManager
    {
        public string PlayerName { get; set; }

        public override void Awake()
        {
            //CA::2020-12-20:: Tiro un random list para los minijuegos.
            randomizeMinigames();
            base.Awake();
        }

        /*
        [Header("Spawner Setup")]
        [Tooltip("Reward Prefab for the Spawner")]
        public GameObject rewardPrefab;*/

        /*
        /// <summary>
        /// This is called on the server when a networked scene finishes loading.
        /// </summary>
        /// <param name="sceneName">Name of the new scene.</param>
        public override void OnRoomServerSceneChanged(string sceneName)
        {
            // spawn the initial batch of Rewards
            if (sceneName == GameplayScene)
            {
                Spawner.InitialSpawn();
            }
        }
        */

        /// <summary>
        /// Called just after GamePlayer object is instantiated and just before it replaces RoomPlayer object.
        /// This is the ideal point to pass any data like player name, credentials, tokens, colors, etc.
        /// into the GamePlayer object as it is about to enter the Online scene.
        /// </summary>
        /// <param name="roomPlayer"></param>
        /// <param name="gamePlayer"></param>
        /// <returns>true unless some code in here decides it needs to abort the replacement</returns>
        public override bool OnRoomServerSceneLoadedForPlayer(NetworkConnection conn, GameObject roomPlayer, GameObject gamePlayer)
        {
            PlayerScore playerScore = gamePlayer.GetComponent<PlayerScore>();
            playerScore.index = roomPlayer.GetComponent<NetworkRoomPlayer>().index;
            return true;
        }

        public override void OnRoomStopClient()
        {
            // Demonstrates how to get the Network Manager out of DontDestroyOnLoad when
            // going to the offline scene to avoid collision with the one that lives there.
            if (gameObject.scene.name == "DontDestroyOnLoad" && !string.IsNullOrEmpty(offlineScene) && SceneManager.GetActiveScene().path != offlineScene)
                SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());

            base.OnRoomStopClient();
        }

        public override void OnRoomStopServer()
        {
            // Demonstrates how to get the Network Manager out of DontDestroyOnLoad when
            // going to the offline scene to avoid collision with the one that lives there.
            if (gameObject.scene.name == "DontDestroyOnLoad" && !string.IsNullOrEmpty(offlineScene) && SceneManager.GetActiveScene().path != offlineScene)
                SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());

            base.OnRoomStopServer();
        }

        /*
            This code below is to demonstrate how to do a Start button that only appears for the Host player
            showStartButton is a local bool that's needed because OnRoomServerPlayersReady is only fired when
            all players are ready, but if a player cancels their ready state there's no callback to set it back to false
            Therefore, allPlayersReady is used in combination with showStartButton to show/hide the Start button correctly.
            Setting showStartButton false when the button is pressed hides it in the game scene since NetworkRoomManager
            is set as DontDestroyOnLoad = true.
        */

        bool showStartButton;

        public override void OnRoomServerPlayersReady()
        {
            // calling the base method calls ServerChangeScene as soon as all players are in Ready state.
#if UNITY_SERVER
            base.OnRoomServerPlayersReady();
#else
            showStartButton = true;
#endif
        }

        public override void OnGUI()
        {
            base.OnGUI();

            if("Lobby" == SceneManager.GetActiveScene().name){
                if (allPlayersReady)
                {
                    if(showStartButton){
                        showStartButton = false;
                        GameObject.Find("StartBtn").GetComponent<Button>().interactable = true;
                        GameObject.Find("StartBtn").GetComponent<Button>().onClick.AddListener(nextLevel);               
                        GameObject.Find("StartBtn").transform.GetChild(0).GetComponent<Text>().text = "Start Game";
                    }
                }
                else{
                    GameObject.Find("StartBtn").GetComponent<Button>().interactable = false;
                    GameObject.Find("StartBtn").transform.GetChild(0).GetComponent<Text>().text = "";
                }
            }
        }
        
        //CA::2020-12-20:: Me robo cosas del chat.
        public struct CreatePlayerMessage : NetworkMessage
        {
            public string name;
        }

        /*
        public override void OnStartServer()
        {
            base.OnStartServer();
            NetworkServer.RegisterHandler<CreatePlayerMessage>(OnCreatePlayer);
        }
        */
        
        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);

            // tell the server to create a player with this name
            conn.Send(new CreatePlayerMessage { name = PlayerName });
        }

        /*
        void OnCreatePlayer(NetworkConnection connection, CreatePlayerMessage createPlayerMessage)
        {
            // create a gameobject using the name supplied by client
            GameObject playergo = Instantiate(playerPrefab);
            playergo.GetComponent<Player>().playerName = createPlayerMessage.name;

            // set it as the player
            NetworkServer.AddPlayerForConnection(connection, playergo);

            //chatWindow.gameObject.SetActive(true);
        }
        */

        //ROBO Más
        public void SetHostname(string hostname)
        {
            networkAddress = hostname;
        }

        public void nextLevel(){
            ServerChangeScene(GameplayScene[randomListIndex[currentRandomIndex]]);
        }
    }
}

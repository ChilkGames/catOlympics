using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mirror.Examples.NetworkRoom
{
    [AddComponentMenu("")]
    public class NetworkRoomPlayerExt : NetworkRoomPlayer
    {
        static readonly ILogger logger = LogFactory.GetLogger(typeof(NetworkRoomPlayerExt));
        
        //CA::::
        public GameObject roomPlayerBannerPrefab;

        bool bannerDisplayed = false;

        public override void OnStartClient()
        {
            if (logger.LogEnabled()) logger.LogFormat(LogType.Log, "OnStartClient {0}", SceneManager.GetActiveScene().path);
            base.OnStartClient();
        }

        public override void OnClientEnterRoom()
        {
            if (logger.LogEnabled()) logger.LogFormat(LogType.Log, "OnClientEnterRoom {0}", SceneManager.GetActiveScene().path);
            if(!bannerDisplayed){
                generateBanner();
            }
        }

        public override void OnClientExitRoom()
        {
            if (logger.LogEnabled()) logger.LogFormat(LogType.Log, "OnClientExitRoom {0}", SceneManager.GetActiveScene().path);
        }

        public override void ReadyStateChanged(bool _, bool newReadyState)
        {
            if (logger.LogEnabled()) logger.LogFormat(LogType.Log, "ReadyStateChanged {0}", newReadyState);
        }

        void generateBanner(){
            GameObject newRoomBannerGameObject; // = OnRoomServerCreateRoomPlayer(conn);

            newRoomBannerGameObject = Instantiate(roomPlayerBannerPrefab.gameObject, Vector3.zero, Quaternion.identity);
            
            newRoomBannerGameObject.transform.parent = GameObject.Find("Canvas").transform; 
            newRoomBannerGameObject.transform.localScale = new Vector3(1,1,1);
            switch(index){
                case 0:
                    newRoomBannerGameObject.GetComponent<RectTransform>().localPosition = new Vector3(-700, 110, 0);
                    break;
                case 1:
                    newRoomBannerGameObject.GetComponent<RectTransform>().localPosition = new Vector3(-245, 110, 0);
                    break;
                case 2:
                    newRoomBannerGameObject.GetComponent<RectTransform>().localPosition = new Vector3(210, 110, 0);
                    break;
                default:
                    newRoomBannerGameObject.GetComponent<RectTransform>().localPosition = new Vector3(665, 110, 0);
                    break;
            }
            
            playerBanner = newRoomBannerGameObject;
            bannerDisplayed = true;
        }

        public override void destroyBanner(){
            Destroy(playerBanner);
            bannerDisplayed = false;
        }
    }
}

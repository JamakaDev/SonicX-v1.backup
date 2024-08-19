using UnityEngine;

namespace SlimUI.ModernMenu{
    public class ExtraLinks : MonoBehaviour{
        public void OurWebsite(){
            Application.OpenURL("https://www.sonicx.xyz/");
        }

        public void OurXTwitter(){
            Application.OpenURL("https://x.com/SonicXFTM");
        }

        public void OurTelegram(){
            Application.OpenURL("https://t.co/5q8vdGT8N4");
        }

        public void OurTradingBot(){
            Application.OpenURL("https://t.co/pFXTHKCGdM");
        }
    }
}

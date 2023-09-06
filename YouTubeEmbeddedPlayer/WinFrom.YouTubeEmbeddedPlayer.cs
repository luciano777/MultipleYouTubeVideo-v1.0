using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace YouTubeEmbeddedPlayer
{
    public class YoutubePlayer
    {
        #region All Class Property Full


        private string _YotubeVideoURL;

        /// <summary>
        /// This is The Youtube Link You Want Play It
        /// </summary>
        public string YotubeVideoURL
        {
            get { return _YotubeVideoURL; }
            set { _YotubeVideoURL = value; }
        }

        private int _StartSeconds;

        /// <summary>
        /// Add Start Time To Play The Vedio In { SECONDS }
        /// </summary>
        public int StartSeconds
        {
            get { return _StartSeconds; }
            set { _StartSeconds = value; }
        }

        private int _EndSeconds;

        /// <summary>
        /// Add End Time To Play The Vedio In { SECONDS }
        /// </summary>
        public int EndSeconds
        {
            get { return _EndSeconds; }
            set { _EndSeconds = value; }
        }

        private bool _Force1080HD;

        /// <summary>
        /// Force The Vedio Tp play In 1080 HD
        /// </summary>
        public bool Force1080HD
        {
            get { return _Force1080HD; }
            set { _Force1080HD = value; }
        }
        private bool _ShowInfo;
        /// <summary>
        /// showinfo=0: oculta el título y la información del video.
        /// </summary>
        public bool ShowInfo
        {
            get { return _ShowInfo; }
            set { _ShowInfo = value; }
        }
        private bool _Autoplay;

        /// <summary>
        /// Autoplay The Vedio When Loading The Page
        /// </summary>
        public bool Autoplay
        {
            get { return _Autoplay; }
            set { _Autoplay = value; }
        }
        private bool _FullScreen;
        /// <summary>
        /// FullScreen the Video
        /// </summary>
        public bool FullScreen
        {
            get { return _FullScreen; }
            set { _FullScreen = value; }
        }

        private bool _LoopVideoOrPlaylist;

        /// <summary>
        /// Play The Vedios Or Playlest In Loop
        /// </summary>
        public bool LoopVideoOrPlaylist
        {
            get { return _LoopVideoOrPlaylist; }
            set { _LoopVideoOrPlaylist = value; }
        }

        private bool _ModestBranding;

        /// <summary>
        /// Modest Branding
        /// </summary>
        public bool ModestBranding
        {
            get { return _ModestBranding; }
            set { _ModestBranding = value; }
        }

        private bool _ShowUnrelatedVideos;

        /// <summary>
        /// Show Unrelated Videos
        /// </summary>
        public bool ShowUnrelatedVideos
        {
            get { return _ShowUnrelatedVideos; }
            set { _ShowUnrelatedVideos = value; }
        }

        private string _PlayerLanguage;

        /// <summary>
        /// Set Player Language { ar-eg , eng-us , ....etc }
        /// </summary>
        public string PlayerLanguage
        {
            get { return _PlayerLanguage; }
            set { _PlayerLanguage = value; }
        }

        private bool _EnablePlayerControls;

        /// <summary>
        /// Enable Player Controls 
        /// </summary>
        public bool EnablePlayerControls
        {
            get { return _EnablePlayerControls; }
            set { _EnablePlayerControls = value; }
        }

        private bool _UsingWhiteProgressBar;

        /// <summary>
        /// Using White ProgressBar in the Player
        /// </summary>
        public bool UsingWhiteProgressBar
        {
            get { return _UsingWhiteProgressBar; }
            set { _UsingWhiteProgressBar = value; }
        }

        private bool _DisablePlayerKeyboardShortcuts;

        /// <summary>
        /// Disable Player Keyboard Shortcuts
        /// </summary>
        public bool DisablePlayerKeyboardShortcuts
        {
            get { return _DisablePlayerKeyboardShortcuts; }
            set { _DisablePlayerKeyboardShortcuts = value; }
        }

        private string[] _PlayerPlaylistIDs;

        /// <summary>
        /// Player Playlist IDs
        /// </summary>
        public string[] PlayerPlaylistIDs
        {
            get { return _PlayerPlaylistIDs; }
            set { _PlayerPlaylistIDs = value; }
        }

        private string _ListID;

        /// <summary>
        /// List ID
        /// </summary>
        public string ListID
        {
            get { return _ListID; }
            set { _ListID = value; }
        }


        private WebBrowser _WebBrowserControl;

        /// <summary>
        /// The WebBrowser Control Used In Your Form "Name"
        /// </summary>
        public WebBrowser WebBrowserControl
        {
            get { return _WebBrowserControl; }
            set { _WebBrowserControl = value; }
        }

        #endregion

        #region Class Constractor

        /// <summary>
        /// The Defalt Constractor
        /// </summary>
        public YoutubePlayer()
        {

            _YotubeVideoURL = YotubeVideoURL;
            _WebBrowserControl = WebBrowserControl;
            _Autoplay = Autoplay;
            _ShowInfo = ShowInfo;
            _FullScreen = FullScreen;
            _StartSeconds = StartSeconds;
            _EndSeconds = EndSeconds;
            _Force1080HD = Force1080HD;
            _Autoplay = Autoplay;
            _LoopVideoOrPlaylist = LoopVideoOrPlaylist;
            _ModestBranding = ModestBranding;
            _ShowUnrelatedVideos = ShowUnrelatedVideos;
            _PlayerLanguage = PlayerLanguage;
            _EnablePlayerControls = EnablePlayerControls;
            _UsingWhiteProgressBar = UsingWhiteProgressBar;
            _DisablePlayerKeyboardShortcuts = DisablePlayerKeyboardShortcuts;
            _PlayerPlaylistIDs = PlayerPlaylistIDs;
            _WebBrowserControl = WebBrowserControl;
        }
        #endregion

        #region Create Youtube Embed URL

        /// <summary>
        /// Creat a Custom Youtube Embedded URL
        /// </summary>
        /// <returns>String Of a Custom Youtube Embedded URL</returns>
        public string CreateYoutubeEmbedURL()
        {
            string VedioID = GetIDFromYoutubeURL(_YotubeVideoURL);

            var uriBuilder = new UriBuilder()
            {
                Scheme = "https",
                Host = "www.youtube.com",
                Path = "/embed/" + VedioID
            };

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            if (_Autoplay)
            {
                query["autoplay"] = "1";
            }
            if (_ShowInfo)
            {
                query["showinfo"] = "0";
            }

            if (_FullScreen)
            {
                query["fullscreen"] = "1";
            }

            if (_StartSeconds > 0)
            {
                query["start"] = _StartSeconds.ToString();
            }

            if (_EndSeconds > 0)
            {
                query["end"] = _StartSeconds.ToString();
            }

            if (_Force1080HD)
            {
                query["vq"] = "hd1080";
            }

            if (_LoopVideoOrPlaylist)
            {
                query["loop"] = "1";
            }

            if (_ModestBranding)
            {
                query["modestbranding"] = "1";
            }

            if (_ShowUnrelatedVideos)
            {

            }
            else
            {
                query["rel"] = "0";
            }

            if (_EnablePlayerControls)
            {

            }
            else
            {
                query["controls"] = "0";
            }

            if (_UsingWhiteProgressBar)
            {
                query["color"] = "white";
            }

            if (_DisablePlayerKeyboardShortcuts)
            {
                query["disablekb"] = "1";
            }


            if (string.IsNullOrEmpty(_PlayerLanguage))
            {

            }
            else
            {
                query["hl"] = _PlayerLanguage;
            }

            if (_PlayerPlaylistIDs != null)
            {
                string JoinAllIDs = string.Join(",", _PlayerPlaylistIDs.Select(item => item));

                query["playlist"] = JoinAllIDs;
            }

            uriBuilder.Query = query.ToString();

            string YoutubeEmbedURL = HttpUtility.UrlDecode(uriBuilder.ToString());


            return YoutubeEmbedURL;
        }

        #endregion

        #region Extract Video ID From Youtube URLs

        /// <summary>
        /// Need Youtube Url In Format
        /// 1- youtube.com/watch?v=AuZR06xtgXQ
        /// 2- youtu.be/AuZR06xtgXQ
        /// 3- www.youtube.com/embed/AuZR06xtgXQ?start=30&end=60&vq=hd1080&hl=en-us
        /// Check The Format Befor Passing The Parmeters
        /// </summary>
        /// <param name="YoutubeURL">Need Youtube URL</param>
        /// <returns>Youtube Vedio ID</returns>
        public string GetIDFromYoutubeURL(string YoutubeURL)
        {
            var uri = new Uri(YoutubeURL);

            var query = HttpUtility.ParseQueryString(uri.Query);

            var YoutubeVideoId = string.Empty;

            if (query.AllKeys.Contains("v"))
            {
                YoutubeVideoId = query["v"];
            }
            else
            {
                YoutubeVideoId = uri.Segments.Last();
            }

            return YoutubeVideoId;
        }

        #endregion

        #region Extract Youtube List Play ID From Youtube URLs Contains "list" Query

        /// <summary>
        /// Extract Youtube List ID From URL
        /// Like Query "list=PLqPejUavRNTVu6AWaG8HREYJDw6cL1oZA"
        /// </summary>
        /// <param name="YoutubeURL">Youtube Link Contain "list" Query</param>
        /// <returns>Youtube List ID AS String</returns>
        //public string GetListIDFromYoutubeURL(string YoutubeURL)
        //{
        //    var uri = new Uri(YoutubeURL);

        //    var query = HttpUtility.ParseQueryString(uri.Query);

        //    var YoutubeListID = string.Empty;

        //    if (query.AllKeys.Contains("list"))
        //    {
        //        YoutubeListID = query["list"];
        //    }
        //    else
        //    {
        //        YoutubeListID = uri.Segments.Last();
        //    }

        //    return YoutubeListID;
        //}


        #endregion

        #region Create An HTML Page To Load Your Custom Player In webBrowser Contolr

        /// <summary>
        /// This Method Retern coustom HTML with your choois
        /// just to embed it in the Youtube Player
        /// </summary>
        /// <returns> HtmlPage to Use it in WebBrowser Control to LOAD Yout Vedio In FUll Screen</returns>
        public string HtmlPlayer()
        {
            string HtmlPage = "<html> <head>" +
                    "<meta charset=\"utf-8\" content='IE=Edge' http-equiv='X-UA-Compatible'/>" +
                    "</head>" +
                    "<body style=\"margin: 0; overflow: hidden;\">" +
                    "<div style=\"position: relative; padding-bottom: 100%; padding-top: 0%; height: 0; overflow: hidden;\">" +
                    "<iframe style=\"position: absolute; top: 0; left: 0; bottom: 0;\" width='" + _WebBrowserControl.Width + "' height='" + _WebBrowserControl.Height + "'        src='" + CreateYoutubeEmbedURL() + "'    frameborder='0'  allow=\"accelerometer; clipboard-write; encrypted-media; gyroscope; picture-in-picture;\" allowFullScreen></iframe>" +
                    "</div>" +
                    "</body> </html>";

            return HtmlPage;
        }

        #endregion
    }
}

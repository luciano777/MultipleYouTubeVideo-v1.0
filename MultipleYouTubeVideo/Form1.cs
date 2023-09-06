using System;
using System.Drawing;
using System.Windows.Forms;
using YouTubeEmbeddedPlayer;

namespace MultipleYouTubeVideo
{
    public partial class FormMultiplePlayer : Form
    {
        string ventana1 = "https://youtu.be/HPiv1pzIPRc";//TN 
        string ventana2 = "https://youtu.be/O9mOtdZ-nSk";//Euronews
        string ventana3 = "https://youtu.be/4e8Iw3Frf1A";//LN+
        string ventana4 = "https://youtu.be/g7Kx0AKmfTg";//Vorterix
        string ventana5 = "https://youtu.be/XDJPzMznAjU";//France24
        string ventana6 = "https://youtu.be/tsStUN73_6I";//DW
        string link;

        public FormMultiplePlayer()
        {
            InitializeComponent();
            this.SizeChanged += new EventHandler(FormMain_SizeChanged);
            this.Resize += Form1_Resize;
            this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.Size = new Size((int)(this.ClientSize.Width), (int)(this.ClientSize.Height * 0.98));
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                // Verifica si el control es un WebBrowser
                if (control is WebBrowser webBrowser)
                {
                    // Ajusta el tamaño del WebBrowser al tamaño actual del TableLayoutPanel
                    webBrowser.Width = tableLayoutPanel1.ClientSize.Width / 3;
                    webBrowser.Height = tableLayoutPanel1.ClientSize.Height / 2;
                }
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is WebBrowser webBrowser)
                {
                    webBrowser.Width = tableLayoutPanel1.Width / 3;
                    webBrowser.Height = tableLayoutPanel1.Height / 2;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnInformacion_Click(sender,e);
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is WebBrowser webBrowser)
                {
                    if (webBrowser.Name == webBrowser1.Name) { link = ventana1; }
                    if (webBrowser.Name == webBrowser2.Name) { link = ventana2; }
                    if (webBrowser.Name == webBrowser5.Name) { link = ventana3; }
                    if (webBrowser.Name == webBrowser6.Name) { link = ventana4; }
                    if (webBrowser.Name == webBrowser3.Name) { link = ventana5; }
                    if (webBrowser.Name == webBrowser4.Name) { link = ventana6; }
                    YoutubePlayer youtubeWebBrowserPlayer = new YoutubePlayer()
                    {
                        YotubeVideoURL = link,
                        Force1080HD = true,
                        Autoplay = true,
                        FullScreen = true,
                        ModestBranding = true,
                        EnablePlayerControls = false,
                        //ShowInfo=false,
                        UsingWhiteProgressBar = false,
                        DisablePlayerKeyboardShortcuts = true,
                        WebBrowserControl = webBrowser1
                    };
                    webBrowser.DocumentText = string.Format(youtubeWebBrowserPlayer.HtmlPlayer());

                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string link = txtBxYoutubeURL.Text;
            if (txtBxYoutubeURL.Text == "" || txtBxYoutubeURL == null) { MessageBox.Show("No hay ningun link de Youtube!."); }
            else if (link.StartsWith("https://youtu.be/") == false) { MessageBox.Show("El link no es correcto debe empezar como: https://youtu.be/XXXXXXXXXX"); }
            else
            {
                try
                {
                    int ventana = ChequearVideo();
                    YoutubePlayer youtubeWebBrowserPlayer = new YoutubePlayer()
                    {
                        YotubeVideoURL = txtBxYoutubeURL.Text,
                        Force1080HD = true,
                        Autoplay = true,
                        FullScreen = true,
                        ModestBranding = true,
                        EnablePlayerControls = true,
                        UsingWhiteProgressBar = false,
                        DisablePlayerKeyboardShortcuts = true,
                        WebBrowserControl = webBrowser1
                    };
                    if (ventana == 1) { this.webBrowser1.DocumentText = string.Format(youtubeWebBrowserPlayer.HtmlPlayer()); ventana1 = txtBxYoutubeURL.Text; }
                    if (ventana == 2) { this.webBrowser2.DocumentText = string.Format(youtubeWebBrowserPlayer.HtmlPlayer()); ventana2 = txtBxYoutubeURL.Text; }
                    if (ventana == 3) { this.webBrowser5.DocumentText = string.Format(youtubeWebBrowserPlayer.HtmlPlayer()); ventana3 = txtBxYoutubeURL.Text; }
                    if (ventana == 4) { this.webBrowser6.DocumentText = string.Format(youtubeWebBrowserPlayer.HtmlPlayer()); ventana4 = txtBxYoutubeURL.Text; }
                    if (ventana == 5) { this.webBrowser3.DocumentText = string.Format(youtubeWebBrowserPlayer.HtmlPlayer()); ventana5 = txtBxYoutubeURL.Text; }
                    if (ventana == 6) { this.webBrowser4.DocumentText = string.Format(youtubeWebBrowserPlayer.HtmlPlayer()); ventana6 = txtBxYoutubeURL.Text; }
                    if (ventana == 0) MessageBox.Show("Todas las ventanas estan llenas!");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        private int ChequearVideo()
        {

            int i = 0;
            if (webBrowser1.DocumentText == "") { i = 1; }
            else if (webBrowser2.DocumentText == "") { i = 2; }
            else if (webBrowser5.DocumentText == "") { i = 3; }
            else if (webBrowser6.DocumentText == "") { i = 4; }
            else if (webBrowser3.DocumentText == "") { i = 5; }
            else if (webBrowser4.DocumentText == "") { i = 6; }
            else { i = 0; }
            return i;
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (webBrowser1.Focused == true) { webBrowser1.DocumentText = ""; }
            else if (webBrowser2.Focused == true) { webBrowser2.DocumentText = ""; }
            else if (webBrowser5.Focused == true) { webBrowser5.DocumentText = ""; }
            else if (webBrowser6.Focused == true) { webBrowser6.DocumentText = ""; }
            else if (webBrowser3.Focused == true) { webBrowser3.DocumentText = ""; }
            else if (webBrowser4.Focused == true) { webBrowser4.DocumentText = ""; }
            else { MessageBox.Show("No ha seleccionado ninguna ventana!"); }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.Sizable;
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is WebBrowser webBrowser && webBrowser.DocumentText != "")
                {
                    if (webBrowser.Name == webBrowser1.Name) { link = ventana1; }
                    if (webBrowser.Name == webBrowser2.Name) { link = ventana2; }
                    if (webBrowser.Name == webBrowser5.Name) { link = ventana3; }
                    if (webBrowser.Name == webBrowser6.Name) { link = ventana4; }
                    if (webBrowser.Name == webBrowser3.Name) { link = ventana5; }
                    if (webBrowser.Name == webBrowser4.Name) { link = ventana6; }
                    YoutubePlayer youtubeWebBrowserPlayer = new YoutubePlayer()
                    {
                        YotubeVideoURL = link,
                        Force1080HD = true,
                        Autoplay = true,
                        FullScreen = true,
                        ModestBranding = true,
                        EnablePlayerControls = true,
                        UsingWhiteProgressBar = false,
                        DisablePlayerKeyboardShortcuts = true,
                        WebBrowserControl = webBrowser1
                    };
                    webBrowser.DocumentText = string.Format(youtubeWebBrowserPlayer.HtmlPlayer());
                }
            }

            btnPlay.Visible = true;
            btnLimpiar.Visible = true;
            btnMax.Visible = true;
            btnSalir.Visible = true;
            txtBxYoutubeURL.Visible = true;
            btnInformacion.Visible = true;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Maximized;
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is WebBrowser webBrowser && webBrowser.DocumentText != "")
                {

                    if (webBrowser.Name == webBrowser1.Name) { link = ventana1; }
                    if (webBrowser.Name == webBrowser2.Name) { link = ventana2; }
                    if (webBrowser.Name == webBrowser5.Name) { link = ventana3; }
                    if (webBrowser.Name == webBrowser6.Name) { link = ventana4; }
                    if (webBrowser.Name == webBrowser3.Name) { link = ventana5; }
                    if (webBrowser.Name == webBrowser4.Name) { link = ventana6; }
                    YoutubePlayer youtubeWebBrowserPlayer = new YoutubePlayer()
                    {
                        YotubeVideoURL = link,
                        Force1080HD = true,
                        Autoplay = true,
                        FullScreen = true,
                        ModestBranding = true,
                        EnablePlayerControls = true,
                        UsingWhiteProgressBar = false,
                        DisablePlayerKeyboardShortcuts = true,
                        WebBrowserControl = webBrowser1
                    };
                    webBrowser.DocumentText = string.Format(youtubeWebBrowserPlayer.HtmlPlayer());

                }
            }
            btnPlay.Visible = false;
            btnLimpiar.Visible = false;
            btnMax.Visible = false;
            btnSalir.Visible = false;
            txtBxYoutubeURL.Visible = false;
            btnInformacion.Visible = false;
        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            string texto = "MODO DE USO:\n\nAl abrirse se cargaran 6 videos default de noticieros en Vivo.\n\n\n" +
                " - Puede seleccionar cualquier video y con el boton de limpiar se eliminara el video.\n\n" +
                " - Copie y pegue el link del video de youtube en la caja de texto, con el siguiente formato:\n\n" +
                "https://youtu.be/HPiv1pzIPRc \n\n\n" +
                " - Si tiene mas de una ventana libre, el sistema ira agregando los videos en orden.";
            MessageBox.Show(texto, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}


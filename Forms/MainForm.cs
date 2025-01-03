using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Windows.Forms;

namespace RouteTrackingApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadInitial();
        }

        private void LoadInitial()
        {
            this.Text = "Route Tracker";
            this.Width = 1000;
            this.Height = 700;

            gmap = new GMapControl
            {
                Dock = DockStyle.Fill,
                MapProvider = GMapProviders.GoogleMap,
                Position = new PointLatLng(10.8231, 106.6297),
                MinZoom = 2,
                MaxZoom = 18,
                Zoom = 10,
                ShowCenter = false
            };

            btnStartTracking.Click += btnStartTracking_Click;
            btnViewHistory.Click += btnViewHistory_Click;
            btnSettings.Click += btnSettings_Click;

            var panel = new Panel { Dock = DockStyle.Left, Width = 180 };
            panel.Controls.Add(btnStartTracking);
            panel.Controls.Add(btnViewHistory);
            panel.Controls.Add(btnSettings);

            this.Controls.Add(gmap);
            this.Controls.Add(panel);
        }

        private void btnStartTracking_Click(object sender, System.EventArgs e)
        {
            var trackingForm = new TrackingForm(gmap);
            trackingForm.ShowDialog();
        }

        private void btnViewHistory_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("View History clicked");
        }

        private void btnSettings_Click(object sender, System.EventArgs e)
        {
            var settingsForm = new SettingForm();
            settingsForm.ShowDialog();
        }
    }
}

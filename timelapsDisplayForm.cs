using System;
using System.Drawing;
using System.Windows.Forms;
using TimeTraker.Windows;
using System.Device.Location;
using System.Xml;

namespace TimeTraker {
    public partial class timelapsDisplayForm : Form {

        private readonly DailyTimeTracker dailyTimeTracker;
        private SessionChangeHandler sessionChange;
        private GeoCoordinateWatcher coordinateWatcher;
        private string employeeLocationAddress = String.Empty;
        private bool IsStartDateSet = false;
        public timelapsDisplayForm() {
            InitializeComponent();
            sessionChange = new SessionChangeHandler();
            dailyTimeTracker = new DailyTimeTracker();
            dailyTimeTracker.OnStartTimeChange += DailyTimeTracker_OnStartTimeChange;

            officeTimer.Enabled = true;
            officeTimer.Start();

            coordinateWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            coordinateWatcher.PositionChanged += GeoPositionChanged;
            coordinateWatcher.Start();

            sessionChange.MachineLocked += SessionChange_MachineLocked;
            LocateApplication();


        }

        private void GeoPositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e) {
            try {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load($"https://maps.googleapis.com/maps/api/geocode/xml?latlng={e.Position.Location.Latitude},{e.Position.Location.Longitude}&sensor=false");

                XmlNodeList xNodelst = xDoc.GetElementsByTagName("result");
                XmlNode xNode = xNodelst.Item(0);
                employeeLocationAddress = xNode.SelectSingleNode("formatted_address").InnerText;
                lblCurrentAddress.Text = $"Add: {employeeLocationAddress}";
                coordinateWatcher.Stop();
            }
            catch (Exception exception) {
                employeeLocationAddress = string.Empty;
                coordinateWatcher.Start();
            }
        }

        private void LocateApplication() {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                workingArea.Bottom - Size.Height);

        }

        private void SessionChange_MachineLocked(object sender, EventArgs e) {

            coordinateWatcher.Stop();
            coordinateWatcher.Start();
            if (employeeLocationAddress.Contains("70, Sohna Rd, Sector 48, Gurugram, Haryana 122004, India") && !IsStartDateSet) {
                dailyTimeTracker.StartOfficeTime(DateTime.Now);
                startTimePicker.Value = DateTime.Now;
                IsStartDateSet = true;
            }

        }

        private void DailyTimeTracker_OnStartTimeChange(object sender, EventArgs e) {
            lblStartTime.Text = dailyTimeTracker.StartTime.ToString("HH:mm:ss tt");
        }

        private void timelapsDisplayForm_Load(object sender, EventArgs e) {

        }

        private void startTimePicker_ValueChanged(object sender, EventArgs e) {
            dailyTimeTracker.StartOfficeTime(startTimePicker.Value);
            var exitTime = startTimePicker.Value.AddHours(7.5);
            lblExitTime.Text = $"EOD: {exitTime.ToString("h:mm tt")}";
            IsStartDateSet = true;
        }

        private void lblStartTime_Click(object sender, EventArgs e) {
            startTimePicker.Visible = true;
        }

        private void startTimePicker_Leave(object sender, EventArgs e) {
            startTimePicker.Visible = false;
        }


        private void startTimePicker_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                startTimePicker.Visible = false;
            }
        }

        private void RefreshOfficeTimeSpan() {

            var officeTime = dailyTimeTracker.CalculateOfficeTime();
            lblTimelaps.Text = officeTime.ToString("g");

            if (officeTime.Hours >= 6 && (officeTime.Hours <= 7 && officeTime.Minutes < 30)) {
                lblTimelaps.ForeColor = Color.DarkGoldenrod;
            }
            else if (officeTime.Hours >= 7 && officeTime.Minutes >= 30) {
                lblTimelaps.ForeColor = Color.DarkOliveGreen;
            }
            else {
                lblTimelaps.ForeColor = Color.OrangeRed;
            }
        }

        private void officeTimer_Tick(object sender, EventArgs e) {
            if (IsStartDateSet) {
                RefreshOfficeTimeSpan();
            }
            if (IsStartDateSet && (DateTime.Now.Day != dailyTimeTracker.StartTime.Day)) {
                IsStartDateSet = false;
            }
        }

        private void startTimePicker_VisibleChanged(object sender, EventArgs e) {

            if (startTimePicker.Visible) {
                officeTimer.Stop();

            }
            else {
                officeTimer.Start();
            }

        }

        private void btnHide_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
            timeNotification.Visible = true;
            timeNotification.ShowBalloonTip(500);
        }

        private void timeNotification_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Normal;
        }

    }
}

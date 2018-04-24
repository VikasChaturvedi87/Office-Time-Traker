using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimeTraker {
    public class DailyTimeTracker {

        public DateTime StartTime { get; set; }

        public TimeSpan TimeInOffice { get; set; }

        public event EventHandler OnStartTimeChange;

        public bool StartOfficeTime(DateTime? startDateTime = null) {

            StartTime = startDateTime ?? DateTime.Now;

            OnStartTimeChange?.Invoke(null,null);

            return true;
        }

        public bool EndOfficeTime(DateTime? endDateTime = null) {
            StartTime = endDateTime ?? DateTime.Now;
            return true;
        }

        public TimeSpan CalculateOfficeTime() {
            TimeInOffice = (DateTime.Now - StartTime);
            return TimeInOffice;
        }
    }
}

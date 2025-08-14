namespace Assignment06.Models
{
    public class VisitDetail
    {
        public int VisitID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int VisitTypeID { get; set; }
        public DateTime VisitDate { get; set; }
        public int Duration { get; set; }
        public string DoctorNotes { get; set; }
    }
}

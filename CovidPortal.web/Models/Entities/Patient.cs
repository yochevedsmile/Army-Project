namespace CovidPortal.web.Models.Entities
{
    public class Patient
    {
        public string Id { get; set; }


        public string FullName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
        public string MobilePhone { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime? CovidPositiveDate { get; set; }
        public DateTime? RecoveryDate { get; set; }

    }
}

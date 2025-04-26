namespace recruitmentAPI.Controllers
{
    public class ToDoTable
    {   
        public int id { get; set; }
        public string? tytul_zadania { get; set; }
        public string? opis { get; set; }
        public DateTime expiry_date { get; set; }
        public int completion { get; set; }
        public Boolean IsCompleted { get; set; }    

    }

    public class ToDoTableDomain
    {
        public string? tytul_zadania { get; set; }
        public string? opis { get; set; }
        public DateTime expiry_date { get; set; }
        public int completion { get; set; }
        public Boolean IsCompleted { get; set; }

    }
}

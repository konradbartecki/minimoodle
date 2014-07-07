    public partial class CzlonekGrupy 			//Relacje student-grupa to oddzielna tabela która posiada
    {
        public int id { get; set; }			//ID relacji
        public int grupaID { get; set; }		//ID grupy
        public int studentID { get; set; }		//ID studenta
    
        public virtual Grupa Grupa { get; set; }	//Odniesienie do grupy
        public virtual Student Student { get; set; }	//Odniesienie do studenta
    }

    public partial class Grupa				//Grupa posiada
    {    
        public int id { get; set; }			//Swoje ID
        public string name { get; set; }		//Swoją nazwę
        public int wykladowcaID { get; set; }		//Swojego wykładowce
    
        public virtual List<CzlonekGrupyDTO> CzlonekGrupy { get; set; }	//Listę członków grupy
        public virtual List<WykladowcaDTO> Wykladowca { get; set; }	//Listę Wykładowcę
        public virtual List<MaterialyDTO> Material { get; set; }	//Listę materiałów
        public virtual List<EgzaminyDTO> Test { get; set; }		//Listę egzaminów
    }

    public partial class Material			//Każdy materiał posiada
    {
        public int id { get; set; }			//Swoje własne ID
        public string title { get; set; }		//Tytuł
        public string text { get; set; }		//Text
        public int grupaID { get; set; }		//ID grupy do której należy
    
        public virtual Grupa Grupa { get; set; }	//Odniesienie do grupy
    }

    public partial class Ocena				//Każda ocena posiada
    {
        public int id { get; set; }			//Swoje ID
        public int value { get; set; }			//Swoją wartość, tzn. ocenę
        public int studentID { get; set; }		//ID ocenionego studenta
        public int wykladowcaID { get; set; }		//ID oceniającego wykładowcy
    
        public virtual Student Student { get; set; }	//Odniesienie do Studenta
        public virtual Wykladowca Wykladowca { get; set; }	//Odniesienie do wykładowcy
    }

    public partial class Pytanie			//Każde pytanie posiada:
    {
        public int id { get; set; }			//Swoje ID
        public string text { get; set; }		//Text pytania
        public string firstAnswer { get; set; }		//Text pierwszej odpowiedzi
        public string secondAnswer { get; set; }	//Text drugiej odpowiedzi
        public string thirdAnswer { get; set; }		//Text trzeciej odpowiedzi
        public string fourthAnswer { get; set; }	//Text czwartej odpowiedzi
        public int good { get; set; }			//ID poprawnej odpowiedzi
        public int testID { get; set; }			//ID testu do którego należy
    
        public virtual Test Test { get; set; }		//Odniesienie do testu
    }

    public partial class Student			//Każdy student posiada:
    {
     	public int id { get; set; }			//Swoje ID
        public string name { get; set; }		//Imie
        public string surname { get; set; }		//Nazwisko
        public string password { get; set; }		//Haslo logowania
        public string email { get; set; }		//Email
        public string username { get; set; }		//Nazwe uzytkownika
    
        public virtual List<CzlonekGrupyDTO> CzlonekGrupy { get; set; }	//Liste relacji student-grupa
        public virtual ICollection<Ocena> Ocena { get; set; }		//Kolekcję ocen
    }

    public partial class Test				//Każdy test posiada
    {
        public int id { get; set; }			//Swoje ID
        public string name { get; set; }		//Swoją nazwę
        public int grupaID { get; set; }		//ID grupy do której należy
        public int wykladowcaID { get; set; }		//ID oceniającego wykładowcy
    
        public virtual Grupa Grupa { get; set; }	//Odniesienie do grupy
        public virtual List<PytaniaDTO> Pytanie { get; set; }	//Listę pytań
        public virtual Wykladowca Wykladowca { get; set; }	//Odniesienie do wykładowcy
    }

    public partial class Wykladowca			//Każdy wykładowca posiada
    {
        public int id { get; set; }			//Swoje ID
        public string name { get; set; }		//Imie
        public string surname { get; set; }		//Nazwisko
        public string password { get; set; }		//Haslo
        public string email { get; set; }		//Email
        public string username { get; set; }		//Nazwe uzytkownika
    
        public virtual ICollection<Grupa> Grupa { get; set; }	//Kolekcje grup
        public virtual ICollection<Test> Test { get; set; }	//Kolekcje testów
        public virtual ICollection<Ocena> Ocena { get; set; }	//Kolekcje ocen
    }
        static EndpointAddress endpoint = new EndpointAddress("http://localhost:8732/StreamingService.Service");
        static ServiceClient client = new ServiceClient("WSHttpBinding_IService", endpoint);

        ObservableCollection<StudenciViewModel> studenciGrupy = new ObservableCollection<StudenciViewModel>();
        ObservableCollection<EgzaminyViewModel> testyGrupy = new ObservableCollection<EgzaminyViewModel>();
        ObservableCollection<MaterialyViewModel> materialyGrupy = new ObservableCollection<MaterialyViewModel>();        

protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)  //Podobnie jak MaterialView.xaml.cs
        {
            base.OnNavigatedTo(e);
            string username = NavigationContext.QueryString["username"];
            string grupaID = NavigationContext.QueryString["groupID"];



            client.GetGrupaAsync(Convert.ToInt32(grupaID));
            client.GetStudentAsync(username);

            PopulateUI();
        }

        private async void PopulateUI()
        {
            await GetGrupaSignal.WaitAsync();			//Zaczekaj na wczytanie obiektu grupy
            PivotControl.Title = grupa.name;			//Ustaw tytuł strony zgodnie z nazwą grupy

            studenciGrupy.Clear();				//Upewnij się że ObservableCollection studenciGrupy jest puste
            foreach(var item in grupa.CzlonekGrupy)		//Dla każdego elementu "item" w liscie członków grupy w obiekcie "grupa"
            {
                client.GetStudentByIDAsync(item.studentID);	//Pobierz info o studencie grupy
                await StudenciGrupySignal.WaitAsync();		//Zaczekaj na pobranie informacji o studencie grupy
                studenciGrupy.Add(new StudenciViewModel		//Dodaj nowy element w studenciGrupy zgodnie z StudenciViewModel
                {
                    fullName = studentCzlonekGrupy.name + " " + studentCzlonekGrupy.surname,
                    id = studentCzlonekGrupy.id,
                    name = studentCzlonekGrupy.name,
                    surname = studentCzlonekGrupy.surname
                });
                studentCzlonekGrupy = null;			//Wyczyść obiekt studentCzlonekGrupy
            }
            StudenciLongListSelector.ItemsSource = studenciGrupy;	//Pokaż liste studentów w interfejsie użytkownika

            //Populate Materialy
            materialyGrupy.Clear();
            materialyGrupy.Add(new MaterialyViewModel
            {
                id = 0,
                title = "Dodaj",
                text = "Utwórz nowy materiał"
            });
            foreach (var item in grupa.Material)		//Dla każdego materiału w grupie
            {
                string desc = item.desc.Replace("<p>", "");	//Usuń formatowanie HTML (przygotowanie do wyświetlenia w opisie)
                materialyGrupy.Add(new MaterialyViewModel
                    {
                        id = item.id,
                        title = item.title,
                        text = TruncString(desc, 40)		//Skróć opis do 40 znaków
                    });
            }

            MaterialyLongListSelector.ItemsSource = materialyGrupy;	//Pokaż liste materiałów w interfejsie użytkownika

            //Populate Egzaminy
            testyGrupy.Clear();
            foreach (var item in grupa.Test)
            {
                testyGrupy.Add(new EgzaminyViewModel
                {
                    egzaminID = item.egzaminID,
                    nazwaEgzaminu = item.nazwaEgzaminu,
                    grupaID = item.grupaID,
                    wykladowcaID = item.wykladowcaID
                });
            }
            TestyLongListSelector.ItemsSource = testyGrupy;
        }

        void client_GetStudentByIDCompleted(object sender, GetStudentByIDCompletedEventArgs e)
        {
            studentCzlonekGrupy = e.Result;
            StudenciGrupySignal.Release();
        }
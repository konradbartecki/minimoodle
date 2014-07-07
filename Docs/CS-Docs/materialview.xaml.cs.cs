Nawigacja do MaterialyView.xaml.cs
        "/Views/MaterialyView.xaml?materialID=2&groupID=3"

protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            int materialID = Convert.ToInt32(NavigationContext.QueryString["materialID"]); 	//Wczytaj materialID z kontekstu nawigacji - 2
            string grupaID = NavigationContext.QueryString["groupID"];			   	//Wczytaj groupID z kontekstu nawigacji - 3
            client.GetGrupaAsync(Convert.ToInt32(grupaID));					//Wczytaj obiekt grupy korzystając z wczytanego ID
            populateUI(materialID); 								//Wypełnij interfejs użytkownika
        }

private async void populateUI(int materialID)
        {
            await GetGrupaSignal.WaitAsync();							//Poczekaj na wczytanie obiektu grupy

            MaterialyViewModel material = new MaterialyViewModel();				//Utwórz nowy ViewModel
            material = (from p in grupa.Material						//Znajdź "p" w obiekcie grupa w liscie materiałów
                        where p.id == materialID						//gdzie "p.id" zgadza się z podanym ID materiału z konekstu nawigacji
                        select new MaterialyViewModel						//Utwórz z tego nowy ViewModel
                        {
                            id = p.id,
                            text = p.desc,
                            title = p.title
                        }).FirstOrDefault();


            PageTitle.Text = "Materiał grupy " + grupa.name;					//Wypełnij tytuł strony materiału
            PageHeader.Text = material.title;							//Wypełnij nagłówek strony materiału
            WebTextHelper webTextHelper = new WebTextHelper();					//Nowa instancja WebTextHelper
            webTextHelper.buildHTMLPage(material.text, WebControl);				//Zbuduj strone web w opraciu o text materiału
        }
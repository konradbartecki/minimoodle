        public Student GetStudentByID(int studentID) 
        { 
            Moodle3Entities db = new Moodle3Entities();  	//Ustanawia połączenie z bazą danych 
            var studentEntity = (from p 		 	//z obiektu p 
                                 in db.Student 		 	//w tablicy studentów 
                                 where p.id == studentID 	//gdzie p.id równa się podanemu ID 
                                 select p).FirstOrDefault();    //wybierz p 
            if (studentEntity != null) 				//jesli student nie jest pusty 
                return TranslateStudentEntityToStudent(studentEntity); 
            else 
                throw new Exception("Zła nazwa użytkownika"); 
        } 

        private Student TranslateStudentEntityToStudent(Student studentEntity) 
        { 
            Student student = new Student(); 
            student.id = studentEntity.id; 
            student.name = studentEntity.name; 
            student.surname = studentEntity.surname; 
            student.username = studentEntity.username; 
            student.password = studentEntity.password; 
            student.email = studentEntity.email; 
            student.CzlonekGrupy = GetCzlonekGrup(student.id); 
            return student; 
        }
using System;

namespace UserApp
{
    class User
    {
        #region FIELDS
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _placeOfBirth;
        #endregion

        #region PROPERTIES
        public string FirstName { get => _firstName; }
        public string LastName { get => _lastName; }
        public DateTime DateOfBirth { get => _dateOfBirth; }
        public string PlaceOfBirth { get => _placeOfBirth; }
        #endregion

        #region CONSTRUCTORS
        public User(string firstName, string lastName, DateTime dateOfBirth, string placeOfBirth)
        {
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
            _placeOfBirth = placeOfBirth;
        }
        public User()
        {
            _firstName = getFirstNameFromUser();
            _lastName = getLastNameFromUser();
            _dateOfBirth = getDateOfBirthFromUser();
            _placeOfBirth = getPlaceOfBirthUser();
        }
        #endregion

        #region METHODS
        private string getFirstNameFromUser()
        {
            Console.Write("Podaj imie:\n> ");
            return Console.ReadLine();
        }
        private string getLastNameFromUser()
        {
            Console.Write("Podaj nazwisko:\n> ");
            return Console.ReadLine();
        }
        private string getPlaceOfBirthUser()
        {
            Console.Write("Podaj miejsce urodzin:\n> ");
            return Console.ReadLine();
        }
        private string getDayOfBirthFromUser()
        {
            Console.Write("Podaj dzień urodzin:\n> ");
            return Console.ReadLine();
        }
        private string getMonthOfBirthFromUser()
        {
            Console.Write("Podaj miesiąc urodzin:\n> ");
            return Console.ReadLine();
        }
        private string getYearOfBirthFromUser()
        {
            Console.Write("Podaj rok urodzin:\n> ");
            return Console.ReadLine();
        }
        private DateTime getDateOfBirthFromUser()
        {
            int day = 0;
            int month = 0; 
            int year = 0;
            do
            {
                if (!int.TryParse(getDayOfBirthFromUser(), out day))
                {
                    Console.WriteLine("Nieprawidłowe dane. Proszę podać poprawny dzień urodzin!");
                    continue;
                }
                if(!this.isDayValid(day))
                {
                    Console.WriteLine("Nieprawidłowe dane. Proszę podać poprawny dzień urodzin!");
                    day = 0;
                }
            } while (day == 0);
            do
            {
                if (!int.TryParse(getMonthOfBirthFromUser(), out month))
                {
                    Console.WriteLine("Nieprawidłowe dane. Proszę podać poprawny miesiąc urodzin!");
                    continue;
                }
                if (!this.isMonthValid(month))
                {
                    Console.WriteLine("Nieprawidłowe dane. Proszę podać poprawny miesiąc urodzin!");
                    month = 0;
                }
            } while (month == 0);
            do
            {
                if (!int.TryParse(getYearOfBirthFromUser(), out year))
                {
                    Console.WriteLine("Nieprawidłowe dane. Proszę podać poprawny rok urodzin!");
                    continue;
                }
                if (!this.isYearValid(year))
                {
                    Console.WriteLine("Nieprawidłowe dane. Proszę podać poprawny rok urodzin!");
                    year = 0;
                }
            } while (year == 0);
            try
            {
                return new DateTime(year, month, day);
            }
            catch(Exception e)
            {
                //Console.WriteLine(e.Message);
                Console.WriteLine("Podana data nie istnieje! Proszę podać poprawną datę.");
                return getDateOfBirthFromUser();
            }
        }
        public void Show()
        {
            Console.WriteLine($"Cześć {this._firstName} {this._lastName}, urodziłeś się w {this._placeOfBirth} i masz {calculateAge()} lat.");
        }
        private int calculateAge()
        {
            var age = DateTime.Now.Year - this._dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < this._dateOfBirth.DayOfYear) age = age - 1;
            return age;
        }
        #endregion

        #region VALIDATORS
        private bool isDayValid(int day)
        {
            if (day > 0 && day <= 31) return true;
            else return false;
        }
        private bool isMonthValid(int month)
        {
            if (month > 0 && month <= 12) return true;
            else return false;
        }
        private bool isYearValid(int year)
        {
            if (year <= DateTime.Now.Year) return true;
            else return false;
        }
        #endregion
    }
}

using System.Runtime.CompilerServices;

namespace Password_Validator // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PasswordValidator passwordValidator = new PasswordValidator();
            
            while (true)
            {
                Console.WriteLine("enter password:");
                string userPassword = Console.ReadLine();
                Console.WriteLine($"Validator said {passwordValidator.ValidPassword(userPassword)}");
            }

        }
    }

    

    public class PasswordValidator
    {
        

        public bool ValidPassword(string password)
        {
            return ValidLength(password) && ValidCharacters(password);
        }

        private bool ValidLength(string password)
        {
            return password.Length >= 6 && password.Length <= 13;
        }

        private bool ValidCharacters(string password)
        {
            bool foundUpper = false,foundLower= false,foundNumber= false,foundCapT= false,foundAmpersand= false;

            foreach (var letter in password)
            {
                if (char.IsUpper(letter)) foundUpper = true;
                if (char.IsLower(letter)) foundLower = true;
                if (char.IsNumber(letter)) foundNumber = true;
                if (letter == 'T') foundCapT = true;
                if (letter == '&') foundAmpersand = true;
            }


            return (foundUpper && foundLower && foundNumber && (!foundCapT && !foundAmpersand));

        }
        
        
        
        
        
        
        
        
        
    }
    
    
    
    
    
    
    
    
    
    
    
}
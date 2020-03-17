using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcnew.Models
{
    public class validationcls
    {
        string firstname;
        string lastname;
        double salary;
        string pancard;
        string password;
        string cpassword;
        string phone;
        string mail;
        DateTime doj;        

        [Required(ErrorMessage ="first name not entered")]
        [StringLength(maximumLength:25,ErrorMessage ="Maximum length is 25")]
        public string Firstname { get => firstname; set => firstname = value; }

        [Required(ErrorMessage = "last name not entered")]
        public string Lastname { get => lastname; set => lastname = value; }
        [Required(ErrorMessage ="salary not entered")]
        [Range(1000,20000,ErrorMessage ="salary not in range")]
        public double Salary { get => salary; set => salary = value; }

        [Required(ErrorMessage = "pancard not entered")]
        [RegularExpression("^[A-Z]{5}[0-9]{4}[A-Z]$", ErrorMessage = "pancard not correct")]
        public string Pancard { get => pancard; set => pancard = value; }

        [Required(ErrorMessage = "password not entered")]
        public string Password { get => password; set => password = value; }

        [Required(ErrorMessage = "password not entered")]
        [Compare("Password", ErrorMessage = "password mismatch")]
        public string Cpassword { get => cpassword; set => cpassword = value; }

        [Required(ErrorMessage = "phone not entered")]
        [MinLength(10,ErrorMessage = "phone no should be 10")]
        [MaxLength(10,ErrorMessage = "phone no should be 10")]
        public string Phone { get => phone; set => phone = value; }

        [Required(ErrorMessage = "email not entered")]
        [EmailAddress(ErrorMessage = "email not valid")]
        public string Mail { get => mail; set => mail = value; }

        [Required(ErrorMessage = "date of joining not entered")]
        [customDOJ]
        //[customage(ErrorMessage = "age must be between 21-58")]
        public DateTime Doj { get => doj; set => doj = value; }

        
        
    }
}
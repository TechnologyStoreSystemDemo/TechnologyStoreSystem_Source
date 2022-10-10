using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ViewModels.Commands;

using Models;

namespace ViewModels
{
    public class LoginVM : BaseVM
    {
        private EmployeeAccount? employeeAccount;

        public EmployeeAccount? EmployeeAccount
        {
            get { return employeeAccount; }
            set
            {
                employeeAccount = value;
                OnPropertyChanged("EmployeeAccount");
            }
        }

        private string? _Email;

        public string? Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                EmployeeAccount = new EmployeeAccount
                {
                    StrEmail = _Email,
                    StrPassword = SecureStringConvectToString(Password)
                };
                OnPropertyChanged("Email");
            }
        }

        private SecureString _Password;

        public SecureString Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                EmployeeAccount = new EmployeeAccount
                {
                    StrEmail = Email,
                    StrPassword = SecureStringConvectToString(_Password)
                };
                OnPropertyChanged("Password");
            }
        }
        public ICommand LoginCommands { get; set; }
        public ICommand CloseCommands { get; set; }
        public ICommand MouseDownCommands { get; set; }

        public LoginVM()
        {
            EmployeeAccount = new EmployeeAccount();
            LoginCommands = new RelayCommands<object>(
                p =>
                {
                    Login();
                },
                p =>
                {
                    if (EmployeeAccount == null)
                    {
                        return false;
                    }
                    if (string.IsNullOrEmpty(EmployeeAccount.StrEmail))
                    {
                        return false;
                    }
                    if (EmployeeAccount.StrPassword == null)
                    {
                        return false;
                    }
                    return true;
                });
            CloseCommands = new RelayCommands<Window>(
                p =>
                {
                    p.Close();
                },
                p =>
                {
                    return p != null;
                });

            MouseDownCommands = new RelayCommands<Window>(
            p =>
            {
                p.DragMove();
            });
        }

        private void Login()
        {
            MessageBox.Show("Email: " + Email +
                            "\nPassword: " + Password
                            );
        }

        private string SecureStringConvectToString(SecureString pass)
        {
            //if (pass == null)
            //{
            //	throw new ArgumentNullException("pass");
            //}

            return new NetworkCredential(null, pass).Password;
        }
    }
}

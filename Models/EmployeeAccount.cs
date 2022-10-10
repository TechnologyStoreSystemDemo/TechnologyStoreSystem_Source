using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;

namespace Models
{
    public class EmployeeAccount
    {
        private string? _StrEmpId;
        [Key, Column("EmpId", Order = 0, TypeName = "varchar"), MaxLength(8)]
        public string? StrEmpId
        {
            get { return _StrEmpId; }
            set { _StrEmpId = value; }
        }

        private string? _StrEmail;
        [Column("Email", Order = 1, TypeName = "varchar"), MaxLength(50)]
        public string? StrEmail
        {
            get => _StrEmail;
            set { _StrEmail = value; }
        }

        private string? _StrPassword;
        [Column("Password", Order = 2, TypeName = "varchar"), MaxLength(50)]
        public string? StrPassword
        {
            get => _StrPassword;
            set { _StrPassword = value; }
        }
    }
}

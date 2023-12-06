using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace WpfDatabaseSqlite
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Address { get; set; }
    }
}
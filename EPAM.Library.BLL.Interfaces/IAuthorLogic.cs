using EPAM.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Library.BLL.Interfaces
{
    public interface IAuthorLogic
    {
        Guid Add(Author author);
        IEnumerable<Author> GetAll();
    }
}

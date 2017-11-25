using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollment.Repositories.Theatre
{
    public interface ITheatre
    {

        Task AddTheatre(Models.Theatre thea);
        Task<IEnumerable<Models.Theatre>> GetTheatres();

    }
}

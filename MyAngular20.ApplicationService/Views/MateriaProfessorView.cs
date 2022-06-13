using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService.Views
{
   public class MateriaProfessorView : ViewBase
    {
        public int MateriaId { get; set; }
        public int ProfessorId { get; set; }
    }

    public interface IMateriaProfessorFacade : IViewFacade<MateriaProfessorView> { }
}

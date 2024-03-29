﻿namespace MyAngular20.ApplicationService.Views
{
    public class ProfessorView : ViewBase
    {
        public string Nome { get; set; }
        public int[] MateriasIds { get; set; }
    }

    public interface IProfessorFacade : IViewFacade<ProfessorView> { }
}

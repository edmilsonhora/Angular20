﻿namespace MyAngular20.ApplicationService.Views
{
    public class MateriaView:ViewBase
    {
        public string Nome { get; set; }
    }

    public interface IMateriaFacade : IViewFacade<MateriaView> { }
}
using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Interop;

namespace PruebaTecnica.Interfaces
{
    //interfas para configurar la plataforma y el directorio en android y ios
    public interface IConfi
    {
        string DirectorioBD { get; }
        ISQLitePlatform Plataforma { get; }
    }
}

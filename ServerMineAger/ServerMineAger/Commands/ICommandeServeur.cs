using System;
using System.Collections.Generic;
using System.Text;

namespace ServerMineAger.Commands
{
    public interface ICommandeServeur
    {
        string Nom { get; }

        void Executer();
        void Annuler();
    }
}

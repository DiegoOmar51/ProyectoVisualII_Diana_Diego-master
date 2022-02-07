using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Salario
    {
        public enum estadoSalario { Pendiente,Aprobado,Anulado }
        public int SalarioId { get; set; }
        //Relacion con personal 
        public int? PersonalId { get; set; }
        public Personal Personal { get; set; }
        public float SueldoBasico { get; set; }
        public float DecimoTercerSueldo { get; set; }
        public float DecimoCuartoSueldo { get; set; }
        public float Utilidades { get; set; }

        public estadoSalario EstadoSal { get; set; }
        //REFERNCIA CON DECIMO TERCERO
        public Decimo_Tercero decterceros { get; set; }
        //REFERNCIA CON roles

        public Roles roles { get; set; }
    }
}

using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Operaciones
{
    public class CalcCalificaciones
    {
        /*public float peso1 { get; set; }
        public float peso2 { get; set; }
        public float peso3 { get; set; }
        public float notaMinima { get; set; }

        public CalcCalificaciones(Configuracion configuracion)
        {
            this.peso1 = configuracion.PesoNota1;
            this.peso2 = configuracion.PesoNota2;
            this.peso3 = configuracion.PesoNota3;
            this.notaMinima = configuracion.NotaMinima;
        }

        public float NotaFinal(Calificacion calificacion)
        {
            float respuesta;

            respuesta =
                calificacion.Nota1 * peso1 +
                calificacion.Nota2 * peso2 +
                calificacion.Nota3 * peso3;

            respuesta = (float) Math.Round((double) respuesta, 2);

            return respuesta;
        }

        public bool Aprobado(Calificacion calificacion)
        {
            return NotaFinal(calificacion) >= notaMinima;
        }*/
    }
}

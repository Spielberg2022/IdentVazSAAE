using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentificaVazSAAE.Domínio
{
    public class ClassVerificaVazamento_Dom
    {
        public DataTable leituras { get; set; }
        public DataTable vazamentos { get; set; }
        public string dataRef { get; set; }
        public double consumoAtual { get; set; }
        public double valorConta { get; set; }
        public Int64 ligacao { get; set; }
        public DataTable rol { get; set; }
        public double consumoPadraoMaximo { get; set; }
        public double mediaGeral { get; set; }
        public DataTable modaGeral { get; set; }
        public double desvioPadraoGeral { get; set; }
        public double mediaJan { get; set; }
        public double mediaFev { get; set; }
        public double mediaMar { get; set; }
        public double mediaAbr { get; set; }
        public double mediaMai { get; set; }
        public double mediaJun { get; set; }
        public double mediaJul { get; set; }
        public double mediaAgo { get; set; }
        public double mediaSet { get; set; }
        public double mediaOut { get; set; }
        public double mediaNov { get; set; }
        public double mediaDez { get; set; }
        public double mediault3meses { get; set; }
        public DataTable mMensais { get; set; }
        public double consumoMaximo { get; set; }
        public double consumoMinimo { get; set; }

    }
}

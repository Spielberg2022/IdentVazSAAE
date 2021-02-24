using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using IdentificaVazSAAE.Persistência;
using IdentificaVazSAAE.Domínio;

namespace IdentificaVazSAAE.Aplicação
{
    public class ClassVerificaVazamento_Apl
    {
		public SqlConnection connection = new SqlConnection();
		public ClassVerificaVazamento_Per verificaVazamento_Per = new ClassVerificaVazamento_Per();
		public ClassVerificaVazamento_Dom verificaVazamento_Dom = new ClassVerificaVazamento_Dom();
		public string erro;
		public bool vf;

		public DataTable ListaLeituras(ClassVerificaVazamento_Dom vazamento_Dom)
        {
			verificaVazamento_Per.sqlConnection = connection;
			vazamento_Dom.leituras = verificaVazamento_Per.LocalizarLigacao(vazamento_Dom);
			verificaVazamento_Dom.leituras = vazamento_Dom.leituras;
			return vazamento_Dom.leituras;
		}

        public DataTable ListaRol(ClassVerificaVazamento_Dom vazamento_Dom)
        {
			verificaVazamento_Per.sqlConnection = connection;
			vazamento_Dom.rol = verificaVazamento_Per.ListaRol(vazamento_Dom);
			verificaVazamento_Dom.rol = vazamento_Dom.rol;
			return vazamento_Dom.rol;
		}

        public string MediaJan(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaJan = verificaVazamento_Per.CalcMediaJan(vazamento_Dom);
            verificaVazamento_Dom.mediaJan = vazamento_Dom.mediaJan;
            return vazamento_Dom.mediaJan.ToString();
        }

        public string MediaFev(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaFev = verificaVazamento_Per.CalcMediaFev(vazamento_Dom);
            verificaVazamento_Dom.mediaFev = vazamento_Dom.mediaFev;
            return vazamento_Dom.mediaFev.ToString();
        }

        public object ListaModa(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.modaGeral = verificaVazamento_Per.ModaGeral(vazamento_Dom);
            verificaVazamento_Dom.modaGeral = vazamento_Dom.modaGeral;
            return vazamento_Dom.modaGeral;
        }

        public string MediaMar(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaMar = verificaVazamento_Per.CalcMediaMar(vazamento_Dom);
            verificaVazamento_Dom.mediaMar = vazamento_Dom.mediaMar;
            return vazamento_Dom.mediaMar.ToString();
        }

        public string MediaAbr(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaAbr = verificaVazamento_Per.CalcMediaAbr(vazamento_Dom);
            verificaVazamento_Dom.mediaAbr = vazamento_Dom.mediaAbr;
            return vazamento_Dom.mediaAbr.ToString();
        }

        public string MediaMai(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaMai = verificaVazamento_Per.CalcMediaMai(vazamento_Dom);
            verificaVazamento_Dom.mediaMai = vazamento_Dom.mediaMai;
            return vazamento_Dom.mediaMai.ToString();
        }

        public double VerConsumoMinimo(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.consumoMinimo = verificaVazamento_Per.ConsumoMinimoFaturado(vazamento_Dom);
            verificaVazamento_Dom.consumoMinimo = vazamento_Dom.consumoMinimo;
            return vazamento_Dom.consumoMinimo;
        }

        public double VerMediaUlt3Meses(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediault3meses = verificaVazamento_Per.MediaUlt3Meses(vazamento_Dom);
            verificaVazamento_Dom.mediault3meses = vazamento_Dom.mediault3meses;
            return vazamento_Dom.mediault3meses;
        }

        public double VerDesvioPadrao(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.desvioPadraoGeral = verificaVazamento_Per.DesvioPadrao(vazamento_Dom);
            verificaVazamento_Dom.desvioPadraoGeral = vazamento_Dom.desvioPadraoGeral;
            return vazamento_Dom.desvioPadraoGeral;
        }

        public bool verificaUltConta()
        {
            if(verificaVazamento_Dom.leituras.Rows.Count > 0)
            {
                var temp = verificaVazamento_Dom.leituras.Rows.Count - 1;
                var variacaoMaximaContaAnterior = double.Parse(verificaVazamento_Dom.leituras.Rows[temp - 1][4].ToString()) + verificaVazamento_Dom.desvioPadraoGeral;
                verificaVazamento_Dom.consumoAtual = double.Parse(verificaVazamento_Dom.leituras.Rows[temp][4].ToString());
                verificaVazamento_Dom.dataRef = verificaVazamento_Dom.leituras.Rows[temp][0].ToString();
                if (double.Parse(verificaVazamento_Dom.leituras.Rows[temp][4].ToString()) > verificaVazamento_Dom.consumoPadraoMaximo && double.Parse(verificaVazamento_Dom.leituras.Rows[temp][4].ToString()) > variacaoMaximaContaAnterior)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public DataTable verificaVazamentos(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            verificaVazamento_Dom.vazamentos = verificaVazamento_Per.VerificaVazamentos(vazamento_Dom);
            return verificaVazamento_Dom.vazamentos;
        }

        public double VerConsumoPadraoMax(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.consumoPadraoMaximo = vazamento_Dom.desvioPadraoGeral + vazamento_Dom.mediaGeral;
            verificaVazamento_Dom.consumoPadraoMaximo = vazamento_Dom.consumoPadraoMaximo;
            return vazamento_Dom.consumoPadraoMaximo;
        }

        public double VerMediaGeral(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaGeral = verificaVazamento_Per.MediaGeral(vazamento_Dom);
            verificaVazamento_Dom.mediaGeral = vazamento_Dom.mediaGeral;
            return vazamento_Dom.mediaGeral;
        }

        public double SimulaValorConta(ClassVerificaVazamento_Dom vazamento_Dom, int linhaTabVazamento, double consumoAFaturar)
        {
            verificaVazamento_Per.sqlConnection = connection;
            string dataRef = vazamento_Dom.vazamentos.Rows[linhaTabVazamento][0].ToString().Substring(3, 4) + vazamento_Dom.vazamentos.Rows[linhaTabVazamento][0].ToString().Substring(0,2);
            vazamento_Dom.valorConta = verificaVazamento_Per.ValorConta(vazamento_Dom, dataRef, consumoAFaturar);
            verificaVazamento_Dom.valorConta = vazamento_Dom.valorConta;
            return vazamento_Dom.valorConta;
        }

        public double SimulaValorConta(ClassVerificaVazamento_Dom vazamento_Dom, int linhaTabVazamento)
        {
            verificaVazamento_Per.sqlConnection = connection;
            string dataRef = vazamento_Dom.vazamentos.Rows[linhaTabVazamento][0].ToString().Substring(3, 4) + vazamento_Dom.vazamentos.Rows[linhaTabVazamento][0].ToString().Substring(0, 2);
            vazamento_Dom.valorConta = verificaVazamento_Per.ValorConta(vazamento_Dom, dataRef);
            verificaVazamento_Dom.valorConta = vazamento_Dom.valorConta;
            return vazamento_Dom.valorConta;
        }

        public double VerConsumoMaximo(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.consumoMaximo = verificaVazamento_Per.ConsumoMaximoFaturado(vazamento_Dom);
            verificaVazamento_Dom.consumoMaximo = vazamento_Dom.consumoMaximo;
            return vazamento_Dom.consumoMaximo;
        }

        public string MediaJun(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaJun = verificaVazamento_Per.CalcMediaJun(vazamento_Dom);
            verificaVazamento_Dom.mediaJun = vazamento_Dom.mediaJun;
            return vazamento_Dom.mediaJun.ToString();
        }

        public string MediaJul(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaJul = verificaVazamento_Per.CalcMediaJul(vazamento_Dom);
            verificaVazamento_Dom.mediaJul = vazamento_Dom.mediaJul;
            return vazamento_Dom.mediaJul.ToString();
        }

        public string MediaSet(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaSet = verificaVazamento_Per.CalcMediaSet(vazamento_Dom);
            verificaVazamento_Dom.mediaSet = vazamento_Dom.mediaSet;
            return vazamento_Dom.mediaSet.ToString();
        }

        public string MediaNov(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaNov = verificaVazamento_Per.CalcMediaNov(vazamento_Dom);
            verificaVazamento_Dom.mediaNov = vazamento_Dom.mediaNov;
            return vazamento_Dom.mediaNov.ToString();
        }

        public string MediaDez(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaDez = verificaVazamento_Per.CalcMediaDez(vazamento_Dom);
            verificaVazamento_Dom.mediaDez = vazamento_Dom.mediaDez;
            return vazamento_Dom.mediaDez.ToString();
        }

        public string MediaOut(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaOut = verificaVazamento_Per.CalcMediaOut(vazamento_Dom);
            verificaVazamento_Dom.mediaOut = vazamento_Dom.mediaOut;
            return vazamento_Dom.mediaOut.ToString();
        }

        public string MediaAgo(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            verificaVazamento_Per.sqlConnection = connection;
            vazamento_Dom.mediaAgo = verificaVazamento_Per.CalcMediaAgo(vazamento_Dom);
            verificaVazamento_Dom.mediaAgo = vazamento_Dom.mediaAgo;
            return vazamento_Dom.mediaAgo.ToString();
        }

        public DataTable PreencheTabelaMediasMensais(ClassVerificaVazamento_Dom vazamento_Dom)
        {
            DataTable mMedias = new DataTable();
            mMedias = verificaVazamento_Per.mMensais(vazamento_Dom);
            return mMedias;
        }
    }
}

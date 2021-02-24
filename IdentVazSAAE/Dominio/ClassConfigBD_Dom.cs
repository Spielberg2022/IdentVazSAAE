namespace IdentificaVazSAAE.Domínio
{
    public class ClassConfigBD_Dom
    {
        public string Servidor { get; set; }
        public string Instância { get; set; }
        public string Usuário { get; set; }
        public string Senha { get; set; }
        public string Bd { get; set; }
        public string Diretório { get; set; }
        public string BdOriginal { get; set; }
        public string Destino { get; set; }

        private string _autenticação;
        public string Autenticação
        {
            get { return _autenticação; }
            set
            {
                _autenticação = value;
                if (_autenticação == "Autenticação do Windows")
                {
                    _autenticação = "Windows";
                }
                else
                {
                    _autenticação = "SQL";
                }
            }
        }
    }
}

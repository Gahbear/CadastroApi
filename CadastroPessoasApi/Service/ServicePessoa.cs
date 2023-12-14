using CadastroPessoasApi.Data;
using CadastroPessoasApi.ViewModel;

namespace CadastroPessoasApi.Service
{
    public class ServicePessoa
    {
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var repository = new Repository();
            return repository.GetAll().ToList();
        }
        public PessoaViewModel GetById(int pessoaId)
        {
            var repository = new Repository();
            return repository.GetById(pessoaId);
        }
        public PessoaViewModel GetByprimeiroNome(string primeiroNome)
        {
            var repository = new Repository();
            return repository.GetByprimeiroNome(primeiroNome);
        }
        public void Update(int pessoaId, string primeiroNome)
        {
            if (pessoaId > 0 && !string.IsNullOrEmpty(primeiroNome))
            {
                var repository = new Repository();
                repository.Update(pessoaId, primeiroNome);
            }

        }

        public string Create(PessoaViewModel pessoa)
        {
            if (pessoa == null)
                return "Os dados são obrigatorios";


            if (pessoa != null && string.IsNullOrEmpty(pessoa.nomeMeio))
                return "O campo nomeMeio é obrigatório";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.ultimoNome))
                return "O campo ultimoNome é obrigatório";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.CPF))
                return "O campo CPF é obrigatório";

            var repository = new Repository();
            return repository.Create(pessoa);


        }
    }
}

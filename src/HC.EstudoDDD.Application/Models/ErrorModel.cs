namespace HC.EstudoDDD.Application.Models
{
    public class ErrorModel
    {
        public List<string> Erros { get; }

        public ErrorModel(string erro)
        {
            Erros.Add(erro);
        }

        public ErrorModel(IEnumerable<string> erros)
        {
            Erros.AddRange(erros);
        }
    }
}

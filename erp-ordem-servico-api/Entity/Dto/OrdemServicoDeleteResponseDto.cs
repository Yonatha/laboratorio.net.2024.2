namespace LaboratorioDev.Entity.Dto
{
    public class OrdemServicoDeleteResponseDto
    {
        public List<string> Falha { get; set; }
        public List<int> Sucesso { get; set; }

        public OrdemServicoDeleteResponseDto()
        {
            Falha = new List<string>();
            Sucesso = new List<int>();
        }

        public void AddFailure(int numero, string errorMessage)
        {
            Falha.Add(errorMessage);
        }

        public void AddSuccess(int numero)
        {
            Sucesso.Add(numero);
        }
    }

}
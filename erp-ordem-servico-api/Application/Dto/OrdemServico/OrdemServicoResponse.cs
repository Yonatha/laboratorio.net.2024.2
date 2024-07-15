namespace erp_ordem_servico_api.Dto.OrdemServico
{
    public record OrdemServicoResponse
{
    public int Id { get; init; }
    public string Descricao { get; init; }

    public OrdemServicoResponse() { }

    public OrdemServicoResponse(int id, string descricao)
    {
        Id = id;
        Descricao = descricao;
    }
}

}
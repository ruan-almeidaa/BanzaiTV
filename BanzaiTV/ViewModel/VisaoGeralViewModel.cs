namespace BanzaiTV.ViewModel
{
    public class VisaoGeralViewModel
    {
        public int QuantidadeClientes { get; set; }
        public int QuantidadeMensalidadesAtrasadasMesAtual { get; set; }
        public int QuantidadeMensalidadesPendentesMesAtual { get; set; }
        public int QuantidadeMensalidadesPagasMesAtual { get; set; }
        public double ValorReceberMesAtual { get; set; }
        public int QuantidadeMensalidadesAtrasadas{ get; set; }
        public int QuantidadeMensalidadesPendentes{ get; set; }
        public int QuantidadeMensalidadesPagas{ get; set; }
        public double ValorReceber { get; set; }
    }
}

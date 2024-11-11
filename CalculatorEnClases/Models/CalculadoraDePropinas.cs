namespace CalculatorEnClases.Models
{
    public static class CalculadoraDePropinas
    {
        public static decimal Propina(decimal importe, decimal porcentajeDePropina)
        {
            return importe * porcentajeDePropina / 100;
        }

        public static decimal PropinaPorPersona(decimal importe,decimal numeroDePersonas ,decimal porcentajeDePropina )
        {
            return Propina(importe,porcentajeDePropina)/numeroDePersonas;
        }

        public static decimal ImporteConPropina (decimal importe, decimal porcentajeDePropina)
        {
            return importe + Propina(importe, porcentajeDePropina);
        }

        public static decimal ImportePorPersona(decimal importe, decimal numerodepersonas, decimal porcentajeDePropina)
        {
            return (Propina(importe,porcentajeDePropina)/numerodepersonas);
        }



    }
}

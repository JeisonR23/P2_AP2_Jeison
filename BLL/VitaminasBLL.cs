using Microsoft.EntityFrameworkCore;
    public class VitaminasBLL
    {
        private Contexto _contexto;
        public VitaminasBLL(Contexto contexto)
        {
            _contexto = contexto; 
        }


        public Vitaminas? Buscar(int vitaminasId)
        {
            var vitamina = _contexto.Vitaminas
                .Where( v => v.VitaminaId == vitaminasId)
                .SingleOrDefault();
            return vitamina;
        }

        public List<Vitaminas> GetList()
        {
           return _contexto.Vitaminas.AsNoTracking().ToList();
        }
    }

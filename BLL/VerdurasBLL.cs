using Microsoft.EntityFrameworkCore;

public class VerdurasBLL
{
    private Contexto _contexto;
    public VerdurasBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int verdurasId)
    {
        return _contexto.Verduras.Any(verdura => verdura.VerduraId == verdurasId);
    }

    public bool Guardar(Verduras verdura)
    {
        return !Existe(verdura.VerduraId) ? Insertar(verdura) : Modificar(verdura);
    }

    public bool Insertar(Verduras verdura)
    {
        _contexto.Verduras.Add(verdura);

        foreach (var item in verdura.Detalle)
        {
            var vitamina = _contexto.Vitaminas.Find(item.VitaminaId);
            vitamina.Existencia += item.Cantidad;
        }

        bool paso = _contexto.SaveChanges() > 0;

        _contexto.Entry(verdura).State = EntityState.Detached;

        return paso;
    }

    public bool Modificar(Verduras verdura)
    {
        var anterior = _contexto.Verduras
           .Where(c => c.VerduraId == verdura.VerduraId)
           .Include(c => c.Detalle)
           .AsNoTracking()
           .SingleOrDefault();

        foreach (var item in anterior.Detalle)
        {
            var vitamina = _contexto.Vitaminas.Find(item.VitaminaId);
            vitamina.Existencia -= item.Cantidad;
        }
        _contexto.Entry(anterior).State = EntityState.Detached;

        anterior = null;

        _contexto.Database.ExecuteSqlRaw($"DELETE FROM VerdurasDetalle WHERE VerdurasId={verdura.VerduraId};");

        foreach (var item in verdura.Detalle)
        {
            var vitamina = _contexto.Vitaminas.Find(item.VitaminaId);
            vitamina.Existencia += item.Cantidad;

            _contexto.Entry(item).State = EntityState.Added;
        }

        _contexto.Entry(verdura).State = EntityState.Modified;

        var guardo = _contexto.SaveChanges() > 0;

        _contexto.Entry(verdura).State = EntityState.Detached;

        return guardo;
    }

    public bool Eliminar(Verduras verdura)
    {
        _contexto.Entry(verdura).State = EntityState.Deleted;

        foreach (var item in verdura.Detalle)
        {
            var vitamina = _contexto.Vitaminas.Find(item.VitaminaId);
            vitamina.Existencia -= item.Cantidad;
        }

        _contexto.Database.ExecuteSqlRaw($"DELETE FROM VerdurasDetalle WHERE VerdurasId={verdura.VerduraId};");

        bool paso = _contexto.SaveChanges() > 0;
        _contexto.Entry(verdura).State = EntityState.Detached;

        return paso;
    }

    public Verduras? Buscar(int verduraId)
    {
        Verduras? verdura = _contexto.Verduras
            .Include(c => c.Detalle)
            .Where(c => c.VerduraId == verduraId)
            .AsNoTracking()
            .SingleOrDefault();
        return verdura;
    }

    public List<Verduras> GetListByDate(DateTime desde, DateTime hasta)
    {
        var Verduras = _contexto.Verduras
            .Where(c => desde.Date <= c.FechaCreacion.Date && hasta.Date >= c.FechaCreacion.Date)
            .AsNoTracking()
            .ToList();

        return Verduras;
    }

    public List<Verduras> GetList()
    {
        List<Verduras> verduras = _contexto.Verduras
             .AsNoTracking()
             .ToList();

        return verduras;
    }
}




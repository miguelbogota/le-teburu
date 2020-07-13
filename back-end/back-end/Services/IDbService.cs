using back_end.Models.Entity;
using back_end.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Services {
  public interface IDbService<E, O, T> {

    // Funcion convierte el modelo a un modelo del entity
    public E ToEntity(O objeto);
    // Funcion convierte una lista de modelos a una de modelos del entity
    public ICollection<E> ToEntity(ICollection<O> objetos);
    // Funcion convierte el modelo de entity a un modelo
    public O ToObject(E objeto);
    // Funcion convierte una lista de modelos de entity a una de modelos
    public ICollection<O> ToObject(ICollection<E> objetos);

    // Funcion retorna todos los datos desde la db
    public Task<ICollection<O>> GetAll();
    // Funcion retorna todos los datos desde la db
    public Task<O> Get(T id);
    // Funcion agrega un dato a la db
    public Task<O> Add(O objeto);
    // Funcion actualiza un dato en la db
    public Task Update(O objeto);
    // Funcion elimina un dato de la db
    public Task<O> Delete(T id);

    // Funcion va a retornar todas las entidades de la db
    public Task<ICollection<E>> SetEntities();
    // Funcion va a retornar una entidad
    public Task<E> SetEntity(T id);

  }
}

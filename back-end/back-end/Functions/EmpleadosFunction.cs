using back_end.Models.Objects;
using back_end.Services.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Functions {
  public class EmpleadosFunction {

    // Propiedad de la base de datos
    private readonly Models.TeburuDBContext db;

    // Contructor con dependencia a la db
    public EmpleadosFunction(Models.TeburuDBContext db) { this.db = db; }

    public async Task<ICollection<EmpleadoModel>> GetEmpleados() {
      ICollection<EmpleadoModel> models = new List<EmpleadoModel>();
      foreach (EmpleadoModel model in await new EmpleadoService(db).GetAll()) {
        models.Add(await GetModel(model));
      }
      return models;
    }

    public async Task<EmpleadoModel> GetEmpleado(int id) {
      EmpleadoModel model = await new EmpleadoService(db).Get(id);
      return await GetModel(model);
    }


    // Funcion trae todas las propiedades de un modelo
    public async Task<EmpleadoModel> GetModel(EmpleadoModel model) {
      model.Jefe = await GetJefe(model.Jefe);
      model.DatosPersonales = await new DatosPersonalesService(db).Get(model.DatosPersonales.Documento);
      model.DatosPersonales.Ubicacion = await new UbicacionService(db).Get(model.DatosPersonales.Ubicacion.Id);
      model.Restaurante = await new RestauranteService(db).Get(model.Restaurante.Id);
      model.Restaurante.Ubicacion = await new UbicacionService(db).Get(model.Restaurante.Ubicacion.Id);
      return model;
    }

    // Funcion trae el jefe del empleado
    public async Task<EmpleadoModel> GetJefe(EmpleadoModel model) {
      if (model.Id != 0) {
        model = await new EmpleadoService(db).Get(model.Id);
        model.DatosPersonales = await new DatosPersonalesService(db).Get(model.DatosPersonales.Documento);
        model.DatosPersonales.Ubicacion = await new UbicacionService(db).Get(model.DatosPersonales.Ubicacion.Id);
        model.Restaurante = await new RestauranteService(db).Get(model.Restaurante.Id);
        model.Restaurante.Ubicacion = await new UbicacionService(db).Get(model.Restaurante.Ubicacion.Id);
        model.Jefe = null;
      }
      return model;
    }

  }
}

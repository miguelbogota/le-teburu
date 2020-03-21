import React from 'react'
import { useForm } from 'react-hook-form';

export default function RegistroDatos() {

  // Funcion para hacer el registro
  const onSubmit = (data) => {
    console.log(data);
  }

  const { register, handleSubmit, errors } = useForm();

  return (
    <div>

      <h3>Registro</h3>
      <h3>Datos Personales</h3>

      <form onSubmit={handleSubmit(onSubmit)}>

        {/* Campo para el numero de documento */}
        <div className="form-group">
          <label className="control-label">Documento</label>
          <input type="text" className="form-control" name="documento" ref={register({ required: true })} />
          {errors.documento && (<small className="form-text text-danger">Este campo es requerido.</small>)}
        </div>

        {/* Campo para el genero */}
        <div className="form-group">
          <label className="control-label">Tipo de documento</label>
          <select className="form-control" name="tipoDocumento" ref={register({ required: true })}>
            <option value="">Seleccione...</option>
            <option>Cedula</option>
            <option>Pasaporte</option>
            <option>Tarjeta de identidad</option>
          </select>
          {errors.tipoDocumento && (<small className="form-text text-danger">Seleccione una opcion.</small>)}
        </div>

        {/* Campo para el nombre */}
        <div className="form-group">
          <label className="control-label">Nombre</label>
          <input type="text" className="form-control" name="nombre" ref={register({ required: true })} />
          {errors.nombre && (<small className="form-text text-danger">Este campo es requerido.</small>)}
        </div>

        {/* Campo para el apellido */}
        <div className="form-group">
          <label className="control-label">Apellido</label>
          <input type="text" className="form-control" name="apellido" ref={register({ required: true })} />
          {errors.apellido && (<small className="form-text text-danger">Este campo es requerido.</small>)}
        </div>

        {/* Campo para el genero */}
        <div className="form-group">
          <label className="control-label">Genero</label>
          <select className="form-control" name="genero" ref={register({ required: true })}>
            <option value="">Seleccione...</option>
            <option value="M">Masculino</option>
            <option value="F">Femenino</option>
            <option value="O">Otro</option>
          </select>
          {errors.genero && (<small className="form-text text-danger">Seleccione una opcion.</small>)}
        </div>

        <div className="form-group">
          <label className="control-label">Numero de documento</label>
          <input type="text" className="form-control" />
        </div>

        <div className="form-group">
          <label htmlFor="tDocumento_id" className="control-label">Tipo de documento</label>
          <select className="form-control" id="tDocumento_id">
            <option value="Tarjeta de identidad">Tarjeta de identidad</option>
            <option value="Cedula de ciudanania">Cedula de ciudanania</option>
            <option value="Pasaporte">Pasaporte</option>
          </select>
        </div>

        <div className="form-group">
          <label className="control-label">Fecha de nacimiento</label>
          <input type="text" className="form-control" id="edad_id" name="Edad" />
        </div>

        <div className="form-group">
          <label className="control-label">Telefono</label>
          <input type="text" className="form-control" id="telefono" name="telefono" />
        </div>

        <div className="form-group">
          <label htmlFor="clave" className="control-label">Clave</label>
          <input type="text" className="form-control" id="clave" name="calve" />
        </div>

        <div className="form-group">
          <label className="control-label">Fecha de contratacion</label>
          <input type="text" className="form-control" id="fechaContratacon" name="Edad" />
        </div>

        <h3>Datos Empresa</h3>

        <div className="form-group">
          <label className="control-label">Direccion</label>
          <input type="text" className="form-control" id="direccion" name="direccion" />
        </div>

        <div className="form-group">
          <label className="control-label">Ciudad</label>
          <input type="text" className="form-control" id="ciudad" name="ciudad" />
        </div>

        <div className="form-group">
          <label className="control-label">Pais</label>
          <input type="text" className="form-control" id="pais" name="pais" />
        </div>

        <div className="form-group">
          <label htmlFor="cargo_id" className="control-label">Cargo</label>
          <select className="form-control" id="cargo_id">
            <option value="Gerente">Gerente</option>
            <option value="Cocina">Cocina</option>
            <option value="Caja">Caja</option>
          </select>
        </div>

        <div className="form-group">
          <label className="control-label">Lugar</label>
          <input type="text" className="form-control" id="Lugar" name="Lugar" />
        </div>

        <div className="form-group">
          <label htmlFor="correo_id" className="control-label">Correo</label>
          <input type="text" className="form-control" id="correo_id" name="correo" />
        </div>

        <div className="form-group">
          <button type="submit" className="btn btn-primary">Guardar</button>
        </div>

      </form>

    </div>
  )
}


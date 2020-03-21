import React, { Component } from 'react'
import { Link } from 'react-router-dom';
import Empleados from './Empleados';

export default class AdminEmpleados extends Component {

  render() {
    return (
      <div className="container">

        {/* Boton para agregar un nuevo usuario o para editar */}
        <div className="mt-4 d-block text-center">
          <Link to="/registro" className="btn btn-success">Agregar un empleado nuevo</Link>
        </div>

        {/* Tabla donde se mostraran todos los empleados */}
        <Empleados />

      </div>
    )
  }
}

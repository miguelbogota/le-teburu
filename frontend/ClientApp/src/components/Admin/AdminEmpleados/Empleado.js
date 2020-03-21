import React, { Component } from 'react'
import axios from 'axios';

export default class Empleado extends Component {

  constructor(props) {
    super(props);

    this.state = {
      empleado: props.empleado,
    }
  }

  // Funcion borra un record desde la api
  eliminarEmpleado = (id) => {
    axios.delete(`https://localhost:44387/api/employees/${id}`)
      .then(res => this.props.deleteItem(id));
  }

  render() {
    return (
      <tr>

        {/* Columas de la fila */}
        <th scope="row">{this.props.empleado.id}</th>
        <td>{this.props.empleado.persona.documento}</td>
        <td>{this.props.empleado.persona.nombre}</td>
        <td>{this.props.empleado.persona.apellido}</td>
        <td>{this.props.empleado.cargo}</td>

        {/* Acciones */}
        <td>
          <button className="btn btn-primary btn-sm">Editar</button>
          <button className="btn btn-danger btn-sm ml-1" onClick={() => this.eliminarEmpleado(this.props.empleado.id)}>Eliminar</button>
        </td>

      </tr>
    )
  }
}

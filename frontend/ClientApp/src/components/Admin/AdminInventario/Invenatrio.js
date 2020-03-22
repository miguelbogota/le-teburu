import React, { Component } from 'react'
import axios from 'axios';

export default class Invenatrio extends Component {
  constructor(props) {
    super(props);

    this.state = {
      inventario: props.inventario,
    }
  }

  // Funcion borra un record desde la api
  eliminarEmpleado = (id) => {
    axios.delete(`https://localhost/api/employees/${id}`)
      .then(res => this.props.deleteItem(id));
  }
  
  
  
  render() {
    return (
      <tr>

        {/* Columas de la fila */}
        <th scope="row">{this.props.inventario.id}</th>
        <td>{this.props.inventario.producto.nombre}</td>
        <td>{this.props.inventario.producto.cantidad}</td>
        <td>{this.props.inventario.fechaIngreso}</td>

        {/* Acciones */}
        <td>
          <button className="btn btn-primary btn-sm">Editar</button>
          <button className="btn btn-danger btn-sm ml-1" onClick={() => this.eliminarProducto(this.props.inventario.id)}>Eliminar</button>
        </td>

      </tr>
    )
  }
}

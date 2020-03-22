import React, { Component } from 'react'
import axios from 'axios';
import Invenatrio from './Invenatrio';

export default class TablaInvenatrio extends Component {
  constructor(props) {
    super(props)

    this.state = {
      invenatrio: [],
      isFetch: true
    }

    this.refrescarAPI = this.refrescarAPI.bind(this);
    this.deleteItem = this.deleteItem.bind(this);

  }

  componentDidMount() {
    this.refrescarAPI()
  }

  // Funcion para obtener la info de la API
  refrescarAPI = () => {
    axios.get("https://localhost/api/employees")
      .then(res => this.setState({ invenatrio: res.data, isFetch: false }));
  }

  deleteItem(id) {
    this.setState(prevState => {
      const newItems = prevState.invenatrio.filter((i) => i.id !== id);
      return {
        empleados: newItems
      }
    })
  }

  render() {
    if (this.state.isFetch) { return <div className="d-block text-center mt-4">Cargando...</div> }

    return (
      <div className="mt-4">
        {/* Tabla mostrando los usuarios */}
        <div className="table-responsive-lg text-center">
          <table className="table table-hover table-sm">
            <thead>
              <tr>

                {/* Headers de la tabla */}
                <th scope="col">Id</th>
                <th scope="col">Nombre</th>
                <th scope="col">Cantidad</th>
                <th scope="col">Fecha de ingreso</th>
                
              </tr>
            </thead>
            <tbody>

              {/* Loop para mostrar todos los usuarios en la tabla */}
              {this.state.invenatrio.map((i) =>
                <Invenatrio key={i.id} invenatrio={i} deleteItem={this.deleteItem} />
              )}

            </tbody>
          </table>
        </div>
      </div>
    )
  }
}

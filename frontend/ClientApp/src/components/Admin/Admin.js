import React, { Component } from 'react'
import axios from 'axios';
import Registro from './Registro';
import Usuarios from './Usuarios';

export default class Admin extends Component {

  constructor(props) {
    super(props)

    this.state = {
      empleados: [],
      isFetch: true
    }
  }

  componentDidMount() {
    axios.get("https://localhost:44387/api/employees")
      .then(res => this.setState({ empleados: res.data, isFetch: false }));
  }

  render() {
    if (this.state.isFetch) { return 'Cargando...' }

    return (
      <div className="container">

        <div className="row mt-3 mt-md-5">

          <div className="bg-white border rounded p-3 col-md-5">

            <Registro />
          </div>

          <div className="col-sm-7">
            <Usuarios users={this.state.empleados} />
          </div>
        </div>
      </div>
    )
  }
}

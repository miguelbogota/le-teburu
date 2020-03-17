import React, { Component } from 'react'

import Datos from './Datos';
import Tabla2 from './Tabla2';

export default class Inventario extends Component {
  render() {
    return (
      <div className="container">


        <div className="row mt-3 mt-md-5">

          <div className="bg-white border rounded p-3 col-md-5">
            <Datos />
          </div>

          <div className="col-sm-7">
            <Tabla2 />
          </div>
        </div>
      </div>
    )
  }
}

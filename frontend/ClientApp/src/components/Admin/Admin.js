import React, { Component } from 'react'

import Registro from './Registro';
import Usuarios from './Usuarios';

export default class Admin extends Component {
  render() {
    return (
      <div className="container">


        <div className="row mt-3 mt-md-5">

          <div className="bg-white border rounded p-3 col-md-5">
            <Registro />
          </div>

          <div className="col-sm-7">
            <Usuarios />
          </div>
        </div>
      </div>
    )
  }
}

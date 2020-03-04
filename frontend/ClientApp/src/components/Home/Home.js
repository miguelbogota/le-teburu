import React, { Component } from 'react'

// Componentes
import Productos from './Productos';
import Venta from './Venta';
import './Styles.css';

export default class Home extends Component {
  render() {
    return (
      <div className="row mt-4">
        
        <div className="col-md-6">
          <Productos />
        </div>

        <div className="col-md-6">
          <Venta />
        </div>

      </div>
    )
  }
}

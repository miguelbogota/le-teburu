import React, { Component } from 'react'

export default class Datos extends Component {
  render() {
    return (
      <div>
        <h3>Datos inventario</h3>

        <div className="form-group">
          <label className="control-label">Nombre producto</label>
          <input type="text" className="form-control" id="nombreProduc_id" name="NombreProduc" />
        </div>

        <div className="form-group">
          <label className="control-label">Fecha de ingreso</label>
          <input type="text" className="form-control" id="ingresoInven_id" name="ingresoInven" />
        </div>

        <div className="form-group">
          <label htmlFor="tProducto_id" className="control-label">Tipo de producto</label>
          <select className="form-control" id="tProducto_id">
            <option value="carnes">Carnes</option>
            <option value="legumbres">Legumbres</option>
            <option value="gaseosas">Gaseosas</option>
            <option value="salsas">Salsas</option>
            <option value="cocina">Cocina</option>
            <option value="aseo">Aseo</option>
            <option value="otros">Otros</option>
          </select>
        </div>

        <div className="form-group">
          <label htmlFor="fVencimiento_id" className="control-label">Fecha de vencimiento</label>
          <input type="text" className="form-control" id="fVencimiento_id" name="fVencimiento" />
        </div>

        <div className="form-group">
          <label htmlFor="cantidad_id" className="control-label">Cantidad</label>
          <input type="text" className="form-control" id="cantidad_id" name="cantidad" />
        </div>

      </div>
    )
  }
}
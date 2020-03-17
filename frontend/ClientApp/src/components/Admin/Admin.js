import React, { Component } from 'react'

import Registro from './Registro';
import Usuarios from './Usuarios';

export default class Admin extends Component {

  constructor (props){
    super(props)
  
    console.log("constructor")

    this.state ={
      Registro: [],
      Usuarios: []
    }
  }


  componentDidMount (){
    fetch ('')
    .then(Response => Response.json())
    .then (RegistroJson => this.setState({Registro: RegistroJson.result}))
  }

  componentDidMount (){
    fetch ('')
    .then(Response => Response.json())
    .then (UsuariosJson => this.setState({Usuarios: UsuariosJson.result}))
  }
  
  componentDidUpdate (){
    console.log ('update')
  }

  render() {

    return (
      <div className="container">


        <div className="row mt-3 mt-md-5">

          <div className="bg-white border rounded p-3 col-md-5">
            <This.state.Registro.map((Registro)=><Registro name = {Registro.displayname}/>)  />
          </div>

          <div className="col-sm-7">
            <this.state.Usuarios.map((Usuarios)=><Usuarios usu = {Usuarios.displayname}/>) />
          </div>
        </div>
      </div>
    )
  }
}

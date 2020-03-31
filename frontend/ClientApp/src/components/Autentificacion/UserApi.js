import { post, get } from "../lib/request";
import {  } from "../Registro/RegistroDatos";
export const createUser = async (
        documento, 
        tipoDumento, 
        nombre, 
        apellido, 
        genero, 
        fechaNacimiento, 
        telefono, 
        correo, 
        dirrecion, 
        ciudad, 
        pais,  
        contraseña, 
        cargo, 
        estadoActual, 
        salario, 
        tipoContrato, 
        fechaContratacion
) => {
  
  try {
    const response = await post("./RegistroDatos", {
      user: {
        documento, 
        tipoDumento, 
        nombre, 
        apellido, 
        genero, 
        fechaNacimiento, 
        telefono, 
        correo, 
        dirrecion, 
        ciudad, 
        pais,  
        contraseña, 
        cargo, 
        estadoActual, 
        salario, 
        tipoContrato, 
        fechaContratacion
      }
    });
    return response;
  } catch (error) {
    return error.response && error.response.status === 422
      ? "El correo electronico ya ha sido tomado."
      : "error desconocido. Inténtalo de nuevo";
  }
};
//modificar linea de codigo a usuario
export const getUsers = () => {
  return getData("/RegistroDatos", null);
};
//modificar linea de codigo a usuario
export const getUser = (jwt, id) => {
  return getData(`/RegistroDatos/${id}`, jwt);
};
//modificar linea de codigo a usuario
export const getCurrentUser = jwt => {
  return getData("/RegistroDatos/current", jwt);
};
//modificar linea de codigo a usuario
const getData = (endpoint, jwt) => {
  try {
    return get(endpoint, jwt);
  } catch (error) {
    return error;
  }
};
import redirect from "./redirect";
import { setCookie, getCookie, removeCookie } from "./sesion";
import { authenticate } from "./AuthApi";
import { createUser } from "./UserApi";
import { validateCredentials, validateNewUser } from "./validation";

// Iniciar sesión
export const signIn = async (correo, clave) => {
  const error = validateCredentials(correo, clave);
  if (error) {
    return error;
  }

  const res = await authenticate(correo, clave);
  if (!res.jwt) {
    return res;
  }
  //modificar linea de codigo a usuario
  setCookie("jwt", res.jwt);
  redirect("/user");
  return null;
};

// Registrar nuevos usuarios
export const signUp = async (documento, tipoDumento, nombre, apellido, genero, fechaNacimiento, 
  telefono, correo, dirrecion, ciudad, pais,  contraseña, cargo, estadoActual, salario, tipoContrato, fechaContratacion) => {
  const error = validateNewUser(documento, tipoDumento, nombre, apellido, genero, fechaNacimiento, 
    telefono, correo, dirrecion, ciudad, pais,  contraseña, cargo, estadoActual, salario, tipoContrato, fechaContratacion);
  if (error) {
    return error;
  }

  const res = await createUser(documento, tipoDumento, nombre, apellido, genero, fechaNacimiento, 
    telefono, correo, dirrecion, ciudad, pais,  contraseña, cargo, estadoActual, salario, tipoContrato, fechaContratacion);

  if (!res.data) {
    return res;
  }

  setCookie("success", `${name}, Su cuenta fue creada.`);
  redirect("./Login");
  return null;
};

// Finalizar sesión
export const signOut = (ctx = {}) => {
  if (process.browser) {
    removeCookie("jwt");
    redirect("/Login", ctx);
  }
};

// Acceder a el JWT token
export const getJwt = ctx => {
  return getCookie("jwt", ctx.req);
};

// Verificamos si estamos autenticados
export const isAuthenticated = ctx => !!getJwt(ctx);

// Redireccionar si ya estamos autenticados 
//modificar linea de codigo a usuario
export const redirectIfAuthenticated = ctx => {
  if (isAuthenticated(ctx)) {
    redirect("/Admin", ctx);
    return true;
  }
  return false;
};

// Verificamos si aún no estamos autenticados
export const redirectIfNotAuthenticated = ctx => {
  if (!isAuthenticated(ctx)) {
    redirect("/login", ctx);
    return true;
  }
  return false;
};
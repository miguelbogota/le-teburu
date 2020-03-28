import redirect from "./redirect";
import { setCookie, getCookie, removeCookie } from "./secion";
import { authenticate } from "./AuthApi";
import { createUser } from "./UserApi";
import { validateCredentials, validateNewUser } from "./validation";

// Iniciar sesión
export const signIn = async (email, password) => {
  const error = validateCredentials(email, password);
  if (error) {
    return error;
  }

  const res = await authenticate(email, password);
  if (!res.jwt) {
    return res;
  }
  //modificar linea de codigo a usuario
  setCookie("jwt", res.jwt);
  redirect("/user");
  return null;
};

// Registrar nuevos usuarios
export const signUp = async (name, email, password, password_confirmation) => {
  const error = validateNewUser(name, email, password, password_confirmation);
  if (error) {
    return error;
  }

  const res = await createUser(name, email, password, password_confirmation);

  if (!res.data) {
    return res;
  }

  setCookie("success", `${name}, your account was created.`);
  redirect("/login");
  return null;
};

// Finalizar sesión
export const signOut = (ctx = {}) => {
  if (process.browser) {
    removeCookie("jwt");
    redirect("/login", ctx);
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
    redirect("/user", ctx);
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
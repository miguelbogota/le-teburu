import { post } from "../lib/request";

export const authenticate = async (documento, contraseña) => {
  try {
    const res = await post("/user_token", {
      auth: {
        documento,
        contraseña
      }
    });
    return res.data;
  } catch (error) {
    return error.response && error.response.status === 404
      ? "Correo o clave incorrecto"
      : "Error desconocido. Inténtalo de nuevo";
  }
};
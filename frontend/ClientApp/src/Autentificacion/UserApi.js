import { post, get } from "../lib/request";

export const createUser = async (
  name,
  email,
  password,
  password_confirmation
) => {
  //modificar linea de codigo a usuario
  try {
    const response = await post("/users", {
      user: {
        name,
        email,
        password,
        password_confirmation
      }
    });
    return response;
  } catch (error) {
    return error.response && error.response.status === 422
      ? "Email is already taken."
      : "Unknown error. Please try again";
  }
};
//modificar linea de codigo a usuario
export const getUsers = () => {
  return getData("/users", null);
};
//modificar linea de codigo a usuario
export const getUser = (jwt, id) => {
  return getData(`/users/${id}`, jwt);
};
//modificar linea de codigo a usuario
export const getCurrentUser = jwt => {
  return getData("/users/current", jwt);
};
//modificar linea de codigo a usuario
const getData = (endpoint, jwt) => {
  try {
    return get(endpoint, jwt);
  } catch (error) {
    return error;
  }
};
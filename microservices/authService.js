const {
  validateNickName,
  validateEmail,
  validatePassword,
  validateNumber,
} = require("../microservices/validationsService");
const { insertUser, getUser } = require("../microservices/userService");

const registerUser = async (data) => {
  try {
    const { NickName, Correo, Clave, Nivel } = data;

    //Validar si el nickName cumple con las reglas
    const nickVal = validateNickName(NickName);
    if (nickVal != true) {
      return nickVal;
    }

    //Validar si el correo cumple con las reglas
    const correoVal = validateEmail(Correo);
    if (correoVal != true) {
      return correoVal;
    }

    //Validar si el clave cumple con las reglas
    const claveVal = validatePassword(Clave);
    if (claveVal != true) {
      return claveVal;
    }

    //Validar si el clave cumple con las reglas
    const nivelVal = validateNumber(Nivel);
    if (nivelVal != true) {
      return nivelVal;
    }

    //Los datos del usuario cumplen con todas las reglas

    //Registrar el usuario
    const res = await insertUser(data);

    return res;
  } catch (error) {
    return { error: "Error al registrar usuario.", response: error };
  }
};

const login = async (data) => {
  try {
    //Validar si el correo cumple con las reglas
    const correoVal = validateEmail(data.Correo);
    if (correoVal != true) {
      return correoVal;
    }

    //Validar si el clave cumple con las reglas
    const claveVal = validatePassword(data.Clave);
    if (claveVal != true) {
      return claveVal;
    }

    const res = await getUser(data);

    return res;
  } catch (error) {
    return { error: "Error al loguear usuario.", response: error };
  }
};

module.exports = { registerUser, login };

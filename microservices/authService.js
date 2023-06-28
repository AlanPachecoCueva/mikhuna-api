
const { validateNickName, validateEmail, validatePassword, validateNumber } = require("../microservices/validationsService");
const { insertUser, getUser } = require("../microservices/userService");

const registerUser = async (data) =>{
    const  {nickName, correo, clave, nivel } = data;

    //Validar si el nickName cumple con las reglas
    const nickVal = validateNickName(nickName);
    if ( nickVal != true){
        return nickVal;
    }

    //Validar si el correo cumple con las reglas
    const correoVal = validateEmail(correo);
    if ( correoVal != true){
        return correoVal;
    }

    //Validar si el clave cumple con las reglas
    const claveVal = validatePassword(clave);
    if ( claveVal != true){
        return claveVal;
    }

    //Validar si el clave cumple con las reglas
    const nivelVal = validateNumber(nivel);
    if ( nivelVal != true){
        return nivelVal;
    }

    //Los datos del usuario cumplen con todas las reglas

    //Registrar el usuario
    const res = await insertUser(data);

    if(!res){
        return false;
    }else{
        return res;
    }
}

const login = async (data) =>{

    //Validar si el correo cumple con las reglas
    const correoVal = validateEmail(data.correo);
    if ( correoVal != true){
        return correoVal;
    }

    //Validar si el clave cumple con las reglas
    const claveVal = validatePassword(data.clave);
    if ( claveVal != true){
        return claveVal;
    }

    const res = await getUser(data);

    if(!res){
        return false;
    }else{
        return res;
    }
}

module.exports = { registerUser, login };
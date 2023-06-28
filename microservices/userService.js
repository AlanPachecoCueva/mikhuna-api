const { getConnection, sql } = require("../database/dbConnection.js");

const insertUser = async (data) => {
  let con;
  try {
    con = await getConnection();
    // Definir la consulta SQL de inserción
    const query = `INSERT INTO Usuarios (NickName, Correo, Clave, Nivel) VALUES (@valorNickName, @valorCorreo, @valorClave, @valorNivel)`;

    // Crear un objeto de solicitud de la consulta
    const request = new sql.Request(con);

    // Asignar los valores a los parámetros de la consulta
    request.input("valorNickName", sql.VarChar, data.nickName);
    request.input("valorCorreo", sql.VarChar, data.correo);
    request.input("valorClave", sql.VarChar, data.clave);
    request.input("valorNivel", sql.Int, data.nivel);

    // Ejecutar la consulta SQL de inserción
    const result = await request.query(query);

    console.log("Nuevo registro insertado:", result);
    return result;
  } catch (error) {
    console.error("Error al insertar el registro:", error);
    return false;
  } finally {
    // Cerrar la conexión a la base de datos
    await con.close();
  }
};

const deleteUser = async (data) => {
  const { correo, clave } = data;
  let con;
  try {
    con = await getConnection();
    // Definir la consulta SQL para eliminar el registro
    const query = `DELETE FROM Usuarios WHERE Correo = @correo AND Clave = @clave`;

    // Crear un objeto de solicitud de la consulta
    const request = new sql.Request(con);

    // Asignar los valores a los parámetros de la consulta
    request.input("correo", sql.VarChar, correo);
    request.input("clave", sql.VarChar, clave);

    // Ejecutar la consulta SQL de eliminación
    const result = await request.query(query);

    console.log("Registro eliminado:", result);
    return result;
  } catch (error) {
    console.error("Error al eliminar el registro:", error);
    return false;
  } finally {
    // Cerrar la conexión a la base de datos
    await con.close();
  }
};

const updateUser = async (data) => {
  const {
    correoAnterior,
    claveAnterior,
    nickName,
    correo,
    clave,
    nivel,
    imagen,
  } = data;
  let con;
  try {
    // Establecer conexión con la base de datos
    con = await getConnection();

    // Definir la consulta SQL para actualizar el registro
    const query = `UPDATE Usuarios SET NickName = @nickName, Correo = @correo, Clave = @clave, Nivel = @nivel, Imagen = @imagen WHERE Correo = @correoAnterior AND Clave = @claveAnterior`;

    // Crear un objeto de solicitud de la consulta
    const request = new sql.Request();

    // Asignar los valores a los parámetros de la consulta
    request.input("nickName", sql.VarChar, nickName);
    request.input("correo", sql.VarChar, correo);
    request.input("clave", sql.VarChar, clave);
    request.input("nivel", sql.Int, nivel);
    request.input("imagen", sql.VarChar, imagen);
    request.input("correoAnterior", sql.VarChar, correoAnterior);
    request.input("claveAnterior", sql.VarChar, claveAnterior);

    // Ejecutar la consulta SQL de actualización
    const result = await request.query(query);

    console.log("Registro actualizado:", result);
    return result;
  } catch (error) {
    console.error("Error al actualizar el registro:", error);
    return false;
  } finally {
    // Cerrar la conexión a la base de datos
    await con.close();
  }
};

const getUser = async (data) => {
  const { correo, clave } = data;
  let con;
  try {
    con = await getConnection();
    // Definir la consulta SQL para obtener el usuario
    const query =
      "SELECT * FROM Usuarios WHERE Correo = @correo AND Clave = @clave";

    // Crear un objeto de solicitud de la consulta
    const request = new sql.Request(con);

    // Asignar los valores a los parámetros de la consulta
    request.input("correo", sql.VarChar, correo);
    request.input("clave", sql.VarChar, clave);

    // Ejecutar la consulta SQL de obtención del usuario
    const result = await request.query(query);
    console.log("result getUser: ", result);
    if (result.recordset.length > 0) {
      console.log("Usuario encontrado:", result.recordset[0]);
      return result.recordset[0];
    } else {
      console.log("Usuario no encontrado");
      return false;
    }
  } catch (error) {
    console.error("Error al obtener el usuario:", error);
    return false;
  } finally {
    // Cerrar la conexión a la base de datos
    await con.close();
  }
};

module.exports = { insertUser, deleteUser, updateUser, getUser };
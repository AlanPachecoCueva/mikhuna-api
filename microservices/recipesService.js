const { getConnection, sql } = require("../database/dbConnection.js");

const addRecipe = async (data) => {
  const { Nombre, Duracion, UrlImagen } = data;
  let CalificacionPromedio = 1;
  let con;
  try {
    con = await getConnection();
    // Definir la consulta SQL de inserción
    const query = `INSERT INTO Recetas (Nombre, Duracion, UrlImagen, CalificacionPromedio) VALUES (@nombre, @duracion, @urlImagen, @calificacionPromedio)`;

    // Crear un objeto de solicitud de la consulta
    const request = new sql.Request(con);

    // Asignar los valores a los parámetros de la consulta
    request.input("nombre", sql.VarChar, Nombre);
    request.input("duracion", sql.Real, Duracion);
    request.input("urlImagen", sql.VarChar, UrlImagen);
    request.input("calificacionPromedio", sql.Real, CalificacionPromedio);
    
    // Ejecutar la consulta SQL de inserción
    const result = await request.query(query);

    console.log("Nuevo registro insertado:", result);
    return { status: true, content: data };
  } catch (error) {
    console.error("Error al insertar el registro:", error);
    return { status: false, content: error };
  } finally {
    // Cerrar la conexión a la base de datos
    await con.close();
  }
};

const addIngredient = async (data) => {
  const { Nombre, Unidad, RecetaID } = data;
  let con;
  try {
    con = await getConnection();
    // Definir la consulta SQL de inserción
    const query = `INSERT INTO Ingredientes (Nombre, Unidad, RecetaID) VALUES (@nombre, @unidad, @recetaID)`;

    // Crear un objeto de solicitud de la consulta
    const request = new sql.Request(con);

    // Asignar los valores a los parámetros de la consulta
    request.input("nombre", sql.VarChar, Nombre);
    request.input("unidad", sql.VarChar, Unidad);
    request.input("recetaID", sql.Int, RecetaID);

    // Ejecutar la consulta SQL de inserción
    const result = await request.query(query);

    console.log("Nuevo registro insertado:", result);
    return { status: true, content: data };
  } catch (error) {
    console.error("Error al insertar el registro:", error);
    return { status: false, content: error };
  } finally {
    // Cerrar la conexión a la base de datos
    await con.close();
  }
};

const addStep = async (data) => {
    const { Paso, RecetaID } = data;
    let con;
    try {
      con = await getConnection();
      // Definir la consulta SQL de inserción
      const query = `INSERT INTO Pasos (Paso, RecetaID) VALUES (@paso, @recetaID)`;
  
      // Crear un objeto de solicitud de la consulta
      const request = new sql.Request(con);
  
      // Asignar los valores a los parámetros de la consulta
      request.input("Paso", sql.VarChar, Paso);
      request.input("recetaID", sql.Int, RecetaID);
  
      // Ejecutar la consulta SQL de inserción
      const result = await request.query(query);
  
      console.log("Nuevo registro insertado:", result);
      return { status: true, content: data };
    } catch (error) {
      console.error("Error al insertar el registro:", error);
      return { status: false, content: error };
    } finally {
      // Cerrar la conexión a la base de datos
      await con.close();
    }
  };

module.exports = { addRecipe, addIngredient, addStep };

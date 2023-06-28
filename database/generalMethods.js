const { getConnection } = require("./dbConnection.js");

const getAllByTable = async (tableName) => {
  let con;
  try {
    con = await getConnection();
    const query = `SELECT * FROM ${tableName}`;

    const result = await con.query(query);
    console.log("Resultados de la consulta GET:", result.recordset);
    // Lógica para obtener y devolver los usuarios
    return result;
  } catch (error) {
    // Manejo de errores
    console.error(
      `generalMethods getAllByTable(${tableName}): Error al ejecutar la consulta:`,
      error
    );
    return false;
  } finally {
    if (con) {
      await con.close();
    }
  }
};

module.exports = { getAllByTable };
